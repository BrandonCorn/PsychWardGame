using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public interface IWeapon
    {
        string Name { get; }
        Dictionary<string, ItemType> ItemTypes { get; }
        int Weight { get; }
        string Description { get; }
        int Value { get; }
        int Attack { get; set; }
        int Uses { get; }
        int getStrength(Player player);
    }
}
