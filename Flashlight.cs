using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class Flashlight : I_Items
    {
        private float weight;
        public float Weight { get; }

        private readonly string name = "Flashlight";
        public string Name { get; }

        private string description;
        public string Description { get; }

        private bool keyItem;
        public bool KeyItem { get; }

        private int uses;
        public int Uses { get; }

        private int value;
        public int Value { get; }

        private int batteryHealth;
        public int BatteryHealth { get; set; }

        public Flashlight()
        {
            weight = 0; //0 for key item
            description = "Lets you see in the dark";
            keyItem = true;
            uses = 1; //Doesn't matter
            value = 0;
            batteryHealth = 0;
        }

        public void useItem(Flashlight o)
        {
            if (o.batteryHealth == 0)
            {
                Console.WriteLine("Battery dead.");
            }
            else
            {
                o.batteryHealth--;
            }
        }

        public void useItem()
        {
            throw new NotImplementedException();
        }
    }
}
