///-----------------------------------------------------------------
/// Author : #DEVELOPER_NAME#
/// Date : #DATE#
///-----------------------------------------------------------------

using Com.Github.Knose1.InfinitePocket.Inventory;
using UnityEngine.EventSystems;

namespace Com.Github.Knose1.InfinitePocket.UI.Element
{
	public class ShopItemUIElement : ButtonInventoryElement
	{
		public override void Click(PointerEventData eventData)
		{
			ItemShop shop = (stack.Item as ItemShop);
			
			int cost = shop.Cost;
			Item monney = shop.Monney;
			Item itemToGive = shop.ItemToGive;

			if (InventoryManager.Instance.Count(monney) >= cost)
			{
				InventoryManager.Instance.RemoveItem(monney, cost, false);
				InventoryManager.Instance.AddItem(itemToGive);
			}
		}
	}
}