using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class SutureKit : I_Item
    {
        //This is a healing item, it heals the player back to full health


        private float weight;
        public float Weight { get; }

        private readonly string name = "Suture Kit";
        public string Name { get; }

        private string description;
        public string Description { get; }

        private bool keyItem;
        public bool KeyItem { get; }

        private int uses;
        public int Uses { get; }

        private int value;
        public int Value { get; }

        public SutureKit()
        {
            weight = 1.5f;
            description = "Does more than your regular first aid kit";
            keyItem = false;
            uses = 1;
            value = 500;
        }

        public void useItem()
        {
            throw new NotImplementedException();
        }

        public void useItem(Player player)
        {
            //p.heal(); p.Health = p.MaxHealth
            uses--;
        }

        override
        public string ToString()
        {
            return name + "\n" + description + "\nHealth healed: Full\n" + "\nWeight: " + weight;
        }
    }
}
