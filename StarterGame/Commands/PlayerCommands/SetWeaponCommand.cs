﻿using System;
using System.Collections.Generic;
using System.Text;

//THIS COMMAND IS FOR SETTING THE WEAPON OF YOUR PLAYER
namespace StarterGame
{
    public class SetWeaponCommand : Command
    {
        public SetWeaponCommand()
        {
            this.name = "set";
        }

        /**
        * Command that tells the player to call method setting the weapon of choice.  
        * @params: (Player) current player of the game.  
        * @return: (bool) true/false value whether game is over or not. 
        **/
        public override bool execute(Player player)
        {
            string weaponName = ""; 
            if (this.Words.Count <= 0)
            {
                player.outputMessage("\nSet what weapon?");
                player.outputMessage(player.Backpack.displayWeapons());
                return false;
            }
            else
            {
                while (this.Words.Count > 0)
                {
                    weaponName += this.Words.Dequeue() + " ";
                }
                weaponName = weaponName.TrimEnd();
                if (player.Weapon == null)
                {
                    player.setWeapon((IWeapon)player.takeFromBackpack(weaponName));
                    player.outputMessage("\nYour new weapon has been set!\n");
                }
                else if(player.Backpack.itemInBag(weaponName))
                {
                    IWeapon takenWeapon = player.takeWeapon();
                    player.Backpack.giveItem(takenWeapon);
                    player.setWeapon((IWeapon)player.takeFromBackpack(weaponName));
                    player.outputMessage("\nYour new weapon has been set!"); 
                }
                else
                {
                    player.outputMessage("You don't have a " + weaponName); 
                }
            }
            player.outputMessage(player.Backpack.displayItems());
            return false; 
        }
    }
}
