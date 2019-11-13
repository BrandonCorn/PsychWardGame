using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class LockPick : I_Item
    {
        private float weight;
        public float Weight { get; }

        private readonly string name = "Lockpick";
        public string Name { get; }

        private string description;
        public string Description { get; }

        private bool keyItem;
        public bool KeyItem { get; }

        private int uses;
        public int Uses { get; }

        private int value;
        public int Value { get; }

        public LockPick()
        {
            weight = 0.1f;
            description = "Picks locks, but know some doors can't be picked";
            keyItem = false;
            uses = 1;
            value = 100;
        }

        public void useItem()
        {
            throw new NotImplementedException();
        }

        public void useItem(Door d, LockPick l)
        {
            //if (d doesn't require key to be unlocked)
            //{
            //    d.Unlock(LockPick l);
            //}
            //else if (door requires key)
            //{
            //    Console.WriteLine("Door requires key");
            //}
            //else
            //{ 
            //  Console.WriteLine("Door already unlocked"); //Would be removed if action can only be
            //} //performed on doors that are locked
            l.uses--;
        }

        public string ToString()
        {
            return name + "\n" + description + "\nUses per pick" + uses + "\nWeight: " + weight;
        }
    }
}
