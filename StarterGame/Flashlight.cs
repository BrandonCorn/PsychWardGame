﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class Flashlight : I_Item
    {
        //Will be used in the future for tasks. 
        private float weight;
        public float Weight { get { return weight; } }

        private readonly string name = "flashlight";
        public string Name { get { return name; } }

        private readonly string description = "Lets you see in the dark";
        public string Description { get { return description; } }

        private int purchasePrice;
        public int PurchasePrice { get { return purchasePrice; } set { purchasePrice = value; } }
        private int sellPrice;
        public int SellPrice { get { return sellPrice; } set { sellPrice = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }

        private HashSet<ItemType> itemTypes;
        private ItemType[] types = { ItemType.KeyItem };
        public HashSet<ItemType> ItemTypes { get { return itemTypes; } }

        private int batteryHealth;
        public int BatteryHealth { get { return batteryHealth; } set { batteryHealth = value; } }

        public Flashlight()
        {
            weight = 0; //0 for key item
            uses = 1; //Doesn't matter
            purchasePrice = 99999;
            sellPrice = 99999;
            batteryHealth = 0;
            itemTypes = new HashSet<ItemType>(types);
        }
        

        public void useItem(Flashlight o)
        {
            if (o.batteryHealth == 0)
            {
                Console.WriteLine("Battery dead.");
            }
            else
            {
                o.batteryHealth--;
            }
        }

        public void useItem(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
