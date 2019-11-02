using System.Collections;
using System.Collections.Generic;

namespace StarterGame
{
    public class GoCommand : Command
    {

        public GoCommand() : base()
        {
            this.name = "go";
        }

        override
        public bool execute(Player player)
        {
            if (this.hasSecondWord() && this.hasThirdWord() && this.hasFourthWord())
            {
                player.waltTo(this.secondWord + " " + this.ThirdWord + " " + this.FourthWord);
            }
            else if (this.hasSecondWord() && this.hasThirdWord())
            {
                player.waltTo(this.secondWord + " " + this.ThirdWord);
            }
            else if (this.hasSecondWord())
            {
                player.waltTo(this.secondWord);
            }
            else
            {
                player.outputMessage("\nGo Where?");
            }
            return false;
        }
    }
}
