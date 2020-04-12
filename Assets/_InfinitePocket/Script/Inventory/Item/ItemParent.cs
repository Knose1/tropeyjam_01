using UnityEngine;

namespace Com.Github.Knose1.InfinitePocket.Inventory
{
	[CreateAssetMenu(fileName = nameof(ItemParent), menuName = "InfinitePocket/" + nameof(ItemParent))]
	public class ItemParent : Item
	{
		public override ItemId Id => ItemId.PocketParent;
		public override bool CanStack => false;
	}
}
