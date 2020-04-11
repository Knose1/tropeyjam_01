///-----------------------------------------------------------------
/// Author : #DEVELOPER_NAME#
/// Date : #DATE#
///-----------------------------------------------------------------

using Com.Github.Knose1.InfinitePocket.Inventory;
using UnityEngine;
using static UnityEngine.ParticleSystem;

namespace Com.Github.Knose1.InfinitePocket.Game.Object {
	public class ManaCollectible : Collectible<ItemMana>
	{
		[SerializeField] ParticleSystem _particleSystem = null;
		protected override void OnCollisionWithPlayer()
		{
			_particleSystem.Pause();
			MainModule main = _particleSystem.main;
			main.loop = false;
			_particleSystem.Play();

			_particleSystem.transform.SetParent(null, true);
		}
	}
}