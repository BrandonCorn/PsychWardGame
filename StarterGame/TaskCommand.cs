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
            this.CommandTypes = new Dictionary<CommandType,string>();
            CommandTypes.Add(CommandType.BasicCommand,"Task Basic Command");
            CommandTypes.Add(CommandType.MerchantCommand, "Task Merchant Command");
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
