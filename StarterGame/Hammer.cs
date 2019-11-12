using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    public class Hammer : IWeapon, I_Item
    {
        private readonly string name = "Hammer";
     
        public string Name { get { return name; } }
        private Dictionary<string, ItemType> itemTypes;
        public Dictionary<string, ItemType> ItemTypes { get { return itemTypes; } }
        private int weight;
        public int Weight { get { return weight; } set { weight = value; } }

        public readonly string description = "An awesome hammer to bash people's brains in with";
        public String Description { get { return description + "\nAttack: " + Attack; } }

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
            itemTypes = new Dictionary<string, ItemType>();
            itemTypes.Add(name, ItemType.WeaponItem);
            Uses = 10;
            Attack = 3;
        }
        public int getStrength(Player player)
        {
            return player.Attack + Attack;
        }

        public void useItem()
        {
            //theres no need for this. The player uses the weapon. 
        }
    }
}
