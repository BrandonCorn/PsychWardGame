using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    //This class will be the first task, it is created at the creation of the game in the createWorld method of 
    //the game world. This will be done once we have finished implementing all the other classes. We need the 
    //other classes to be working entirely before tasks can be truly implemented. 
    public class HowToPlay : ITask 
    {
        private string name; 
        public string Name { get { return name; } }

        private TaskState taskState;
        public TaskState TaskState { get { return taskState; } set { taskState = value; } }

        //private Room taskRoom;
        //public Room TaskRoom { get { return taskRoom; } }

        private string description = "This quest will give you a run down of playing the game, things ranging" +
                " from selecting commands to fighting enemies.";
        public string Description { get { return description; } }


        public HowToPlay()
        {
            name = "How To Play";
            taskState = TaskState.Inactive;
            //this.taskRoom = room;
            //this.description = "This quest will give you a run down of playing the game, things ranging" +
            //    " from selecting commands to fighting enemies.";
        }


        
    }
}
