///-----------------------------------------------------------------
/// Author : #DEVELOPER_NAME#
/// Date : #DATE#
///-----------------------------------------------------------------

using Com.Github.Knose1.InfinitePocket.Game.Pockets;
using Com.Github.Knose1.InfinitePocket.Inventory;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Com.Github.Knose1.InfinitePocket.UI.Element
{
	public class MapItemUIElement : ButtonInventoryElement
	{
		public override void Click(PointerEventData eventData)
		{
			int pocketId = (stack.Item as ItemMap).pocketId;
			InventoryManager.Instance.RemoveItem(stack.Item);

			PocketManager.Instance.LoadDeeperPocket(pocketId);
		}
	}
}