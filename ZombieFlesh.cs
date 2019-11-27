using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class ZombieFlesh : I_Items
    {
        private float weight;
        public float Weight { get; }

        private readonly string name = "Zombie flesh";
        public string Name { get; }

        private string description;
        public string Description { get; }

        private bool keyItem;
        public bool KeyItem { get; }

        private int uses;
        public int Uses { get; }

        private int value;
        public int Value { get; }

        public ZombieFlesh()
        {
            weight = 0.5f;
            description = "Nasty. Smells. Makes a nastier posion if mixed correctly";
            keyItem = false;
            uses = 1;
            value = 50;
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
