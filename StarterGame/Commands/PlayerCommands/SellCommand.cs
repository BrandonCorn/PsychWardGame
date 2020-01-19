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

            //I_Item item = player.takeFromBackpack(itemName);
            if (!player.Backpack.itemInBag(itemName))
            {
                player.outputMessage("\nYou don't have that item!");
            }
            else if (player.Backpack.checkItem(itemName).ItemTypes.Contains(ItemType.KeyItem))
            {
                player.outputMessage("\nI wouldn't sell that, you may need it later!");
                //player.addToBackpack(item);
            }

            //Checks whether an item is a weapon or not, for weapons user may want to sell a specific one, for other items
            //it does not matter. 
            else
            {
                if (player.Backpack.checkItem(itemName).ItemTypes.Contains(ItemType.Weapon))
                {
                    player.outputMessage("Which weapon would you like to sell? (Enter weapon's position number to sell, enter 0 to back)\n");
                    player.outputMessage(player.Backpack.displayWeapons(itemName));
                    int position = Console.Read();
                    I_Item item = null; 
                    try
                    {
                        item = player.takeFromBackpack(itemName, position);
                    }
                    catch(Exception e) { 
                        player.outputMessage("\nNot a valid weapon position"); 
                        return false;  
                    }
                    player.receiveCoins(item.SellPrice);
                    player.outputMessage("\nYou received " + item.SellPrice + " coins!");
                }
                else
                {
                    I_Item item = player.takeFromBackpack(itemName); 
                    player.receiveCoins(item.SellPrice);
                    player.outputMessage("\nYou received " + item.SellPrice + " coins!");
                }
            }

            return false;
        }
    }
}
