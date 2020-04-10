using System;
using UnityEngine;

namespace Com.Github.Knose1.InfinitePoket.Inventory
{
	public abstract class Item {

		public static event Action<Item> OnCollect;

		private bool _isCollected = false;
		public bool IsCollected
		{
			get => _isCollected;
		}

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

		protected Item() {}

		public bool HasSpecificData
		{
			get => _hasSpecificData;
			protected set => _hasSpecificData = value;
		}

		public GameObject gameObject 
		{ 
			get; 
			set;
		}

		public void Collect() 
		{
			if (_isCollected)
			{
				Debug.LogWarning("The item you try to collect has already been collected");
				return;
			}
			_isCollected = true;
			OnCollect?.Invoke(this);
		}
		public void Drop()
		{
			if (!_dropable) return;

			if (!_isCollected)
			{
				Debug.LogWarning("The item you try to collect has not been collected");
				return;
			}
			_isCollected = false;
			gameObject.SetActive(false);
		}
		public bool IsTheSameOf(Item item) => item._id == _id;
	}
}