using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    class Machete: IWeapon, I_Item
    {
        private readonly String name = "Machete";
        public String Name { get { return name; } }
        private Dictionary<string, ItemType> itemTypes;
        public Dictionary<string, ItemType> ItemTypes { get { return itemTypes; } }
        private float weight;
        public float Weight { get { return weight; } set { weight = value; } }

        private readonly string description = "A rusty machete to slice up foes!";
        public string Description { get { return description + "\nAttack: " + Attack; } }

        private int value;
        public int Value { get { return value; } set { this.value = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }
        private int attack; 
        public int Attack { get { return attack; } set { attack = value; } }

        public bool KeyItem => throw new NotImplementedException();

        public Machete()
        {
            Weight = 2.5f;
            Value = 600;
            itemTypes = new Dictionary<string, ItemType>();
            itemTypes.Add(name, ItemType.WeaponItem);
            Uses = 10;
            Attack = 12;
        }
        public int getStrength(Player player)
        {
            return player.Attack + Attack;
        }

        public void useItem()
        {
            //No need for this. The player uses the weapon. 
        }
    }
}
