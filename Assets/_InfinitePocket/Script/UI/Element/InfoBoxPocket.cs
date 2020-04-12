using UnityEngine;
using UnityEngine.UI;

namespace Com.Github.Knose1.InfinitePocket.UI.Element
{
	public class InfoBoxPocket : InfoBox
	{
		public const string POCKET_ID_PREFIX = "Pocket Id :";
		[SerializeField] private Text idField;
	}
}