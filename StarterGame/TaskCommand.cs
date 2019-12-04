﻿using System;
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
