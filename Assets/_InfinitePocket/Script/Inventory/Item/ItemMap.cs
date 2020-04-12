using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Com.Github.Knose1.InfinitePocket.Inventory
{
	[CreateAssetMenu(fileName = nameof(ItemMap), menuName = "InfinitePocket/" + nameof(ItemMap))]
	public class ItemMap : Item
	{
		public ItemMap() : base()
		{
			Id = ItemId.Map;
			HasSpecificData = true;
		}
	}
}
