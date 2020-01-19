using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    //Command for the player to purchase goods from the Merchant. 
    public class BuyCommand : Command
    {
        
        public BuyCommand()
        {
            this.name = "buy";
        }

        /**
        * Command that allows player to purchase an item.  
        * @params: (Player) current player of the game.  
        * @return: (bool) true/false value whether game is over or not. 
        **/
        public override bool execute(Player player)
        {
            if (this.Words.Count > 0)
            {
                string itemName = "";
                while(this.Words.Count > 0)
                {
                    itemName += Words.Dequeue() + " ";
                }
                itemName = itemName.TrimEnd();

                Merchant npc = (Merchant)player.currentRoom.getNPC("merchant");
                if (npc != null)
                {
                    I_Item item = null;
                    npc.Inventory.TryGetValue(itemName, out item);

                    if (item != null)
                    {
                        if (player.Backpack.spaceInBag(item) && player.hasEnoughCoins(item.PurchasePrice))
                        {
                            player.spendCoins(item.PurchasePrice);
                            player.Backpack.giveItem(item);
                            NotificationCenter.Instance.postNotification(new Notification("PlayerPurchaseMessage"));
                        }
                    }
                }
            }
            else
            {
                player.outputMessage("\nWhat do you want to buy!!!");
                NotificationCenter.Instance.postNotification(new Notification("ViewInventory", this));
            }
            return false;
        }
    }
}
