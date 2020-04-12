using Com.Github.Knose1.InfinitePocket.Game;
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
		public override bool IsTheSameOf(Item item) => base.IsTheSameOf(item) && item is ItemMap && pocketId == (item as ItemMap).pocketId;

		public const int GENERATE_NEW = -1;
		public int pocketId = GENERATE_NEW;

		[SerializeField, TextArea()] protected string _descriptionIfGenerated;
		public override string Description => CanStack ? base.Description : _descriptionIfGenerated;

		public override ItemId Id => ItemId.Map;
		public override bool CanStack => pocketId == GENERATE_NEW;
	}
}
