using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class SutureKit : I_Item
    {
        //This is a healing item, it heals the player back to full health


        private float weight;
        public float Weight { get { return weight; } }

        private readonly string name = "suture Kit";
        public string Name { get { return name; } }

        private readonly string description = "Does more than your regular first aid kit";
        public string Description { get { return description; } }

        private int value;
        public int Value { get { return value; } set { this.value = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }

        private Dictionary<string, ItemType> itemTypes;
        public Dictionary<string, ItemType> ItemTypes { get { return itemTypes; } }

        public SutureKit()
        {
            weight = 1.5f;
            uses = 1;
            value = 500;
            itemTypes = new Dictionary<string, ItemType>();
            itemTypes.Add("Battle", ItemType.BattleItem);
            itemTypes.Add("Basic", ItemType.BasicItem);
        }

        public void useItem()
        {
            throw new NotImplementedException();
        }

        public void useItem(Player player)
        {
            //p.heal(); p.Health = p.MaxHealth
            this.uses--;
            if (this.Uses == 0)
            {
                player.Backpack.takeItem(this.Name);
            }
        }

        override
        public string ToString()
        {
            return name + "\n" + description + "\nHealth healed: Full\n" + "\nWeight: " + weight;
        }
    }
}
