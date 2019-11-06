using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    class Machete: I_Item, IWeapon
    {
        private readonly String name = "Machete";
        public String Name { get; }
        private float weight;
        public float Weight { get; }
        private int numItems;
        public int NumItems { get; }
        private String description;
        public String Description { get; }
        private Boolean keyItem;
        public Boolean KeyItem { get; }
        private int value;
        public int Value { get; }

        private int uses;
        public int Uses { get; }

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
