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

        private HashSet<ItemType> itemTypes;
        private ItemType[] types = { ItemType.BattleItem };
        public HashSet<ItemType> ItemTypes { get { return itemTypes; } }
        private float weight;
        public float Weight { get { return weight; } set { weight = value; } }

        public readonly string description = "An awesome hammer to bash people's brains in with";
        public String Description { get { return description + "\nAttack: " + Attack; } }

        private int purchasePrice;
        public int PurchasePrice { get { return purchasePrice; } set { purchasePrice = value; } }
        private int sellPrice;
        public int SellPrice { get { return sellPrice; } set { sellPrice = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }
        private int attack; 
        public int Attack { get { return attack; } set { attack = value; } }

        private int repairCost;
        public int RepairCost { get { return repairCost; } set { repairCost = value; } }
        private int maxUse = 7;
        public int MaxUse { get { return maxUse; } set { maxUse = value; } }
        public Hammer()
        {
            Weight = 9.85f;
            itemTypes = new HashSet<ItemType>(types);
            uses = maxUse;
            Attack = 8;
            purchasePrice = 350;
            sellPrice = 175;
            repairCost = 100;
        }
        public int getStrength(Player player)
        {
            return player.playerAttack() + Attack;
        }

        public void useItem(Player player)
        {
            player.outputMessage("Cannot use " + Name + " right now.\n");
        }

        public void useWeapon(Player player)
        {
            Uses--;
            if (Uses <= 0)
            {
                player.Weapon = null;
            }
        }
        public void useWeaponDescription(Player player)
        {
            player.outputMessage("\nYou thrust the hammmer down on the enemies head attempting to drill them in the ground!\n");
        }

        override
        public string ToString()
        {
            return name + " {Attack: " + attack + ",Weight: " + weight + "lbs" + ", Uses: " + uses + "}\n";
        }
    }
}
