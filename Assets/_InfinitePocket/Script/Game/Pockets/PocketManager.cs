using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

namespace Com.Github.Knose1.InfinitePocket.Game.Pockets
{
	[AddComponentMenu("_InfinitePocket/Game/" + nameof(PocketManager))]
	public class PocketManager : MonoBehaviour
	{
		private const int MAX_POCKET_PARENT = 3;

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


		private void Start()
		{
			CreateDeeperPocket();
		}

		private Pocket _currentPocket = null;
		public Pocket CurrentPocket => _currentPocket;

		private List<Pocket> parentHierarchy = new List<Pocket>();

		public Pocket CreateDeeperPocket()
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
				Debug.LogError("[POCKET] ParentHierarchy excess the limit ("+ MAX_POCKET_PARENT+")");
			
			return _currentPocket = lPocket;
		}
	}
}
