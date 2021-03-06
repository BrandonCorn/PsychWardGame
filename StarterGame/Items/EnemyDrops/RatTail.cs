﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class RatTail : I_Item
    {
        private float weight;
        public float Weight { get { return weight; } }

        private readonly string name = "rat tail";
        public string Name { get { return name; } }

        private readonly string description = "Can be mixed with other ingredients to make something useful";
        public string Description { get { return description; } }

        private int purchasePrice;
        public int PurchasePrice { get { return purchasePrice; } set { purchasePrice = value; } }
        private int sellPrice;
        public int SellPrice { get { return sellPrice; } set { sellPrice = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }

        private HashSet<ItemType> itemTypes;
        private ItemType[] types = { ItemType.BasicItem };
        public HashSet<ItemType> ItemTypes { get { return itemTypes; } }

        public RatTail()
        {
            weight = 1.0f;
            uses = 1;
            purchasePrice = 0;
            sellPrice = 30; 
            itemTypes = new HashSet<ItemType>(types);
        }

        public void useItem(RatTail rt)
        {
            rt.uses--;
        }

        public void useItem(Player player)
        {
            player.outputMessage("\n This item is meant to be sold for it's value.");
        }

        override
        public string ToString()
        {
            return name + "\n" + description + "\nUses" + uses + "\nWeight: " + weight;
        }
    }
}
