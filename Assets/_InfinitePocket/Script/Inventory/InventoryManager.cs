using Com.Github.Knose1.InfinitePocket.Game.Pockets;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Github.Knose1.InfinitePocket.Inventory
{
	[AddComponentMenu("_InfinitePocket/Inventory/"+nameof(InventoryManager))]
	public class InventoryManager : MonoBehaviour {

		public static event Action OnInventoryUpdate;

		private static InventoryManager _instance;
		public static InventoryManager Instance
		{
			get
			{
				InventoryManager lInstance = _instance ? _instance : (_instance = FindObjectOfType<InventoryManager>());

				Debug.Assert(lInstance, "There is no instance of " + nameof(InventoryManager));

				return lInstance;
			}
			set
			{
				if (!_instance) _instance = value;
				else
				{
					Debug.LogWarning("Trying to create an instance of " + nameof(InventoryManager));
				}
			}
		}

		private void OnEnable()
		{
			Item.OnCollect += Item_OnCollect;
		}

		private void Item_OnCollect(Item obj) 
		{
			CollectItem(obj);
		}
		public void CollectItem(Item obj)
		{
			List<InventoryStack> inventory = CurrentInventory;

			InventoryStack stack;
			for (int i = inventory.Count - 1; i >= 0; i--)
			{
				stack = inventory[i];
				if (!stack.IsTheSameOf(obj)) continue;
				if (!stack.Add(obj)) continue;

				OnInventoryUpdate?.Invoke();
				return;
			}

			inventory.Add(new InventoryStack(obj));

			OnInventoryUpdate?.Invoke();
		}
		public void RemoveItem(Item obj, int count=1)
		{
			List<InventoryStack> inventory = PocketManager.Instance.CurrentPocket.inventory;

			InventoryStack stack;
			for (int i = inventory.Count - 1; i >= 0; i--)
			{
				stack = inventory[i];
				if (!stack.IsTheSameOf(obj)) continue;
				if (!stack.Remove(obj, count)) continue;

				OnInventoryUpdate?.Invoke();
				return;
			}

		}

		public List<InventoryStack> CurrentInventory => PocketManager.Instance.CurrentPocket.inventory;

		private void OnDisable()
		{
			Item.OnCollect -= Item_OnCollect;
		}

		private void OnDestroy()
		{
			OnDisable();
		}
	}

	public class InventoryStack
	{
		public const int MAX_STACK = 64;
		
		public int count;
		private Item _item;
		public Item Item => _item;

		public InventoryStack(Item item)
		{
			this.count = 1;
			this._item = item;
		}

		public bool IsTheSameOf(Item item) {
			return item.IsTheSameOf(item);
		}

		public bool Add(Item item)
		{
			if (!IsTheSameOf(item)) 
			{
				Debug.LogWarning("The id of the item is different than the Stack's item id");
				return false;
			}

			int lMaxStack = this.Item.HasSpecificData ? 1 : MAX_STACK;

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
		public bool Remove(Item item, int count = 1)
		{
			if(!IsTheSameOf(item))
			{
				Debug.LogWarning("The item is different than the Stack's item");
				return false;
			}

			int oldCount = this.count;
			this.count -= count;

			if (this.count < 0) {
				this.count = 0;
			}

			return oldCount != this.count ;
		}
	}

	public enum ItemId 
	{
		Abstract = 0,
		Map = 1,
		Mana = 2
	}
}