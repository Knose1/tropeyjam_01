using UnityEngine;
using UnityEngine.UI;

namespace Com.Github.Knose1.InfinitePocket.UI.Element
{
	[ExecuteAlways()]
	public class InfoBox : MonoBehaviour
	{
		public const string NAME_PREFIX = "Name :";
		public const string POCKET_ID_PREFIX = "PocketId :";

		[SerializeField] private Text nameField;
		[SerializeField] private Text descriptionField;

		[SerializeField] private RectTransform fieldsParent;

		private RectTransform rectTransform;

		private void Start()
		{
			rectTransform = (RectTransform)transform;
		}
		private void Update()
		{
			Vector2 size = rectTransform.sizeDelta;
			
			size.y = 0;
			for (int i = fieldsParent.childCount - 1; i >= 0; i--)
			{
				size.y += ((RectTransform)fieldsParent.GetChild(i)).sizeDelta.y;
			}

			rectTransform.sizeDelta = size;
		}
	}
}