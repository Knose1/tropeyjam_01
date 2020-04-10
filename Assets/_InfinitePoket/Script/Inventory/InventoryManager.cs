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

			int lMaxStack = this.item.HasSpecificData ? 1 : MAX_STACK;

			if (count >= lMaxStack)
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
		Abstract = 0,
		Map = 1
	}

	public class InventoryManager : MonoBehaviour {

		public List<List<InventoryStack>> inventoryByPoket;

		private void Start () 
		{
			OnEnable();
		}

		private void OnEnable()
		{
			Item.OnCollect += Item_OnCollect;
		}

		private void Item_OnCollect(Item obj) => throw new NotImplementedException();

		private void OnDisable()
		{
			Item.OnCollect += Item_OnCollect;
		}

		private void OnDestroy()
		{
			OnDisable();
		}

		private void SetpoketId()
	}
}