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

        //Chance that a an enemy will appear in a room, each room can have a different chance and it is 
        //decided at runtime. 
        private int chanceEnemy;
        public int ChanceEnemy { get { return chanceEnemy; } }

        public Room() : this("No Tag", "short", 0)
        {
            
        }

        public Room(string tag) : this(tag,"short", 0)
        {
            exits = new Dictionary<string, Door>();
            this.tag = tag;
           
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

        //Method will calculate likelihood that you run into an enemy. Made static since it pertains to rooms
        //but want gameworld to have access to dictate battles. 
        public static bool runIntoEnemy(Player player)
        {
            int chance1 = new Random().Next(1, player.currentRoom.ChanceEnemy + 1);
            int chance2 = new Random().Next(1, player.currentRoom.ChanceEnemy + 1);
            if (chance1 == chance2)
            {
                return true; 
            }
            return false;
        }

        //Method will randomly spawn an enemy for you. This can be tweaked to take into account level, room
        //and other circumstances. method is static to give game world access. 
        public static IEnemy getAnEnemy()
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
