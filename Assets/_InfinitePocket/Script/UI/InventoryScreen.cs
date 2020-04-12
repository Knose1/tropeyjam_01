///-----------------------------------------------------------------
/// Author : #DEVELOPER_NAME#
/// Date : #DATE#
///-----------------------------------------------------------------

using Com.Github.Knose1.InfinitePocket.Inventory;
using Com.Github.Knose1.InfinitePocket.UI.Element;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Github.Knose1.InfinitePocket.UI {
	public class InventoryScreen : MonoBehaviour {

		private void OnEnable()
		{
			InventoryManager.OnInventoryUpdate += InventoryManager_OnInventoryUpdate;
			
			IEnumerator en() {

				yield return new WaitForEndOfFrame();
				UpdateInventory();

			}
			StartCoroutine( en() );
		}

		private void InventoryManager_OnInventoryUpdate() => UpdateInventory();

		private void OnDisable()
		{
			InventoryManager.OnInventoryUpdate -= InventoryManager_OnInventoryUpdate;
		}
		private void OnDestroy()
		{
			InventoryManager.OnInventoryUpdate -= InventoryManager_OnInventoryUpdate;
		}


		private void UpdateInventory()
		{
			List<InventoryGridLine> lines = new List<InventoryGridLine>(GetComponentsInChildren<InventoryGridLine>(true));
			for (int i = lines.Count - 1; i >= 0; i--)
			{
				//Clearing lines
				lines[i].Clear();
			}

			int currentLineId = 0;

			InventoryGridLine currentLine = lines[currentLineId];

			List<InventoryStack> inventory = InventoryManager.Instance.CurrentInventory;
			int length = inventory.Count;

			InventoryStack stack;

			//Iterate on Inventory Stacks
			for (int i = 0; i < length; i++)
			{
				//Go to next line if this one can't add item
				if (!currentLine.CanAddItem())
				{
					//Return if no more line
					if (++currentLineId == lines.Count) break;

					currentLine = lines[currentLineId];
				}

				//Create new Inventory element
				stack = inventory[i];

				UIInventoryElement elm = Instantiate(stack.Item.UiInventoryPrefab);
				elm.LinkItem(stack);

				currentLine.AddItem(elm.transform);
			}

			for (int i = lines.Count - 1; i >= 0; i--)
			{
				//Clearing lines
				lines[i].UpdateLayout();
			}
		}
	}
}