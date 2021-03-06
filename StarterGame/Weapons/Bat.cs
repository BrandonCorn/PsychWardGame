﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class Bat : I_Item, IWeapon
    {
        //SEE I_iTEM INTERFACE FOR EXPLAINATION OF ALL PROPERTIES!!
        private readonly string name = "bat";
        public string Name { get { return name; } }
        private HashSet<ItemType> itemTypes;
        private ItemType[] types = { ItemType.BattleItem, ItemType.Weapon };
        public HashSet<ItemType> ItemTypes { get { return itemTypes; } }
        private float weight;
        public float Weight { get { return weight; } set { weight = value; } }

        private readonly string description = "A real slap in the face to whoever you swing on";
        public string Description { get { return description + "\nAttack: " + Attack; } }

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
        private int maxUse = 8;
        public int MaxUse { get { return maxUse; } set { maxUse = value; } }
        public Bat()
        {
            attack = 10;
            weight = 4.8f;
            itemTypes = new HashSet<ItemType>(types);
            uses = maxUse;
            purchasePrice = 500;
            sellPrice = 225;
            repairCost = 150;
    }

        public int getStrength(Player player)
        {
            return player.playerAttack() + Attack;
        }

        public void useItem(Player player)
        {
            player.outputMessage("Cannot use " + Name + " right now.\n");
            player.addToBackpack(this);
        }

        public void useWeaponDescription(Player player)
        {
            player.outputMessage("\nYou swing your bat at the enemies head like a ball on a tee!\n");
        }

        public void useWeapon(Player player)
        {
            Uses--;
            if (Uses <= 0)
            {
                player.Weapon = null;
            }
        }

        override
        public string ToString()
        {
            return name + " {Attack: " + attack + ",Weight: " + weight + "lbs" + ", Uses: " + uses + "}\n";
        }

    }
}
