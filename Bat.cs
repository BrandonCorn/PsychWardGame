using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class Bat : I_Items, IWeapon
    {
        private int attack;
        public int Attack { get; }

        private float weight;
        public float Weight { get; }

        private readonly string name = "Bat";
        public string Name { get; }

        private string description;
        public string Description { get; }

        private bool keyItem;
        public bool KeyItem { get; }

        private int uses;
        public int Uses { get; }

        private int value;
        public int Value { get; }

        public Bat()
        {
            attack = 10;
            weight = 1.8f;
            description = "A real slap in the face to whoever you swing on";
            keyItem = false;
            uses = 50; //Will change based on damage system
            value = 500;
        }

        public Bat(Player player)
        {
            attack = 10 + getStrength(player);
            weight = 1.8f;
            name = "Bat";
            description = "A real slap in the face to whoever you swing on";
            keyItem = false;
            uses = 50; //Will change based on damage system
            //value = 500 * player.level;
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

        override
        public string ToString()
        {
            return name + "\n" + description + "\nAttack: " + attack + "\nWeight: " + weight;
        }

    }
}
