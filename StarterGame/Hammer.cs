using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    public class Hammer : IWeapon
    {
        private readonly string name = "hammer";
     
        public string Name { get { return name; } }
        //The itemTypes is a Dictionary of what all an item qualifies as, for instance health items 
        //can be used in and out of battle there fore should be of use in both circumstances. 
        private Dictionary<string, ItemType> itemTypes;
        public Dictionary<string, ItemType> ItemTypes { get { return itemTypes; } }
        private float weight;
        public float Weight { get { return weight; } set { weight = value; } }

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
            Weight = .85f;
            Value = 350;
            itemTypes = new Dictionary<string, ItemType>();
            itemTypes.Add(name, ItemType.BattleItem);
            Uses = 10;
            Attack = 7;
        }
        public int getStrength(Player player)
        {
            return player.Attack + Attack;
        }

        public void useItem(Player player)
        {
            Uses--;
            if (Uses <= 0)
            {
                player.Weapon = null;
            }
        }
    }
}
