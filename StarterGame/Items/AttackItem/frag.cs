using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    //Battle Item for player use against enemy. 
    public class frag : I_Item
    {
        private float weight;
        public float Weight { get { return weight; } set { weight = value; } }

        private readonly string name = "frag";
        public string Name { get { return name; } }

        private readonly string description = "Small bombs used to blow up enemies";
        public string Description { get { return description; } }
        private ItemType[] types = { ItemType.BattleItem, ItemType.BasicItem };

        private HashSet<ItemType> itemTypes;
        public HashSet<ItemType> ItemTypes { get { return itemTypes; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }
        private int purchasePrice; 
        public int PurchasePrice { get { return purchasePrice; } set { purchasePrice = value; } }
        private int sellPrice;
        public int SellPrice { get { return sellPrice; } set { sellPrice = value; } }

        private int damage; 
        public int Damage { get { return damage; } }

        public frag()
        {
            weight = 0.4f;
            uses = 1;
            damage = 4;
            itemTypes = new HashSet<ItemType>(types);
            purchasePrice = 150;
            sellPrice = 75; 
        }

        public void useItem(Player player)
        {
            IEnemy enemy = player.currentRoom.CurrentEnemy;
            if (enemy != null)
            {
                player.outputMessage("\nYou threw a frag at the enemy!!");
                enemy.Health -= this.Damage;
                Uses--;
                if (player.defeatedEnemy(player,enemy))
                {
                    //NotificationCenter.Instance.postNotification(new Notification("BattleOver", player));
                }
            }
            else
            {
                player.outputMessage("\nNow is not the time to use that!");
                player.Backpack.giveItem(this);
            }
        }
    }
}
