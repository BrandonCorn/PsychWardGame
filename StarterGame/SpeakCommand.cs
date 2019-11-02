using System;

namespace StarterGame
{
    public class SpeakCommand : Command
    {
        public SpeakCommand()
        {
            this.name = "speak";
        }

        public override bool execute(Player player)
        {
            if (this.hasSecondWord())
            {
                player.speak(this.secondWord);
            }
            else
            {
                player.outputMessage("\nSpeak What");
            }
            return false;
        }
    }
}
