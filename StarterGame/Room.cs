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

        //Contains all the NPCs that a player can interact with in a room. They Key will be the name they 
        //given, creator of the game chooses this when compiling. The value will be the enemy themselves. 
        private Dictionary<NpcName, INPC> roomNpcs; 
        
        public Dictionary<NpcName,INPC> RoomNpcs { get { return roomNpcs; } }

        public Room() : this("No Tag", "short", 0, 0)
        {
            
        }

        public Room(string tag) : this(tag, "short", 0, 0)
        {
            exits = new Dictionary<string, Door>();
            this.tag = tag;
            roomNpcs = new Dictionary<NpcName, INPC>();
        }
        public Room(string tag, string shortName) : this(tag, shortName, 0, 0)
        {
            exits = new Dictionary<string, Door>();
            this.tag = tag;
            this.shortName = shortName;
            roomNpcs = new Dictionary<NpcName, INPC>();
        }
        public Room(String tag, string shortName, int chanceEnemy) : this(tag, shortName, chanceEnemy, 0)
        {
            exits = new Dictionary<String, Door>();
            this.tag = tag;
            this.shortName = shortName;
            this.chanceEnemy = chanceEnemy;
            roomNpcs = new Dictionary<NpcName, INPC>();
        }
        //In the case that the user tells us to place some NPC's in the room this can do some randomly and
        //we only need to give the number of them we want. A generic class will be created to give them
        //their own characterstics 
        public Room(String tag, string shortName, int chanceEnemy, int numNpcs)
        {
            exits = new Dictionary<String, Door>();
            this.tag = tag;
            this.shortName = shortName;
            this.chanceEnemy = chanceEnemy;

            for (int i = 0; i < numNpcs; i++)
            {
                //This method adds a random npc from this enum of npc names and creates a generic npc 
                //character to assign to it. 
                roomNpcs.Add((NpcName)Enum.Parse(typeof(NpcName),Enum.GetName(typeof(NpcName), 
                    new Random().Next(1, Enum.GetNames(typeof(NpcName)).Length))),new GenericNpc());
            }
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

        //Method will calculate the chance of running into an enemy and the random numbers match a 
        //random enemy will be spawned and presented in the game world. 
        public static IEnemy getAnEnemy(Player player)
        {
            int chance1 = new Random().Next(1, player.currentRoom.ChanceEnemy + 1);
            int chance2 = new Random().Next(1, player.currentRoom.ChanceEnemy + 1);
            if (chance1 == chance2)
            {
                int chance = new Random().Next(1, 3);
                if (chance == 1)
                {
                    return new Rat();
                }
                return new ZombiePatient();
            }
            return null;
        }
    }
}
