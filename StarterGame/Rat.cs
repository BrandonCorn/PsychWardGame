﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    public class Rat: IEnemy
    {
        //VIEW IENEMY INTERFACE FOR DESCRIPTIONS OF VARIABLES AND PROPERTIES

        private readonly string name = "Rat";
        public override string Name { get { return name;  } }

        private int attack = 3;
        public override int Attack { get { return attack; } set { attack = value; } }
        private int health = 12;
        public override int Health { get { return health; } set { health = value; } }

        private int hitProbability = 2;
        public override int HitProbability { get { return hitProbability; } }

        private int playerExp = 4; 
        public override int PlayerExp { get { return playerExp; } set { playerExp = value; } }
        public Rat()
        {

        }
        public override string battleGreeting()
        {
            return "A rabid Rat wants you dead. It lunges at you in fury!";
        }

        //Description of the Rat attacking the player to display. We can write more these in this method
        //and make it so that random ones display each time. 
        public override string attackDescription()
        {
            return "\nThe Rat slices your face!";
        }

    }
}