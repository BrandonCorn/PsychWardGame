using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class FirstAidKit : I_Items
    {
        //This is a healing item, heals half the players health

        private float weight;
        public float Weight { get; }

        private readonly string name = "First aid kit";
        public string Name { get; }

        private string description;
        public string Description { get; }

        private bool keyItem;
        public bool KeyItem { get; }

        private int uses;
        public int Uses { get; }

        private int value;
        public int Value { get; }

        public FirstAidKit()
        {
            weight = 1;
            description = "Heals you, if you know what you're doing";
            keyItem = false;
            uses = 1;
            value = 350;
        }

        public void useItem()
        {
            throw new NotImplementedException();
        }

        public void useItem(Player player, FirstAidKit AidKit)
        {
            //p.heal() or p.Health = p.MaxHealth
            //Do we want to have the useItem methods to perform the item stuff?
            //i.e. the weapons "useItem" will deal damage to enemies and such?
            //or will that be in a separate class?
            //Is the player class gonna have all the player qualities or who's doing that
            AidKit.uses--;
        }

        override
        public string ToString()
        {
            return name + "\n" + description + "\nHealth healed: Half\n" + "\nWeight: " + weight;
        }
    }
}
