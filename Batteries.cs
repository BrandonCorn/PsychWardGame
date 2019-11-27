using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class Batteries : I_Items
    {
        private float weight;
        public float Weight { get; }

        private readonly string name = "Batteries";
        public string Name { get; }

        private string description;
        public string Description { get; }

        private bool keyItem;
        public bool KeyItem { get; }

        private int uses;
        public int Uses { get; }

        private int value;
        public int Value { get; }

        public Batteries()
        {
            weight = 0.106f; //The weight of 2 AA batteries
            description = "A pair of batteries";
            keyItem = false;
            uses = 1;
            value = 200; //To be updated in accordance with $ system
        }

        public void useItem(Flashlight o, Batteries b)
        {
            if (o.BatteryHealth == 0)
            {
                o.BatteryHealth = 10;
                b.uses--;
            }
            else
            {
                Console.WriteLine("Flashlight already charged");
            }
        }

        public void useItem(){ throw new NotImplementedException(); }

        override
        public string ToString()
        {
            return name + "\n" + description + "\nUses per charge: 10\n" + "\nWeight: " + weight;
        }
    }
}
