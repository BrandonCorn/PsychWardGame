﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    public class Knife : I_Item, IWeapon
    {
        private readonly String name = "Knife";
        public String Name { get { return name; } }
        private float weight;
        public float Weight { get { return weight; } set { weight = value; } }

        private readonly string description = "A knife perfect for carving out zombie eyes!";
        public string Description { get { return description + "\nAttack: " + Attack; } }
        private Boolean keyItem;
        public Boolean KeyItem { get { return keyItem; } }
        private int value;
        public int Value { get { return value; } set { this.value = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }
        private int attack; 
        public int Attack { get { return attack; } set { attack = value; } }
        


        public Knife()
        {
            Weight = 5;
            Value = 75; 
            keyItem = false;
            Uses = 10;
            Attack = 1;
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
