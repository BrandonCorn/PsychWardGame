using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public interface IWeapon
    {
        string Name { get; }
        Dictionary<string, ItemType> ItemTypes { get; }
        float Weight { get; set; }
        string Description { get; }
        int Value { get; set; }
        int Attack { get; set; }
        int Uses { get; set; }
        int getStrength(Player player);
    }
}
