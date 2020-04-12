///-----------------------------------------------------------------
/// Author : #DEVELOPER_NAME#
/// Date : #DATE#
///-----------------------------------------------------------------

using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

namespace Com.Github.Knose1.InfinitePocket.UI.Element {
	[ExecuteAlways()]
	public class InventoryGridLine : MonoBehaviour {

		[SerializeField] public float spacing = 50;
		[SerializeField, FormerlySerializedAs("CanContain")] public int canContain = 8;
		[SerializeField] public bool spaceAround = false;
		[SerializeField] private HorizontalLayoutGroup innerLayoutGroup = null;

		private RectTransform rectTransform;

		private void OnEnable()
		{
			rectTransform = (RectTransform)transform;
			innerLayoutGroup = GetComponentInChildren<HorizontalLayoutGroup>();
			UpdateLayout();
		}

		public void UpdateLayout()
		{
			if (innerLayoutGroup.transform.childCount == 0) return;
			Canvas.ForceUpdateCanvases();
			innerLayoutGroup.SetLayoutHorizontal();
		}

		private void Awake()
		{
			rectTransform = (RectTransform)transform;
		}

		private void Update()
		{
			Vector2 size = rectTransform.sizeDelta;
			
			float offset = (spaceAround ? spacing : 0);
			
			size.y = (size.x + (spaceAround ? -spacing : spacing)) / canContain - spacing;
			rectTransform.sizeDelta = size;

			((RectTransform)innerLayoutGroup.transform).offsetMin = new Vector2(offset, 0);
			((RectTransform)innerLayoutGroup.transform).offsetMax = new Vector2(offset, 0);
		}

		public void Clear()
		{
			for (int i = innerLayoutGroup.transform.childCount - 1; i >= 0; i--)
			{
				Destroy(innerLayoutGroup.transform.GetChild(i).gameObject);
			}
		}

		public bool CanAddItem() => canContain > innerLayoutGroup.transform.childCount;

		public void AddItem(Transform item)
		{
			if (!CanAddItem())
			{
				Debug.LogWarning($"[Inventory] {name} can't contain more than ${canContain} items");
			}
			item.SetParent(innerLayoutGroup.transform);
		}


	}
}