using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public interface IWeapon
    {
        int Attack { get; }
        int getStrength(Player player);
    }
}
