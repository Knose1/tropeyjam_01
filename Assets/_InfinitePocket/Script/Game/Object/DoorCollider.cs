///-----------------------------------------------------------------
/// Author : #DEVELOPER_NAME#
/// Date : #DATE#
///-----------------------------------------------------------------

using UnityEngine;

namespace Com.Github.Knose1.InfinitePocket.Game.Object
{
	[AddComponentMenu("_InfinitePocket/Game/Object/" + nameof(DoorCollider))]
	public class DoorCollider : MonoBehaviour {

		[SerializeField] Rigidbody rb = null;
		[SerializeField] Transform toUnparent = null;

		private void OnTriggerEnter(Collider other)
		{
			rb.isKinematic = false;
			toUnparent.SetParent(null, true);
			Destroy(gameObject);
		}
	}
}