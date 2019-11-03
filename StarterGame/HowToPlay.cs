using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class HowToPlay : ITask 
    {
        private string name; 
        public string Name { get; }

        private bool active;
        public bool Active { get; }

        private bool complete; 
        public bool Complete { get; }

        private Room taskRoom;
        public Room TaskRoom { get; }

        private string description; 
        public string Description { get; }

        public HowToPlay(Room room)
        {
            this.name = "How To Play";
            this.active = false;
            this.complete = false;
            this.taskRoom = room;
            this.description = "This quest will give you a run down of playing the game, things ranging" +
                " from selecting commands to fighting enemies.";
            
        }
    }
}
