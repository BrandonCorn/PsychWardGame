using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class Rope : I_Items
    {
        private float weight;
        public float Weight { get; }

        private readonly string name = "Rope";
        public string Name { get; }

        private string description;
        public string Description { get; }

        private bool keyItem;
        public bool KeyItem { get; }

        private int uses;
        public int Uses { get; }

        private int value;
        public int Value { get; }

        public Rope()
        {
            weight = 4;
            description = "Does what a rope does, because it's a rope.";
            keyItem = false;
            uses = 1; //One time use
            value = 400;
        }

        public void useItem() { throw new NotImplementedException(); }

        public void useItem(Rope r)
        {
            //Should provide a one way link
            r.uses--;
        }

        override
        public string ToString()
        {
            return name + "\n" + description + "\nUses" + uses + "\nWeight: " + weight;
        }
    }
}
