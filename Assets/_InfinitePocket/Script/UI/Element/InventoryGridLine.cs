///-----------------------------------------------------------------
/// Author : #DEVELOPER_NAME#
/// Date : #DATE#
///-----------------------------------------------------------------

using UnityEngine;

namespace Com.Github.Knose1.InfinitePocket.UI.Element {
	[ExecuteAlways()]
	public class InventoryGridLine : MonoBehaviour {

		[SerializeField] public float spacing = 50;
		[SerializeField] public int CanContain = 8;
		[SerializeField] public bool spaceAround = false;
		[SerializeField] private RectTransform innerLayoutGroup;

		private RectTransform rectTransform;

		private void Awake()
		{
			rectTransform = (RectTransform)transform;
		}

		private void Update()
		{
			Vector2 size = rectTransform.sizeDelta;
			
			float offset = (spaceAround ? spacing : 0);
			
			size.y = (size.x + (spaceAround ? -spacing : spacing)) / CanContain - spacing;
			rectTransform.sizeDelta = size;

			innerLayoutGroup.offsetMin = new Vector2(offset, 0);
			innerLayoutGroup.offsetMax = new Vector2(offset, 0);
		}
	}
}