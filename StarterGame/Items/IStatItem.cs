using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public interface IStatItem
    {
        int Attack {get;}
        int Speed { get; }
        int Block { get; }
        int Uses { get; set; }
    }
}
