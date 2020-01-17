using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame.Items.StatItems
{
    public class AttackMegaBoost : I_Item, IStatItem
    {
        private float weight; 
        public float Weight { get { return weight; } set { weight = value; } }

        private readonly string name = "AttackMegaBoost"; 
        public string Name { get { return Name; } }

        private readonly string description = "An item that gives a large but temporary boost to attack power."; 
        public string Description { get { return name; } }

        private ItemType[] types = { ItemType.BattleItem }; 
        private HashSet<ItemType> itemtypes; 
        public HashSet<ItemType> ItemTypes { get { return ItemTypes; } set { ItemTypes = value; } }

        private int uses; 
        public int Uses { get { return uses; } set { uses = value; } }

        private int purchasePrice; 
        public int PurchasePrice { get { return purchasePrice; } set { purchasePrice = value; } }

        private int sellPrice; 
        public int SellPrice { get { return sellPrice; } set { sellPrice = value; } }

        private int attack; 
        public int Attack { get { return attack; } }

        private int speed; 
        public int Speed { get { return Speed;  } }

        private int block; 
        public int Block {  get { return Block;  } }

        public AttackMegaBoost()
        {
            weight = 0.4f;
            uses = 1;
            purchasePrice = 250;
            sellPrice = 125;
            itemtypes = new HashSet<ItemType>(types); 
        }

        public void useItem(Player player)
        {
            if (player.PlayerState == PlayerState.InBattle)
            {
                player.TempAttack += Attack;
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
