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
            IWeapon repairItem = (IWeapon)player.takeFromBackpack(item);
            if (repairItem != null)
            {
                if (player.hasEnoughCoins(repairItem.RepairCost))
                {
                    player.spendCoins(repairItem.RepairCost);
                    NotificationCenter.Instance.postNotification(new Notification("RepairWeapon", player));  
                }
            }
            return false; 
        }
    }
}
