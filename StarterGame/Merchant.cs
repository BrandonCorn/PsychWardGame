using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class Merchant
    {
        //The tasks can be assigned to rooms by the GameWorld, but the Merchant has control of them
        //only she can take away from the taskList, or access them to mark them as completed to move through 
        //the game. 

        private Queue<ITask> taskList;
        public Queue<ITask> TaskList { get; }
        //created a merchant room, this can be changed in the game world

        private Room merchantRoom;

        //we want access to the merchant room to see if the player is in there and can then start interacting
        //with her. 
        public Room MerchantRoom { get { return this.merchantRoom; } }
        public Merchant(Room room)
        {
            this.merchantRoom = room;
            this.taskList = new Queue<ITask>();
           
        }

        //add tasks to the merchants list
        public void addTask(ITask task)
        {
            this.taskList.Enqueue(task);
        }
        

    }
}
