using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class SellCommand : Command
    {
        public SellCommand()
        {
            this.name = "sell";
        }

        /**
        * Command that initiates sale of current player's chosen item to the merchant.  
        * @params: (Player) current player of the game.  
        * @return: (bool) true/false value whether game is over or not. 
        **/
        public override bool execute(Player player)
        {
            string itemName = "";
            while (this.Words.Count > 0)
            {
                itemName += Words.Dequeue() + " ";
            }
            itemName = itemName.TrimEnd();

            I_Item item = player.takeFromBackpack(itemName); 
            if (item.ItemTypes.Contains(ItemType.KeyItem))
            {
                player.outputMessage("\nI wouldn't sell that, you may need it later!");
                player.addToBackpack(item);
            }
            else if(item == null)
            {
                player.outputMessage("\nWhat do you want to sell!!!");
            }
            else
            {
                player.receiveCoins(item.SellPrice);
                player.outputMessage("\nYou received " + item.SellPrice + " coins!");
            }

            return false;
        }
    }
}
