using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class Room
    {
        private Dictionary<string, Door> exits;
        private string _tag;
        public string tag
        {
            get
            {
                return _tag;
            }
            set
            {
                _tag = value;
            }
        }

        public string shortName { get; set; }

        public Room() : this("No Tag")
        {

        }

        public Room(string tag) : this(tag,"short")
        {
            exits = new Dictionary<string, Door>();
            this.tag = tag;
        }

        public Room(String tag, string shortName)
        {
            this.tag = tag;
            this.shortName = shortName;
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
            foreach (string exitName in keys)
            {
                exitNames += " " + exitName + ", ";
            }

            return exitNames;
        }

        public string description()
        {
            return "You are " + this.tag + ".\n *** " + this.getExits();
        }
    }
}
