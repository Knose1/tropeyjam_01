///-----------------------------------------------------------------
/// Author : #DEVELOPER_NAME#
/// Date : #DATE#
///-----------------------------------------------------------------

using Com.Github.Knose1.InfinitePocket.Game.Pockets;
using UnityEngine.EventSystems;

namespace Com.Github.Knose1.InfinitePocket.UI.Element
{
	public class ParentItemUIElement : ButtonInventoryElement
	{
		public override void Click(PointerEventData eventData)
		{
			PocketManager.Instance.LoadParentPocket();
		}
	}
}