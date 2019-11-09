using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public interface IEnemy
    {
        EnemyType EnemyType {get;}
        int Level { get; }
        int Attack { get; }
        int Health { get; }
        float HitProbability { get; }
        string battleGreeting();
        string AttackDescription();

    }
}
