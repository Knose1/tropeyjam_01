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

		private const int MAX_POCKET_PARENT = 3;
		public delegate void DelegateCreatePocket(Pocket current, Pocket old);

		public event DelegateCreatePocket OnCreatePocket;
		public event DelegateCreatePocket OnPocketLoaded;

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
			CreateDeeperPocketAndSetAsCurrent();
		}

		private Pocket _currentPocket = null;
		public Pocket CurrentPocket => _currentPocket;


		private List<Pocket> parentHierarchy = new List<Pocket>();

		public Pocket CreateDeeperPocketAndSetAsCurrent()
		{
			Pocket lPocket = new Pocket(pocketGenerator.Generate(), Mathf.Clamp(parentHierarchy.Count, 0, MAX_POCKET_PARENT), _currentPocket);
			
			if (_currentPocket != null)
			{
				_currentPocket.childs.Add(lPocket);
			}
			else Debug.Log("[POCKET] Created the first pocket");
			
			parentHierarchy.Add(_currentPocket);
			if (parentHierarchy.Count == MAX_POCKET_PARENT + 1)
			{
				parentHierarchy[0].DisposeWithChilds(parentHierarchy[1]);
			}
			else if (parentHierarchy.Count > MAX_POCKET_PARENT)
			{
				Debug.LogError("[POCKET] ParentHierarchy excess the limit (" + MAX_POCKET_PARENT + ")");
				parentHierarchy[0].DisposeWithChilds(parentHierarchy[1]);
			}

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

				}
			}
			else GameManager.Instance.SetLevel(CreateDeeperPocketAndSetAsCurrent().level);
		}

		public void LoadParentPocket()
		{

		}
	}
}
