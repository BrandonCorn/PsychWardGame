using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class Key : I_Items
    {
        private float weight;
        public float Weight { get; }

        private string name;
        public string Name { get; }

        private string description;
        public string Description { get; }

        private bool keyItem;
        public bool KeyItem { get; }

        private int uses;
        public int Uses { get; }

        private int value;
        public int Value { get; }

        public Key()
        {
            weight = 0; //Should they have weight?
            name = "Key";
            description = "Unlocks doors";
            keyItem = true;
            uses = 1;
            value = 0;
        }

        public Key(string name) //This is in case we want to name keys specifically
        {
            weight = 0;
            this.name = name;
            description = "Unlocks doors";
            keyItem = true;
            uses = 1;
            value = 0;
        }

        public void useItem()
        {
            throw new NotImplementedException();
        }

        public void useItem(Door d, Key k)
        {
            d.Unlock(k);
        }
    }
}
