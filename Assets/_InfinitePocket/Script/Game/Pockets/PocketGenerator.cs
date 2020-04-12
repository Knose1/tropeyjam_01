using Com.Github.Knose1.Common;
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
		[SerializeField] public int tutorialLevel = 0;
		[SerializeField] public List<Level> levels = new List<Level>();
		
		private List<Level> randomLevels = new List<Level>();
		private Level lastGenerated = null;

		public void Start()
		{
			GenerateRandomLevels();
			randomLevels.Remove(levels[tutorialLevel]);
			randomLevels.Insert(0, levels[tutorialLevel]);
		}

		public void GenerateRandomLevels()
		{
			randomLevels = new List<Level>(levels);
			randomLevels.Shuffle();

			if (!lastGenerated || randomLevels.Count == 1) return;

			randomLevels.Remove(lastGenerated);
			randomLevels.Insert(UnityEngine.Random.Range(1, randomLevels.Count - 1), lastGenerated);
		}

		public Level Generate()
		{
			if (randomLevels.Count == 0)
			{
				GenerateRandomLevels();
			}


			Level lToReturn = randomLevels[0];
			randomLevels.RemoveAt(0);

			lastGenerated = lToReturn;
			lToReturn = Instantiate(lastGenerated);
			lToReturn.gameObject.SetActive(false);

			return lToReturn;
		}

		private void OnValidate()
		{
			if (levels.Count == 0) tutorialLevel = 0;
			else tutorialLevel = Mathf.Clamp(tutorialLevel, 0, levels.Count); 
		}
	}
}
