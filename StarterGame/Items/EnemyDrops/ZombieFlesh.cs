﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class ZombieFlesh : I_Item
    {
        private float weight;
        public float Weight { get { return weight; } }

        private readonly string name = "zombie flesh";
        public string Name { get { return name; } }

        private readonly string description = "Nasty. Smells. Makes a nastier posion if mixed correctly";
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

        public ZombieFlesh()
        {
            weight = 0.5f;
            uses = 1;
            purchasePrice = 0;
            sellPrice = 40;
            itemTypes = new HashSet<ItemType>(types);
        }

        public void useItem(ZombieFlesh z)
        {
            z.uses--;
        }

        public void useItem(Player player)
        {
            player.outputMessage("\n This item is meant to be sold for it's value.");
        }

        public override string ToString()
        {
            return name + "\n" + description + "\nUses" + uses + "\nWeight: " + weight;
        }
    }
}
