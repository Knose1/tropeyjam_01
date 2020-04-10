using System;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Github.Knose1.InfinitePoket.Inventory
{
	public struct InventoryStack
	{
		public const int MAX_STACK = 64;
		
		public int count;
		public readonly Item item;

		public InventoryStack(Item item)
		{
			this.count = 0;
			this.item = item;
		}

		public bool HasTheSameId(Item item) {
			return item.IsTheSameOf(item);
		}

		public bool Add(Item item)
		{
			if (!HasTheSameId(item)) 
			{
				Debug.LogWarning("The id of the item is different than the Stack's item id");
				return false;
			}
			if (count == MAX_STACK)
			{
				return false;
			}
			++count;
			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="count"></param>
		/// <returns>False if nothing has been removed</returns>
		public bool Remove(int count = 1)
		{
			this.count -= count;

			if (this.count < 0) {
				this.count = 0;
				return false;
			}
			return true;
		}
	}

	public enum ItemId 
	{
		Abstract = 0
	}

	public class InventoryManager : MonoBehaviour {
		
		

		private void Start () {
			
		}
	}
}