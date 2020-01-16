using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class UseCommand : Command
    {
        public UseCommand()
        {
            this.name = "use";
        }

        /**
        * Command that tells the player to call method using specific item in their posession.  
        * @params: (Player) current player of the game.  
        * @return: (bool) true/false value whether game is over or not. 
        **/
        public override bool execute(Player player)
        {
            //In this method will write how a player will use an item they have in their bag. 
            if (this.Words.Count > 0)
            {
                string item = "";
                while (this.Words.Count > 0)
                {
                    item += this.Words.Dequeue() + " ";
                }
                item = item.TrimEnd();
                I_Item itemToUse = player.Backpack.takeItem(item);
                if (itemToUse == null)
                {
                    player.outputMessage("\nYou don't have a " + item + " to use");

                }
                else
                {
                    itemToUse.useItem(player);

                    //For player who is in battle 
                    IEnemy enemy = player.currentRoom.CurrentEnemy;
                    if (itemToUse.ItemTypes.Contains(ItemType.BattleItem) && enemy != null)
                    {
                        enemy.attackPlayer(player);
                        if (player.playerDefeated())
                        {
                            return true;
                        }
                        player.currentStats();
                        player.getEnemy().currentStats();
                        NotificationCenter.Instance.postNotification(new Notification("PopCommands"));
                    }
                }

                player.outputMessage(player.Backpack.displayItems());
            }
            else
            {
                player.outputMessage("\nUse What\n");
                player.outputMessage(player.Backpack.displayItems());
            }
            return false;
        }
    }
}
