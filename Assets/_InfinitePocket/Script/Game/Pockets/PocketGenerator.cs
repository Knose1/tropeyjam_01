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
		
		[SerializeField] public List<Level> levels = new List<Level>();
		private List<Level> seenLevels = new List<Level>();
		private Level lastGenerated = null;

		public GameObject Generate()
		{
			Level lToReturn = null;

			return lastGenerated = lToReturn;
		}
	}
}
