using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;
using Com.Github.Knose1.InfinitePocket.Inventory;

namespace Com.Github.Knose1.InfinitePocket.Game.Pockets
{
	[AddComponentMenu("_InfinitePocket/Game/" + nameof(PocketManager))]
	public class PocketManager : MonoBehaviour
	{

		private const int MAX_POCKET_PARENT = 2;
		public delegate void DelegateCreatePocket(Pocket current, Pocket old);

		public event DelegateCreatePocket OnCreatePocket;

		private static PocketManager _instance;
		public static PocketManager Instance
		{
			get
			{
				PocketManager lInstance = _instance ? _instance : (_instance = FindObjectOfType<PocketManager>());

				Debug.Assert(lInstance, "There is no instance of " + nameof(PocketManager));

				return lInstance;
			}
			set 
			{
				if (!_instance)	_instance = value;
				else
				{
					Debug.LogWarning("Trying to create an instance of "+nameof(PocketManager));
				}
			}
		}

		[SerializeField] private PocketGenerator pocketGenerator = null;


		private void Awake()
		{
			pocketGenerator.Start();
			GameManager.Instance.SetLevel(CreateDeeperPocketAndSetAsCurrent().level);
		}

		private Pocket _currentPocket = null;
		public Pocket CurrentPocket => _currentPocket;


		private List<Pocket> parentHierarchy = new List<Pocket>();

		public Pocket CreateDeeperPocketAndSetAsCurrent()
		{
			Pocket lPocket = new Pocket(pocketGenerator.Generate(), Mathf.Clamp(parentHierarchy.Count, 0, MAX_POCKET_PARENT), _currentPocket);

			if (_currentPocket)
			{
				_currentPocket.childs.Add(lPocket);
				AddCurrentPocketToParentHierarchy();
			}
			Debug.Log("[POCKET] Created pocket id " + lPocket.id + (_currentPocket ? "; parrent id :" + _currentPocket.id : ""));

			Pocket oldPocket = _currentPocket;
			_currentPocket = lPocket;

			OnCreatePocket?.Invoke(lPocket, oldPocket);
			return lPocket;
		}

		public void LoadDeeperPocket(int pocketId)
		{
			if (pocketId != -1)
			{
				List<Pocket> childs = _currentPocket.childs;
				for (int i = childs.Count - 1; i >= 0; i--)
				{
					Pocket child = childs[i];

					if (child.id == pocketId)
					{
						AddCurrentPocketToParentHierarchy();

						_currentPocket = child;
						
						GameManager.Instance.SetLevel(_currentPocket.level);
						return;
					}
				}

				Debug.LogError(
					$"[POCKET] Trying to load a pocket which is not child of the current pocket.\n" +
					$"Current Pocket: {_currentPocket.id}.\n" +
					$"Pocket to load: {pocketId}"
				);
			}
			else GameManager.Instance.SetLevel(CreateDeeperPocketAndSetAsCurrent().level);
		}

		public void LoadParentPocket()
		{
			if (parentHierarchy.Count == 0)
			{
				Debug.LogError(new NotImplementedException());
				return;
			}

			_currentPocket = parentHierarchy[parentHierarchy.Count - 1];
			parentHierarchy.Remove(_currentPocket);

			GameManager.Instance.SetLevel(_currentPocket.level);
		}

		private void AddCurrentPocketToParentHierarchy()
		{
			parentHierarchy.Add(_currentPocket);
			if (parentHierarchy.Count == MAX_POCKET_PARENT + 1) {}
			else if (parentHierarchy.Count > MAX_POCKET_PARENT)
			{
				Debug.LogError("[POCKET] ParentHierarchy excess the limit (" + MAX_POCKET_PARENT + ")");
			}
			else return;

			parentHierarchy[0].DisposeWithChilds(parentHierarchy[1]);
			parentHierarchy.RemoveAt(0);
		}
	}
}
