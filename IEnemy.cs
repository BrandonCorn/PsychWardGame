using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public interface IEnemy
    {
        int Level { get; }
        int Attack { get; }
        int Defense { get; }
        float HitProbability { get; }

        string AttackDescription { get; }
    }
}
