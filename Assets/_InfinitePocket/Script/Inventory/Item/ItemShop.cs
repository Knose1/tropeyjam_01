using UnityEngine;

namespace Com.Github.Knose1.InfinitePocket.Inventory
{
	[CreateAssetMenu(fileName = nameof(ItemShop), menuName = "InfinitePocket/" + nameof(ItemShop))]
	public class ItemShop : Item
	{
		[SerializeField] private int _cost = 0;
		public int Cost => _cost;

		[SerializeField] private int _quantityToGive = 1;
		public int QuantityToGive => _quantityToGive;

		[SerializeField] public Item _monney;
		public Item Monney => _monney;

		[SerializeField] public Item _itemToGive;
		public Item ItemToGive => _itemToGive;


		public override string Description => string.Format(base.Description, _quantityToGive+" "+_itemToGive.Name, Cost + " " + _monney.Name);

		public override ItemId Id => ItemId.Shop;
		public override bool CanStack => false;
	}
}
