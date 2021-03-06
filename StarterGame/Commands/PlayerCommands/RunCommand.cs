﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class RunCommand : Command
    {
        public RunCommand()
        {
            this.name = "run";
        }

        public string runStatement()
        {
            int choice = new Random().Next(1, 4);
            if (choice == 1) { return "Player chooses to run away like a coward!"; }
            else if (choice == 2) { return "Player escapes a terrible fate!"; }
            else { return "Player has no options left. Peace Oooouuuuttt!"; }
        }

        /**
        * Command that allows the player to run away from the current enemy.  
        * @params: (Player) current player of the game.  
        * @return: (bool) true/false value whether game is over or not. 
        **/
        public override bool execute(Player player)
        {
            if (this.Words.Count > 0)
            {
                player.outputMessage("You should just say \"run\"");
            }
            else
            {
                player.outputMessage("\n" + runStatement());
                NotificationCenter.Instance.postNotification(new Notification("PopCommands", this));
                player.outputMessage("\n" + player.currentRoom.description());
            }
            return false;
        } 
    }
}
