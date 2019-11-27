using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StarterGame
{
    class Backpack : I_Items
    {

        private float weight;

        public float Weight { get; }

        private readonly string name = "Backpack";

        public string Name { get; }

        private bool keyItem;
        public string Description { get; }

        public bool KeyItem { get; }

        private int uses;
        public int Uses { get; }

        private int value;
        public int Value { get; }

        private int capacity;
        public int Capacity { get; }

        private Dictionary<String, Object> inventory;
        public Dictionary<String, Object> Inventory { get; }
        public void AddItem(Dictionary<String, Object> inventory, String s, I_Items item)
        {
            if (inventory.Count >= 30)
            {
                Console.WriteLine("Backpack is full.");
            }
            else
            {
                inventory.Add(s, item);
            }
        }

        public void RemoveItem(Dictionary<String, Object> inventory, String s)
        {
            inventory.Remove(s);
        }

        public void ItemsinBackpack (Dictionary<String, Object> inventory)
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("Bag is empty");
            } else{
                Console.WriteLine("Total number of items: " + inventory.Count + "\n");
                inventory.ToList().ForEach(x => Console.WriteLine(x.Key));
            }
        }
        public Backpack()
        {
            weight = 0; //Weight should be 0
            keyItem = true;
            Description = "Pretty useful for holding things, but can only hold" + capacity + "items.";
            uses = 1; //Doesn't matter
            value = 0; //Unsellable anyways
            capacity = 30;
            Dictionary<String, Object> inventory;

        }

        public void useItem()
        {
            Console.WriteLine("Can't really do all that.");
        }
    }
}
