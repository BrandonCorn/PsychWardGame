using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class RatTail : I_Items
    {
        private float weight;
        public float Weight { get; }

        private readonly string name = "Rat tail";
        public string Name { get; }

        private string description;
        public string Description { get; }

        private bool keyItem;
        public bool KeyItem { get; }

        private int uses;
        public int Uses { get; }

        private int value;
        public int Value { get; }

        public RatTail()
        {
            weight = 0.5f;
            description = "Can be mixed with other ingredients to make something useful";
            keyItem = false;
            uses = 1;
            value = 50; //Change based on monetary system
        }

        public void useItem(RatTail rt)
        {
            rt.uses--;
        }

        public void useItem()
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
