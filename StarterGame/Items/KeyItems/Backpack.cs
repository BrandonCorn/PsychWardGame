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

        private int purchasePrice; 
        public int PurchasePrice { get { return purchasePrice; } set { purchasePrice = value; } }
        private int sellPrice;
        public int SellPrice { get { return sellPrice; } set { sellPrice = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }

        private HashSet<ItemType> itemTypes;
        private ItemType[] types = { ItemType.KeyItem };
        public HashSet<ItemType> ItemTypes { get { return itemTypes; } }

        private int capacity;
        public int Capacity { get { return capacity; } }

        private Dictionary<string, LinkedList<I_Item>> inventory;
        public Dictionary<string, LinkedList<I_Item>> Inventory { get { return inventory; } }

        private Dictionary<string, List<I_Item>> inventory2;
        public Dictionary<string, List<I_Item>> Inventory2 { get { return inventory2; } }


        public Backpack()
        {
            weight = 0; //Weight should be 0
            uses = 1; //Doesn't matter
            purchasePrice = 999999999;
            sellPrice = 999999999;
            capacity = 30;
            description = "Pretty useful for holding items. \n\tCapacity: " + Capacity + "lbs";
            itemTypes = new HashSet<ItemType>(types);
            inventory = new Dictionary<string, LinkedList<I_Item>>();
            inventory2 = new Dictionary<string, List<I_Item>>(); 
        }
        /*public void giveItem(I_Item item)
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
                Inventory[item.Name].AddLast(item);
            }
            
        }*/

        public void giveItem(I_Item item)
        {
            List<I_Item> check = null;
            Inventory2.TryGetValue(item.Name, out check); 
            if(check == null)
            {
                Inventory2[item.Name] = new List<I_Item>();
                Inventory2[item.Name].Add(item); 
            }
            else
            {
                Inventory2[item.Name].Add(item); 
            }
        }

        public I_Item takeItem(string item)
        {
            LinkedList<I_Item> check = null;
            Inventory.TryGetValue(item, out check);
            if (check != null && check.Count != 0)
            {
                I_Item temp = check.First.Value;
                Inventory[item].Remove(temp);
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

        public I_Item takeItem(string item, int position)
        {
            List<I_Item> check = null;
            Inventory2.TryGetValue(item, out check); 
            if(check != null && check.Count != 0)
            {
                I_Item temp = check[position-1];
                Inventory2[item].RemoveAt(position-1);
                if(Inventory2[item].Count <= 0)
                {
                    Inventory2.Remove(item); 
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

        public bool spaceInBag(I_Item item)
        {
            if (this.Weight + item.Weight > capacity)
            {
                Console.WriteLine("You don't have room in your backpack");
                return false;
            }
            return true;  
        }

        public string displayItems()
        {
            string list = "";
            Dictionary<string, List<I_Item>>.ValueCollection values = Inventory2.Values;
            list += "\nWeight in Bag: " + weightInBag() + "lbs\n\t";
            foreach (List<I_Item> item in values)
            {
                list += item.First().Name + ": " + item.Count + "\n\t";
            }
            return list;
        }

        /*public string displayWeapons()
        {
            string list = "";
            Dictionary<string, LinkedList<I_Item>>.ValueCollection values = Inventory.Values;
            list += "Weapons: \n\t"; 
            foreach (LinkedList<I_Item> item in values)
            {
                if (item.First.Value.ItemTypes.Contains(ItemType.Weapon))
                {
                    //list += item.First.Value.Name + "\n"; 
                    list += item.First.Value.ToString(); 
                }
            }
            return list;
        } */


        //This displays every single weapon and it's stats at current time. 
        public string displayWeapons()
        {
            string list = "";
            Dictionary<string, List<I_Item>>.ValueCollection values = Inventory2.Values;
            list += "Weapons: \n\t";
            foreach (List<I_Item> item in values)
            {
                if (item.First().ItemTypes.Contains(ItemType.Weapon))
                {
                    foreach(IWeapon weapon in item)
                    {
                        list += weapon.ToString(); 
                    }
                }
            }
            return list;
        }

        public string displayWeapons(string name)
        {
            string list = ""; 
            List<I_Item> values = Inventory2[name];
            list += "Weapons: \n"; 
            foreach(IWeapon weapon in values)
            {
                list += weapon.ToString(); 
            }
            return list; 
        }

        public bool itemInBag(string item)
        {
            List<I_Item> check = null;
            Inventory2.TryGetValue(item, out check);
            return check != null; 
        }

        public I_Item checkItem(string item)
        {
            return Inventory2[item].First<I_Item>(); 
        }

        public void useItem(Player player)
        {
            Console.WriteLine("Can't really do all that.");
        }
    }
}
