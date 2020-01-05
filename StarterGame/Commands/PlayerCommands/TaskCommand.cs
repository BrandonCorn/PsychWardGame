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
        }

        /**
        * Command that tells the player to display what their current task is and state of that task.  
        * @params: (Player) current player of the game.  
        * @return: (bool) true/false value whether game is over or not. 
        **/
        public override bool execute(Player player)
        {
            if (player.CurrentTask != null)
            {
                Console.WriteLine("\n****************************************************");
                player.outputMessage("\n" + player.CurrentTask.Description + "\nCompletetion Status: " +
                player.CurrentTask.TaskState);
                Console.WriteLine("****************************************************\n");
            }
            return false;
        }
    }
}
