using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class Axe : I_Items, IWeapon
    {
        private int attack;
        public int Attack { get; }

        private float weight;
        public float Weight { get; }

        private readonly string name = "Axe";
        public string Name { get; }

        private string description;
        public string Description { get; }

        private bool keyItem;
        public bool KeyItem { get; }

        private int uses;
        public int Uses { get; }

        private int value;
        public int Value { get; }

        public Axe()
        {
            attack = 15;
            weight = 1.25f;
            name = "Axe";
            description = "It hacks and wacks to destroy your enemies";
            keyItem = false;
            uses = 50;
            value = 850;
        }

        public Axe(Player player)
        {
            attack = 15 + getStrength(player);
            weight = 1.25f;
            description = "It hacks and wacks to destroy your enemies";
            keyItem = false;
            uses = 50;
            //value = 850 * player.level;
        }

        public int getStrength(Player player)
        {
            //To be edited
            return attack;
        }

        public void useItem()
        {
            throw new NotImplementedException();
        }

        public void useItem(Player player, Axe axe)
        {

        }

        override
        public string ToString()
        {
            return name + "\n" + description + "\nAttack: " + attack + "\nWeight: " + weight;
        }

    }
}
