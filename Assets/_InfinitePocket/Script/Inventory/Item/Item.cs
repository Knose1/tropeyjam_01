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
		public string Description => _description;

		[SerializeField] protected UIInventoryElement _uiInventoryPrefab = null;
		public UIInventoryElement UiInventoryPrefab => _uiInventoryPrefab;

		public static event Action<Item> OnCollect;

		private bool _dropable = false;
		public bool Dropable
		{
			get => _dropable;
			protected set => _dropable = value;
		}

		private ItemId _id = ItemId.Abstract;
		public ItemId Id { 
			get => _id; 
			protected set => _id = value;
		}

		private bool _hasSpecificData;
		public bool HasSpecificData
		{
			get => _hasSpecificData;
			protected set => _hasSpecificData = value;
		}

		public void Collect() 
		{
			Debug.Log("[Item] Collected "+GetType().Name);
			OnCollect?.Invoke(this);
		}

		virtual public bool IsTheSameOf(Item item) => item._id == _id;
	}
}