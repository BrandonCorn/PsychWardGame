using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class RatTail : I_Item
    {
        private float weight;
        public float Weight { get; }

        private readonly string name = "rat tail";
        public string Name { get { return name; } }

        private readonly string description = "Can be mixed with other ingredients to make something useful";
        public string Description { get { return description; } }

        private int value;
        public int Value { get { return value; } set { this.value = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }

        private Dictionary<string, ItemType> itemTypes;
        public Dictionary<string, ItemType> ItemTypes { get { return itemTypes; } }

        public RatTail()
        {
            weight = 0.5f;
            uses = 1;
            value = 50; //Change based on monetary system
            itemTypes = new Dictionary<string, ItemType>();
            itemTypes.Add(name, ItemType.BasicItem);
        }

        public void useItem(RatTail rt)
        {
            rt.uses--;
        }

        public void useItem(Player player)
        {
            throw new NotImplementedException();
        }

        override
        public string ToString()
        {
            return name + "\n" + description + "\nUses" + uses + "\nWeight: " + weight;
        }
    }
}
