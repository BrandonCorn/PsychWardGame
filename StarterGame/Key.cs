using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class Key : I_Item
    {
        private float weight;
        public float Weight { get { return weight; } }

        private readonly string name = "Key";
        public string Name { get { return name; } }

        private readonly string description = "Unlocks doors";
        public string Description { get { return description; } }
        private int purchasePrice;
        public int PurchasePrice { get { return purchasePrice; } set { purchasePrice = value; } }
        private int sellPrice;
        public int SellPrice { get { return SellPrice; } set { SellPrice = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }

        private HashSet<ItemType> itemTypes;
        private ItemType[] types = { ItemType.KeyItem }; 
        public HashSet<ItemType> ItemTypes { get { return itemTypes; } }
        public Key()
        {
            weight = 0.5f; //Should have weight. 
            uses = 1;
            purchasePrice = 999999;
            sellPrice = 999999; 
            itemTypes = new HashSet<ItemType>(types);
        }

        public void useItem(Player player)
        {
            throw new NotImplementedException();
        }

        public void useItem(Door d, Key k)
        {
            d.Unlock(k);
        }
    }
}
