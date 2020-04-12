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

			Transform gm = null;
			try
			{
				gm = GetComponentInParent<Level>().transform;
			}
			catch (System.Exception)
			{
				Debug.LogError("There is no Level componnent on the level");
			}

			toUnparent.SetParent(gm, true);

			Destroy(gameObject);
		}
	}
}