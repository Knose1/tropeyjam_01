using UnityEngine;

namespace Com.Github.Knose1.InfinitePocket.UI {

	[AddComponentMenu("_InfinitePocket/UI/" + nameof(UIManager))]
	public class UIManager : MonoBehaviour {

		[SerializeField] private KeyCode OpenInventory = KeyCode.I;
		[SerializeField] private InventoryScreen inventoryScreen;

		private void Update()
		{
			if (Input.GetKeyDown(OpenInventory))
			{
				inventoryScreen.gameObject.SetActive(!inventoryScreen.gameObject.activeSelf);
			}
		}
	}
}