using UnityEngine;
using System.Collections;
using Com.Github.Knose1.InfinitePocket.Inventory;

namespace Com.Github.Knose1.InfinitePocket.Game.Object
{
	public abstract class Collectible<ItemType> : MonoBehaviour where ItemType : Item
	{
		[SerializeField] public ItemType item;
		[SerializeField] public string playerTag = "player";

		protected void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag(playerTag))
			{
				OnCollisionWithPlayer();

				item.Collect();
				Destroy(gameObject);
			}

		}

		protected abstract void OnCollisionWithPlayer();
	}
}
