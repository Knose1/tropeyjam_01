///-----------------------------------------------------------------
/// Author : #DEVELOPER_NAME#
/// Date : #DATE#
///-----------------------------------------------------------------

using Com.Github.Knose1.InfinitePocket.Inventory;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Com.Github.Knose1.InfinitePocket.UI.Element {
	public class UIInventoryElement : UIBehaviour, IEventSystemHandler//, IPointerEnterHandler, IPointerExitHandler, IMoveHandler
	{
		[SerializeField] Text stackCountText = null;

		public void OnPointerEnter(PointerEventData eventData) => throw new System.NotImplementedException();
		public void OnPointerExit(PointerEventData eventData) => throw new System.NotImplementedException();
		public void OnMove(AxisEventData eventData) => throw new System.NotImplementedException();
		

		protected InventoryStack stack;

		public void LinkItem(InventoryStack stack)
		{
			this.stack = stack;
			if (!stack.Item.HasSpecificData) SetCount(stack.count);
		}
		protected void SetCount(int count)
		{
			stackCountText.text = count.ToString();
		}
	}
}