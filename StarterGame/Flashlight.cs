using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class Flashlight : I_Item
    {
        private float weight;
        public float Weight { get; }

        private readonly string name = "Flashlight";
        public string Name { get { return name; } }

        private readonly string description = "Lets you see in the dark";
        public string Description { get { return description; } }

        private int value;
        public int Value { get { return value; } set { this.value = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }

        private Dictionary<string, ItemType> itemTypes;
        public Dictionary<string, ItemType> ItemTypes { get { return itemTypes; } }

        private int batteryHealth;
        public int BatteryHealth { get; set; }

        public Flashlight()
        {
            weight = 0; //0 for key item
            uses = 1; //Doesn't matter
            value = 0;
            batteryHealth = 0;
            itemTypes = new Dictionary<string, ItemType>();
            itemTypes.Add(name, ItemType.BasicItem);
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
