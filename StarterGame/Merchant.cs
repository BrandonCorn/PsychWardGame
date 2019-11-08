using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class Merchant : INPC
    {

        private readonly string name = "Merchant"; 
        public string Name { get { return name; } }
        private string description;
        public string Description { get { return description; } }

        //The tasks can be assigned to rooms by the GameWorld, but the Merchant has control of them
        //only she can take away from the taskList, or access them to mark them as completed to move through 
        //the game. 
        
        private Queue<ITask> taskList;
        public Queue<ITask> TaskList { get { return new Queue<ITask>(taskList); } }
        //created a merchant room, this can be changed in the game world

        private Room merchantRoom;

        //we want access to the merchant room to see if the player is in there and can then start interacting
        //with her. 
        public Room MerchantRoom { get { return this.merchantRoom; } }
        public Merchant(Room room)
        {
           
            this.merchantRoom = room;
            this.taskList = new Queue<ITask>();
            NotificationCenter.Instance.addObserver("EnteredMerchantRoom", enteredMerchantRoom);
        }

        //add tasks to the merchants list
        public void addTask(ITask task)
        {
            this.taskList.Enqueue(task);
        }

        private void enteredMerchantRoom(Notification notification)
        {
            Console.WriteLine("\nWould you like to:\n\tbuy goods" +
                "\n\tsell goods");
        }


    }
}
