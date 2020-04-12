///-----------------------------------------------------------------
/// Author : #DEVELOPER_NAME#
/// Date : #DATE#
///-----------------------------------------------------------------

using UnityEngine;

namespace Com.Github.Knose1.InfinitePocket.Game
{
	[AddComponentMenu("_InfinitePocket/Game/" + nameof(Level))]
	public class Level : MonoBehaviour {
		[SerializeField] private Transform playerStart = null;

		public Vector3 StartPosition => playerStart.position;
	}
}