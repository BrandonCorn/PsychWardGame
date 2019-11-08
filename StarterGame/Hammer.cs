using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    public class Hammer : I_Item, IWeapon
    {
        public readonly String name = "Hammer";
     
        public String Name { get { return name; } }
        private float weight;
        public float Weight { get { return weight; } }

        public readonly string description = "An awesome hammer to bash people's brains in with";
        public String Description { get { return description; } }
        private Boolean keyItem;
        public Boolean KeyItem { get { return keyItem; } }
        private int value;
        public int Value { get { return value; } }

        private int uses;
        public int Uses { get { return uses; } }
        private int attack; 
        public int Attack { get; }
        public Hammer()
        {
            weight = 0;
            keyItem = false;
            uses = 10;
        }
        public void getStrength(Player player)
        {
            
        }

        public void useItem()
        {
            //work on. player>item>useItem()>COMMAND
        }

    }
}
