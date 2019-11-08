using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class Room
    {
        private Dictionary<string, Door> exits;
        private string _tag;
        public string tag { get { return _tag; } set { _tag = value; } }

        public string shortName { get; set; }

        //chance that a an enemy will appear in a room, each room can have a different chance and it is 
        //decided at runtime. 
        private int chanceEnemy;
        public int ChanceEnemy { get { return chanceEnemy; } }

        public Room() : this("No Tag")
        {

        }

        public Room(string tag) : this(tag,"short", 0)
        {
            exits = new Dictionary<string, Door>();
            this.tag = tag;
            NotificationCenter.Instance.addObserver("BattleSequence", battleSequence);
        }
        public Room(string tag, string shortName) : this(tag, shortName, 0)
        {
            exits = new Dictionary<string, Door>();
            this.tag = tag;
            this.shortName = shortName;
        }
        public Room(String tag, string shortName, int chanceEnemy)
        {
            this.tag = tag;
            this.shortName = shortName;
            this.chanceEnemy = chanceEnemy;
            exits = new Dictionary<String, Door>();
        }

        public void setExit(string exitName, Door door)
        {
            exits[exitName] = door;
        }

        public Door getExit(string exitName)
        {
            Door door = null;
            exits.TryGetValue(exitName, out door);
            return door;
        }

        public string getExits()
        {
            string exitNames = "Exits: ";
            Dictionary<string, Door>.KeyCollection keys = exits.Keys;
            int count = 0;
            foreach (string exitName in keys)
            {
                count += 1;
                if (keys.Count == count)
                {
                    exitNames += " " + exitName;
                }
                else
                {
                    exitNames += " " + exitName + ", ";
                }
            }

            return exitNames;
        }

        public string description()
        {
            return "You are " + this.tag + ".\n *** " + this.getExits();
        }

        //This method is callback method from player entering a room, it will initiate and conduct a battle
        //between a player and randomly generated enemy if the random numbers match. 
        public void battleSequence(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (runIntoEnemy())
            {
                IEnemy enemy = getAnEnemy();
            }

        }

        //Method will calculate likelihood that you run into an enemy. 
        public bool runIntoEnemy()
        {
            int chance1 = new Random().Next(1, this.ChanceEnemy);
            int chance2 = new Random().Next(1, this.ChanceEnemy);
            if (chance1 == chance2)
            {
                return true; 
            }
            return false;
        }

        //Method will randomly spawn an enemy for you. This can be tweaked to take into account level, room
        //and other circumstances. 
        public IEnemy getAnEnemy()
        {
            int chance = new Random().Next(1, 3); 
            if (chance == 1)
            {
                return new Rat();
            }
            return new ZombiePatient();
        }

    }
}
