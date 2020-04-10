using UnityEngine;

namespace Com.Github.Knose1.InfinitePoket.Inventory
{
	public abstract class Item  {

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

		public bool IsTheSameOf(Item item) => item._id == _id;
	}
}