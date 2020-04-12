using UnityEngine;

namespace Com.Github.Knose1.InfinitePocket.Inventory
{
	[CreateAssetMenu(fileName = nameof(ItemMana), menuName = "InfinitePocket/" + nameof(ItemMana))]
	public class ItemMana : Item
	{
		public ItemMana()
		{
			Dropable = true;
			Id = ItemId.Mana;
			HasSpecificData = false;
		}
	}
}