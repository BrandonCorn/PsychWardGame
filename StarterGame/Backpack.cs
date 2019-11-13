using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StarterGame
{
    class Backpack : I_Item
    {

        private float weight;

        public float Weight { get; }

        private readonly string name = "Backpack";

        public string Name { get { return name; } }

        private readonly string description; 
        public string Description { get { return description; }}

        private int value;
        public int Value { get { return value; } set { this.value = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }

        private Dictionary<string, ItemType> itemTypes;
        public Dictionary<string, ItemType> ItemTypes { get { return itemTypes; } }

        private int capacity;
        public int Capacity { get { return capacity; } }

        private Dictionary<String, Queue<I_Item>> inventory;
        public Dictionary<String, Queue<I_Item>> Inventory { get { return inventory; } }

        public Backpack()
        {
            weight = 0; //Weight should be 0
            uses = 1; //Doesn't matter
            value = 0; //Unsellable anyways
            description = "Pretty useful for holding items. \n\tCapacity: + " + capacity + "lbs";
            capacity = 30;
            itemTypes = new Dictionary<string, ItemType>();
            itemTypes.Add(name, ItemType.BattleItem);

        }
        public void AddItem(I_Item item)
        {
            if (inventory.Count >= 30)
            {
                Console.WriteLine("Backpack is full.");
            }
            else
            {
                inventory[item.Name].Enqueue(item);
            }
        }

        public void RemoveItem(String itemName)
        {
            inventory[itemName].Dequeue();
        }

        //The actual total number of items is going to be the count of the Queues in each position in the 
        /// Dictionary 
       

        /*public void ItemsinBackpack (Dictionary<String, Object> inventory)
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("Bag is empty");
            } else{
                Console.WriteLine("Total number of items: " + inventory.Count + "\n");
                inventory.ToList().ForEach(x => Console.WriteLine(x.Key));
            }
        }*/


        public void useItem()
        {
            Console.WriteLine("Can't really do all that.");
        }
    }
}
