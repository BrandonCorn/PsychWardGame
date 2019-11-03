using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public interface I_Items
    {
        int Weight { get; }
        string Name { get; }
        string Description { get; }
        bool KeyItem { get; }
        int Uses { get; }
        int Value { get; }
        void useItem(); 
    }
}
