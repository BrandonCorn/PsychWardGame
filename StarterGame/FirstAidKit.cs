using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class FirstAidKit : I_Item
    {
        //This is a healing item, heals half the players health

        private float weight;
        public float Weight { get { return weight; } }

        private readonly string name = "first aid kit";
        public string Name { get { return name; } }

        private readonly string description = "Heals you, if you know what you're doing";
        public string Description { get { return description; } }

        private int purchasePrice;
        public int PurchasePrice { get { return purchasePrice; } set { purchasePrice = value; } }
        private int sellPrice;
        public int SellPrice { get { return sellPrice; } set { sellPrice = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }

        private HashSet<ItemType> itemTypes;
        private ItemType[] types = { ItemType.BasicItem, ItemType.HealthItem, ItemType.BattleItem };
        public HashSet<ItemType> ItemTypes { get { return itemTypes; } }

        public FirstAidKit()
        {
            weight = 1;
            uses = 1;
            purchasePrice = 400;
            sellPrice = 200;
            itemTypes = new HashSet<ItemType>(types);

        }

        public void useItem(Player player)
        {
            player.outputMessage("Your health went up by 50");
            player.Health += 50;
            this.Uses--;
        }

        override
        public string ToString()
        {
            return name + "\n" + description + "\nHealth healed: Half\n" + "\nWeight: " + weight;
        }
    }
}
