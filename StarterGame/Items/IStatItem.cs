using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public interface IStatItem
    {
        //Attack increase of the stat boost item
        int Attack {get;}

        //Speed increase of the stat boost item.
        int Speed { get; }

        //Block increase of the stat boost item. 
        int Block { get; }

        //Number of uses of the stat boost item. 
        int Uses { get; set; }
    }
}
