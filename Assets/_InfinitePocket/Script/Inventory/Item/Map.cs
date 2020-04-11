using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Github.Knose1.InfinitePocket.Inventory
{
	public class Map : Item
	{
		public Map() : base()
		{
			Id = ItemId.Map;
			HasSpecificData = true;
		}
	}
}
