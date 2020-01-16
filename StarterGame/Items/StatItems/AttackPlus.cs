using System;
using System.Collections.Generic;
using System.Text;


namespace StarterGame.Items.StatItems
{
    class AttackPlus : I_Item, IStatItem
    {
        private float weight;
        public float Weight { get { return weight; } set { weight = value; } }
        private readonly string name = "Attack++";

        public string Name { get { return name; } }
        private readonly string description = "Item is used to temporarily increase Attack"; 

        public string Description { get { return description; } }

        private HashSet<ItemType> itemTypes;
        private ItemType[] types = { ItemType.BattleItem};
        public HashSet<ItemType> ItemTypes { get { return itemTypes; } }

        private int uses; 
        public int Uses { get { return uses; } set { uses = value; } }

        private int purchasePrice; 
        public int PurchasePrice { get { return purchasePrice; } set { purchasePrice = value; } }
        private int sellPrice; 
        public int SellPrice { get { return sellPrice; } set { sellPrice = value; } }

        private readonly int attack = 2;
        public int Attack { get { return attack; } }
        public int speed; 
        public int Speed { get { return speed; } }
        private int block; 
        public int Block { get { return block; } }

        public AttackPlus()
        {
            weight = 0.4f;
            uses = 1;
            itemTypes = new HashSet<ItemType>(types); 
        }
        public void useItem(Player player)
        {
            if (player.PlayerState == PlayerState.InBattle)
            {
                player.TempAttack += Attack;
                Uses--;
            }
            else { 
                player.outputMessage("Now's not the time to use that!");
                player.Backpack.giveItem(this);
            }
        }
    }
}
