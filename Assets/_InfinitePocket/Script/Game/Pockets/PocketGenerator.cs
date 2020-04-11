using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Com.Github.Knose1.InfinitePocket.Game.Pockets
{
	[CreateAssetMenu(fileName=nameof(PocketGenerator), menuName = "InfinitePocket/"+nameof(PocketGenerator))]
	public class PocketGenerator : ScriptableObject
	{
		public List<GameObject> blockPaterns = new List<GameObject>();

		public GameObject Generate()
		{
			return null;
		}
	}
}
