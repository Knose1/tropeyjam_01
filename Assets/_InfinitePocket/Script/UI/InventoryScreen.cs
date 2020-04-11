///-----------------------------------------------------------------
/// Author : #DEVELOPER_NAME#
/// Date : #DATE#
///-----------------------------------------------------------------

using Com.Github.Knose1.InfinitePocket.Inventory;
using Com.Github.Knose1.InfinitePocket.UI.Element;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Github.Knose1.InfinitePocket.UI {
	public class InventoryScreen : MonoBehaviour {

		private void OnEnable()
		{
			List<InventoryGridLine> lines = new List<InventoryGridLine>(GetComponentsInChildren<InventoryGridLine>(true));

			InventoryManager.Instance;
		}
	}
}