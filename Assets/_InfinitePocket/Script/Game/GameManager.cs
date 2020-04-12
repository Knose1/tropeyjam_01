///-----------------------------------------------------------------
/// Author : #DEVELOPER_NAME#
/// Date : #DATE#
///-----------------------------------------------------------------

using Com.Github.Knose1.InfinitePocket.Game.Object;
using UnityEngine;

namespace Com.Github.Knose1.InfinitePocket.Game
{
	[AddComponentMenu("_InfinitePocket/Game/" + nameof(GameManager))]
	public class GameManager : MonoBehaviour {


		[SerializeField] private float minYPlayerDeadzone = -1000;
		[SerializeField] private Player player = null;
		[SerializeField] private Level currentLevel = null;

		private void Update () {
			if (!player)
			{
				Debug.LogError(nameof(player) + " is not assigned");
			}
			
			if (player.transform.position.y < minYPlayerDeadzone)
			{
				player.GetComponent<Rigidbody>().velocity = Vector3.zero;
				player.transform.position = currentLevel.StartPosition;
			}
			
		}
	}
}