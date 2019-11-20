using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StarterGame
{
    public class Backpack : I_Item
    {

        private float weight;

        public float Weight { get { return weight; } }

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

        private Dictionary<string, LinkedList<I_Item>> inventory;
        public Dictionary<string, LinkedList<I_Item>> Inventory { get { return inventory; } }

        public Backpack()
        {
            weight = 0; //Weight should be 0
            uses = 1; //Doesn't matter
            value = 0; //Unsellable anyways
            capacity = 30;
            description = "Pretty useful for holding items. \n\tCapacity: " + Capacity + "lbs";
            itemTypes = new Dictionary<string, ItemType>();
            itemTypes.Add(name, ItemType.KeyItem);
            inventory = new Dictionary<string, LinkedList<I_Item>>();
        }
        public void giveItem(I_Item item)
        {
            LinkedList<I_Item> check = null;
            Inventory.TryGetValue(item.Name, out check);
            if (check == null)
            {
                Inventory[item.Name] = new LinkedList<I_Item>();
                Inventory[item.Name].AddFirst(item);
            }
            else
            {
                Inventory[item.Name].AddFirst(item);
            }
            
        }

        public I_Item takeItem(string item)
        {
            LinkedList<I_Item> check = null;
            Inventory.TryGetValue(item, out check);
            if (check != null && check.Count != 0)
            {
                I_Item temp = check.First.Value;
                Inventory[item].RemoveFirst();
                if (Inventory[item].Count == 0)
                {
                    Inventory.Remove(item);
                }
                return temp;
            }
            else
            {
                Console.WriteLine("Item does not exist in your backpack!");
                return null;
            }
        }

        public float weightInBag()
        {
            float temp = 0;
            Dictionary<string, LinkedList<I_Item>>.ValueCollection values = inventory.Values;
            foreach(LinkedList<I_Item> items in values)
            {
                foreach(I_Item item in items)
                {
                    temp += item.Weight;
                }
            }
            return temp; 
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

        public string displayItems()
        {
            string list = "";
            Dictionary<string, LinkedList<I_Item>>.ValueCollection values = Inventory.Values;
            list += "\nWeight in Bag: " + weightInBag() + "lbs\n\t";
            foreach (LinkedList<I_Item> item in values)
            {
                list += item.First.Value.Name + ": " + item.Count + "\n\t";
            }
            return list;
        }


        public void useItem(Player player)
        {
            Console.WriteLine("Can't really do all that.");
        }
    }
}
