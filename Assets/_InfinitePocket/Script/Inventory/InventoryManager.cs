using Com.Github.Knose1.InfinitePocket.Game;
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

		[SerializeField] ItemMap prefabItemPocket  = null;
		[SerializeField] ItemParent backwardArrow = null;
		[SerializeField] List<ItemShop> shops = null;

		private void OnEnable()
		{
			Item.OnCollect += Item_OnCollect;
			PocketManager.Instance.OnCreatePocket += PocketManager_OnCreatePocket;
			GameManager.Instance.OnLevelSet += GameManager_OnLevelSet;
		}

		private void GameManager_OnLevelSet()
		{
			OnInventoryUpdate?.Invoke();
		}

		private void PocketManager_OnCreatePocket(Pocket current, Pocket old)
		{
			if (old)
			{
				ItemMap pocketItem = Instantiate(prefabItemPocket);
				pocketItem.pocketId = current.id;
				old.inventory.Add(new InventoryStack(pocketItem));

				ItemParent parentItem = Instantiate(backwardArrow);
				parentItem.pocketId = old.id;
				AddItem(parentItem, false);
			}
			else AddItem(backwardArrow, false);

			int maxIndex = shops.Count - 1;
			for (int i = 0; i <= maxIndex; i++)
			{
				AddItem(shops[i], i == maxIndex);
			}

		}

		private void Item_OnCollect(Item obj) 
		{
			AddItem(obj);
		}
		public void AddItem(Item obj, bool callEvent = true)
		{
			List<InventoryStack> inventory = CurrentInventory;

			InventoryStack stack;
			for (int i = inventory.Count - 1; i >= 0; i--)
			{
				stack = inventory[i];
				if (!stack.IsTheSameOf(obj)) continue;
				if (!stack.Add(obj)) continue;

				Debug.Log("[Inventory] Added " + obj.Name);
				if (callEvent) OnInventoryUpdate?.Invoke();
				return;
			}

			Debug.Log("[Inventory] Create a stack for " + obj.Name);
			inventory.Add(new InventoryStack(obj));


			if (callEvent) OnInventoryUpdate?.Invoke();
		}
		public void RemoveItem(Item obj, int count=1, bool callEvent = true)
		{
			List<InventoryStack> inventory = PocketManager.Instance.CurrentPocket.inventory;

			InventoryStack stack;
			for (int i = inventory.Count - 1; i >= 0; i--)
			{
				stack = inventory[i];
				if (!stack.IsTheSameOf(obj)) continue;

				int removed = stack.Remove(obj, count);
				
				if (stack.count == 0)
				{
					inventory.Remove(stack);
				}

				if (removed != count)
				{
					count -= removed;
					continue;
				}

				if (callEvent) OnInventoryUpdate?.Invoke();
				return;
			}

		}
		public int Count(Item itemToCount)
		{
			List<InventoryStack> inventory = PocketManager.Instance.CurrentPocket.inventory;

			InventoryStack stack;

			int toReturn = 0;
			
			for (int i = inventory.Count - 1; i >= 0; i--)
			{
				stack = inventory[i];
				if (!stack.IsTheSameOf(itemToCount)) continue;
				
				toReturn += stack.count;
			}

			return toReturn;
		}

		public List<InventoryStack> CurrentInventory => PocketManager.Instance.CurrentPocket.inventory;

		private void OnDisable()
		{
			Item.OnCollect -= Item_OnCollect;
			PocketManager.Instance.OnCreatePocket -= PocketManager_OnCreatePocket;
			GameManager.Instance.OnLevelSet -= GameManager_OnLevelSet;
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
			return _item.IsTheSameOf(item);
		}

		public bool Add(Item item)
		{
			if (!IsTheSameOf(item)) 
			{
				Debug.LogWarning("The id of the item is different than the Stack's item id");
				return false;
			}

			int lMaxStack = Item.CanStack ? MAX_STACK : 1;

			if (count >= lMaxStack)
			{
				return false;
			}
			++count;
			return true;
		}

		public int Remove(Item item, int count = 1)
		{
			if(!IsTheSameOf(item))
			{
				Debug.LogWarning("The item is different than the Stack's item");
				return 0;
			}

			int oldCount = this.count;
			this.count -= count;

			if (this.count < 0) {
				this.count = 0;
			}

			return oldCount - this.count ;
		}
	}

	public enum ItemId 
	{
		Abstract = 0,
		Pocket = 1,
		Mana = 2,
		Map = 3,
		PocketParent = 4,
		Shop = 5
	}
}