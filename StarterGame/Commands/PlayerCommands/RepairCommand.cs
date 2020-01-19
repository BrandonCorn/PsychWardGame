using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame.Commands.PlayerCommands
{
    public class RepairCommand : Command
    {
        //*****Change the backpack Inventory to include items of same kind in Dictionary as opposed to LinkedList

        public RepairCommand()
        {
            this.name = "repair"; 
        }
        public override bool execute(Player player)
        {
            string item = ""; 
            if (this.Words.Count == 0)
            {
                Console.WriteLine("What do you want to repair?");
                return false; 
            }
            while (this.Words.Count > 0)
            {
                item += this.Words.Dequeue(); 
            }
            item.TrimEnd();
            if (player.Backpack.itemInBag(item))
            {
                player.outputMessage("Which one would you like to repair(enter the weapon's number position)");
                player.outputMessage(player.Backpack.displayWeapons(item));
                int position;
                IWeapon repairWeapon;
                try
                {
                    position = Convert.ToInt32(Console.ReadLine());
                    repairWeapon = (IWeapon)player.takeFromBackpack(item, position);
                }
                catch (Exception e)
                {
                    player.outputMessage("\nNot a valid weapon position");
                    return false;
                }
                if (player.hasEnoughCoins(repairWeapon.RepairCost))
                {
                    player.spendCoins(repairWeapon.RepairCost);
                    player.addToBackpack(repairWeapon);
                    NotificationCenter.Instance.postNotification(new Notification("RepairWeapon", repairWeapon));
                    player.outputMessage("Success, your weapon has been repaired!\n" + repairWeapon.ToString());
                }
                else
                {
                    player.outputMessage("You don't have enough money to repair that");
                    player.addToBackpack(repairWeapon);
                }
            }
            else
            {
                player.outputMessage("That weapon is not in your bag!");
            }
            return false; 
        }
    }
}
