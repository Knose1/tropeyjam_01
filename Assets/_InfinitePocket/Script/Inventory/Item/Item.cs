using Com.Github.Knose1.InfinitePocket.UI.Element;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Github.Knose1.InfinitePocket.Inventory
{
	public abstract class Item : ScriptableObject {

		[SerializeField] protected string _name;
		public string Name => _name;

		[SerializeField, TextArea()] protected string _description;
		virtual public string Description => _description;

		[SerializeField] protected UIInventoryElement _uiInventoryPrefab = null;
		public UIInventoryElement UiInventoryPrefab => _uiInventoryPrefab;

		public static event Action<Item> OnCollect;

		abstract public ItemId Id { get; }
		abstract public bool CanStack { get; }

		public void Collect() 
		{
			Debug.Log("[Item] Collected "+GetType().Name);
			OnCollect?.Invoke(this);
		}

		virtual public bool IsTheSameOf(Item item) => item.Id == Id;
	}
}