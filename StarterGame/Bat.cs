using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class Bat : I_Item, IWeapon
    {
        private readonly string name = "Knife";
        public string Name { get { return name; } }
        private Dictionary<string, ItemType> itemTypes;
        public Dictionary<string, ItemType> ItemTypes { get { return itemTypes; } }
        private float weight;
        public float Weight { get { return weight; } set { weight = value; } }

        private readonly string description = "A real slap in the face to whoever you swing on";
        public string Description { get { return description + "\nAttack: " + Attack; } }

        private int value;
        public int Value { get { return value; } set { this.value = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }
        private int attack;
        public int Attack { get { return attack; } set { attack = value; } }

        public Bat()
        {
            attack = 10;
            weight = 1.8f;
            uses = 50; //Will change based on damage system
            value = 500;
            itemTypes = new Dictionary<string, ItemType>();
            itemTypes.Add(name, ItemType.BattleItem);
        }

        /*public Bat(Player player)
        {
            attack = 10 + getStrength(player);
            weight = 1.8f;
            name = "Bat";
            description = "A real slap in the face to whoever you swing on";
            uses = 50; //Will change based on damage system
            //value = 500 * player.level;
        }*/

        public int getStrength(Player player)
        {
            return player.Attack + Attack;
        }

        public void useItem()
        {
            //No need for this the player will use the weapon 
        }

        override
        public string ToString()
        {
            return name + "\n" + description + "\nAttack: " + attack + "\nWeight: " + weight;
        }

    }
}
