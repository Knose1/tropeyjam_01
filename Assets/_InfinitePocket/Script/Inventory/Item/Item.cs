using System;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Github.Knose1.InfinitePocket.Inventory
{
	public abstract class Item {

		private List<Item> _list = new List<Item>();
		public List<Item> List => _list;

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

		protected Item() 
		{
			AddToList();
		}
		protected void AddToList() => _list.Add(this);

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

		//Useless
		/*
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
		*/
		virtual public bool IsTheSameOf(Item item) => item._id == _id;
	}
}