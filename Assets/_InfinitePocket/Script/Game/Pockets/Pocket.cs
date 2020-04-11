using Com.Github.Knose1.InfinitePocket.Inventory;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Github.Knose1.InfinitePocket.Game.Pockets
{
	public class Pocket : IDisposable
	{
		private static int _NextPocketId = 0;

		private bool isDestroyed = false;

		public List<InventoryStack> inventory;
		public int id;
		public int parentCount;
		public GameObject gameObject;
		public Pocket parent;
		public List<Pocket> childs;

		public Pocket(GameObject gameObject, int parentCount = 0, Pocket parent = null)
		{
			this.inventory = new List<InventoryStack>();
			this.id = _NextPocketId++;
			this.parentCount = parentCount;
			this.gameObject = gameObject;
			this.parent = parent;
		}

		public void Dispose()
		{
			isDestroyed = true;
			UnityEngine.Object.Destroy(gameObject);
		}

		public void DisposeWithChilds(Pocket exceptionPocket = null)
		{
			Pocket lPocket;
			for (int i = childs.Count - 1; i >= 0; i--)
			{
				lPocket = childs[i];
				if (lPocket == exceptionPocket)
				{

				}
			}

			if (exceptionPocket != null)
			{
				exceptionPocket.parent = null;
			}
		}

		public static implicit operator bool(Pocket pocket) => pocket.isDestroyed;
	}
}