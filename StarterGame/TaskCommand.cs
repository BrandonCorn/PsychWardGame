using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class TaskCommand : Command
    {
        public TaskCommand()
        {
            this.name = "task";
            this.CommandType = CommandType.BasicCommand; 
        }

        public override bool execute(Player player)
        {
            if (player.CurrentTask != null)
            {
                player.outputMessage(player.CurrentTask.Description + "\nCompletetion Status: " +
                player.CurrentTask.Complete);
            }
            return false;
        }
    }
}
