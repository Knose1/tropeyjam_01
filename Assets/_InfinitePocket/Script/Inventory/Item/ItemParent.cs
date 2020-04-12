using UnityEngine;

namespace Com.Github.Knose1.InfinitePocket.Inventory
{
	[CreateAssetMenu(fileName = nameof(ItemParent), menuName = "InfinitePocket/" + nameof(ItemParent))]
	public class ItemParent : Item
	{
		public ItemParent() : base()
		{
			Id = ItemId.Pocket;
			HasSpecificData = true;
		}
	}
}
