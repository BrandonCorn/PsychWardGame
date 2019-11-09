using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    public class Hammer : I_Item, IWeapon
    {
        private readonly String name = "Hammer";
     
        public String Name { get { return name; } }
        private float weight;
        public float Weight { get { return weight; } set { weight = value; } }

        public readonly string description = "An awesome hammer to bash people's brains in with";
        public String Description { get { return description + "\nAttack: " + Attack; } }
        private Boolean keyItem;
        public Boolean KeyItem { get { return keyItem; } }
        private int value;
        public int Value { get { return value; } set { this.value = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }
        private int attack; 
        public int Attack { get { return attack; } set { attack = value; } }
        public Hammer()
        {
            Weight = 10;
            Value = 100;
            keyItem = false;
            Uses = 10;
            Attack = 3;
        }
        public int getStrength(Player player)
        {
            return player.Attack + Attack;
        }

        public void useItem()
        {
            //work on. player>item>useItem()>COMMAND
        }

    }
}
