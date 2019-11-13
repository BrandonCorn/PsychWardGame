using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class ZombieFlesh : I_Item
    {
        private float weight;
        public float Weight { get; }

        private readonly string name = "Zombie flesh";
        public string Name { get { return name; } }

        private readonly string description = "Nasty. Smells. Makes a nastier posion if mixed correctly";
        public string Description { get { return description; } }

        private int value;
        public int Value { get { return value; } set { this.value = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }

        private Dictionary<string, ItemType> itemTypes;
        public Dictionary<string, ItemType> ItemTypes { get { return itemTypes; } }

        public ZombieFlesh()
        {
            weight = 0.5f;
            uses = 1;
            value = 50;
            itemTypes = new Dictionary<string, ItemType>();
            itemTypes.Add(name, ItemType.BasicItem);
        }

        public void useItem(ZombieFlesh z)
        {
            z.uses--;
        }

        public void useItem()
        {
            throw new NotImplementedException();
        }

        public string ToString()
        {
            return name + "\n" + description + "\nUses" + uses + "\nWeight: " + weight;
        }
    }
}
