using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    class ZombiePatient :IEnemy
    {
        public int Level { get; }
        private int attack;
        public int Attack { get; }
        private int defense;
        public int Defense { get; }
        private float hitprobability;
        public float HitProbability { get; }
        public String AttackDescription { get; }
    }
}
