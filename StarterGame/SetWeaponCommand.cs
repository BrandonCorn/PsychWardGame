using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class SetWeaponCommand : Command
    {
        public SetWeaponCommand()
        {
            this.name = "Set";
        }

        public override bool execute(Player player)
        {
            string weaponName = ""; 
            if (this.Words.Count <= 0)
            {
                player.outputMessage("\nSet what weapon?");
                player.Backpack.displayItems();
                return false;
            }
            else
            {
                while (this.Words.Count > 0)
                {
                    if (this.Words.Count == 1)
                    {
                        weaponName += this.Words.Dequeue();
                    }
                    else
                    {
                        weaponName += this.Words.Dequeue() + " ";
                    }
                }
                if (player.Backpack.Inventory[weaponName].Count > 1)
                {
                    foreach(IWeapon weapon in player.Backpack.Inventory.Values)
                    {
                        //need to display each of the same weapons stats and option for player
                        //to pick a specific one to use. 
                    }
                }
                
               
            }
            
            return false; 
        }
    }
}
