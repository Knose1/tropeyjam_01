///-----------------------------------------------------------------
/// Author : #DEVELOPER_NAME#
/// Date : #DATE#
///-----------------------------------------------------------------

using Com.Github.Knose1.InfinitePocket.Inventory;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Com.Github.Knose1.InfinitePocket.UI.Element
{
	public class UIInventoryElement : UIBehaviour, IEventSystemHandler//, IPointerEnterHandler, IPointerExitHandler, IMoveHandler
	{
		[SerializeField] protected Text stackCountText = null;
		[SerializeField] protected RectTransform stackCountObject = null;

		public void OnPointerEnter(PointerEventData eventData) => throw new System.NotImplementedException();
		public void OnPointerExit(PointerEventData eventData) => throw new System.NotImplementedException();
		public void OnMove(AxisEventData eventData) => throw new System.NotImplementedException();
		

		protected InventoryStack stack;

		public void LinkItem(InventoryStack stack)
		{
			this.stack = stack;
			if (stack.Item.CanStack)
			{
				stackCountObject.gameObject.SetActive(true);
				SetCount(stack.count);
			}
			else
			{
				stackCountObject.gameObject.SetActive(false);
			}
		}
		protected void SetCount(int count)
		{
			stackCountText.text = count.ToString();
		}
	}

	public abstract class ButtonInventoryElement : UIInventoryElement, IPointerClickHandler
	{
		public void OnPointerClick(PointerEventData eventData)
		{
			Debug.Log($"[Use] Clicked on {gameObject.name} of type {GetType().Name}");
			Click(eventData);
		}
		public abstract void Click(PointerEventData eventData);
	}
}