﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class Axe : I_Item, IWeapon
    {

        private readonly string name = "Axe";
        public string Name { get { return name; }  }

        private float weight;
        public float Weight { get { return weight; } set { weight = value; } }

        private readonly string description = "It hacks and wacks to destroy your enemies";
        public string Description { get { return description + "\nAttack: " + Attack; } }

        private int purchasePrice;
        public int PurchasePrice { get { return purchasePrice; } set { purchasePrice = value; } }
        private int sellPrice; 
        public int SellPrice { get { return sellPrice;  } set { sellPrice = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }

        private HashSet<ItemType> itemTypes;
        private ItemType[] types = { ItemType.BattleItem, ItemType.Weapon };
        public HashSet<ItemType> ItemTypes { get { return itemTypes; } }

        private int attack;
        public int Attack { get { return attack; } set { attack = value; } }

        private int repairCost;
        public int RepairCost { get { return repairCost; } set { repairCost = value; } }

        private int maxUse = 11;
        public int MaxUse { get { return maxUse; } set { maxUse = value; } }
        public Axe()
        {
            attack = 11;
            weight = 7.25f;
            itemTypes = new HashSet<ItemType>(types);
            uses = maxUse;
            purchasePrice = 850;
            sellPrice = 425;
            repairCost = 250;
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

        public void useWeapon(Player player)
        {
            Uses--; 
            if (Uses <= 0)
            {
                player.addToBackpack(player.takeWeapon());
            }
        }

        public void useWeaponDescription(Player player)
        {
            player.outputMessage("\nYou slice the enemy with your axe\n"); 
        }

        override
        public string ToString()
        {
            return name + " {Attack: " + attack + ",Weight: " + weight + "lbs" + ", Uses: " + uses + "}\n";
        }

    }
}
