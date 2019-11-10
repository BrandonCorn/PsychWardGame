using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class GenericNpc : INPC
    {
        private string name; 
        public string Name { get { return name; } set { name = value; } }
        private string description;
        public string Description { get { return description; } set { description = value; } }

        public GenericNpc() : this("No name", "A dull player with no life")
        {
        
        }
        public GenericNpc(string name) : this(name, "A dull player with no life")
        {
            this.name = name;
        }

        public GenericNpc(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
    }
}
