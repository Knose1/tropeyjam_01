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

		public List<InventoryStack> inventory = new List<InventoryStack>();
		public int id;
		public int parentCount;
		public Level level;
		public Pocket parent;
		public List<Pocket> childs = new List<Pocket>();

		public Pocket(Level level, int parentCount = 0, Pocket parent = null)
		{
			this.id = _NextPocketId++;
			this.parentCount = parentCount;
			this.level = level;
			this.parent = parent;
		}

		public void Dispose()
		{
			Debug.Log("[POCKET] Pocket with id \""+id+"\" disposed");
			isDestroyed = true;
			UnityEngine.Object.Destroy(level.gameObject);
		}

		public void DisposeWithChilds(Pocket exceptionPocket = null)
		{
			Pocket lPocket;
			for (int i = childs.Count - 1; i >= 0; i--)
			{
				lPocket = childs[i];
				if (lPocket == exceptionPocket)
					continue;

				lPocket.DisposeWithChilds();
			}

			if (exceptionPocket != null)
			{
				exceptionPocket.parent = null;
			}

			Dispose();
		}

		public static implicit operator bool(Pocket pocket) => pocket != null && !pocket.isDestroyed;
	}
}