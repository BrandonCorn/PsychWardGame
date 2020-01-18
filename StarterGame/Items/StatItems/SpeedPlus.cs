using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame.Items.StatItems
{
    public class SpeedPlus : I_Item, IStatItem
    {
        private float weight; 
        public float Weight { get { return weight; } set { weight = value; } }

        private readonly string name = "Speed++"; 
        public string Name { get { return name; } }

        private readonly string description = "Item is used to temporarily increase stats"; 
        public string Description { get { return description; } }

        private ItemType[] types = { ItemType.BattleItem };

        private HashSet<ItemType> itemTypes; 
        public HashSet<ItemType> ItemTypes { get { return itemTypes; } }

        private int uses; 
        public int Uses { get { return uses; } set { uses = value; } }

        private int purchasePrice; 
        public int PurchasePrice { get { return purchasePrice; } set { purchasePrice = value; } }

        private int sellPrice; 
        public int SellPrice { get { return sellPrice; } set { sellPrice = value; } }

        private int attack; 
        public int Attack { get { return attack; } }

        private readonly int speed = 2; 
        public int Speed { get { return speed;  } }

        private int block; 
        public int Block { get { return block;  } }

        public SpeedPlus()
        {
            weight = 0.4f;
            uses = 1;
            purchasePrice = 150;
            sellPrice = 75;
            itemTypes = new HashSet<ItemType>(types);
        }
        public void useItem(Player player)
        {
            if (player.PlayerState == PlayerState.InBattle)
            {
                player.TempSpeed += Speed;
                Uses--;
            }
            else
            {
                player.outputMessage("Now's not the time to use that!");
                player.Backpack.giveItem(this);
            }
        }
    }
}
