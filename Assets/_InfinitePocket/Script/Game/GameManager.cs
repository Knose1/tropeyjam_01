using Com.Github.Knose1.InfinitePocket.Game.Object;
using System;
using UnityEngine;

namespace Com.Github.Knose1.InfinitePocket.Game
{
	[AddComponentMenu("_InfinitePocket/Game/" + nameof(GameManager))]
	public class GameManager : MonoBehaviour {

		public event Action OnLevelSet;

		private static GameManager _instance;
		public static GameManager Instance
		{
			get
			{
				GameManager lInstance = _instance ? _instance : (_instance = FindObjectOfType<GameManager>());

				Debug.Assert(lInstance, "There is no instance of " + nameof(GameManager));

				return lInstance;
			}
			set
			{
				if (!_instance) _instance = value;
				else
				{
					Debug.LogWarning("Trying to create an instance of " + nameof(GameManager));
				}
			}
		}

		[SerializeField] private float minYPlayerDeadzone = -1000;
		[SerializeField] private Player player = null;
		[SerializeField] private Level currentLevel = null;

		private void Update () {
			if (!player)
			{
				Debug.LogError(nameof(player) + " is not assigned");
				return;
			}
			
			if (player.transform.position.y < minYPlayerDeadzone)
			{
				SetPlayerToStartPosition();
			}	
		}

		private void SetPlayerToStartPosition()
		{
			if (!player)
			{
				Debug.LogError(nameof(player) + " is not assigned");
				return;
			}

			player.GetComponent<Rigidbody>().velocity = Vector3.zero;
			player.transform.position = currentLevel.StartPosition;
		}

		public void SetLevel(Level level)
		{
			if (currentLevel) currentLevel.gameObject.SetActive(false);
			
			currentLevel = level;
			currentLevel.gameObject.SetActive(true);

			SetPlayerToStartPosition();
			OnLevelSet?.Invoke();
		}
	}
}