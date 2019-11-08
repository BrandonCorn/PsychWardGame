using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    public class Knife : I_Item, IWeapon
    {
        private readonly String name = "Knife";
        public String Name { get { return name; } }
        private float weight;
        public float Weight { get { return weight; } }
        private int numItems;
        public int NumItems { get { return numItems; } }
        private String description;
        public String Description { get { return description; } }
        private Boolean keyItem;
        public Boolean KeyItem { get { return keyItem; } }
        private int value;
        public int Value { get { return value; } }

        private int uses;
        public int Uses { get { return uses; } }

        public void useItem()
        {
            //work on. player>item>useItem()>COMMAND
        }
        public int Attack { get; }
        
        private int strength;
        public int Strength { get; }
        public void getStrength(Player player)
        {
            
        }

    }
}
