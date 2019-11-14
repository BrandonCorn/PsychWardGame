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
            NotificationCenter.Instance.addObserver("PlayerSpeak_merchant", PlayerSpeak_merchant);
        }

        //add tasks to the merchants list
        public void addTask(ITask task)
        {
            this.taskList.Enqueue(task);
        }

        //When the player enters the merchant room, the commands allowed in the merchant room are set. 
        private void PlayerSpeak_merchant(Notification notification)
        {
            Player player = (Player)notification.Object;
            NotificationCenter.Instance.postNotification(new Notification("PushMerchantCommands", this));
            if (player.CurrentTask == null || player.CurrentTask.Complete == true)
            {
                player.setCurrentTask(GameWorld.Instance.LadyMerchant.TaskList.Dequeue());
                NotificationCenter.Instance.postNotification(new Notification("TaskSet", this));
            }
            //Need to put an option to interact with merchant to allow buy/sell commands

            //Console.WriteLine("\n\nHere's an updated set of commands: " 
            
            Console.WriteLine("\nWould you like to:\n\tbuy goods" +
                "\n\tsell goods");
            
            //Need to add command to end interaction !!!!!
        }

        private void enteredMerchantRoom(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (player.CurrentTask == null || player.CurrentTask.Complete == true)
            {
                player.setCurrentTask(GameWorld.Instance.LadyMerchant.TaskList.Dequeue());
                NotificationCenter.Instance.postNotification(new Notification("TaskSet", this));
            }
            //Need to put an option to interact with merchant to allow buy/sell commands
            
            Console.WriteLine("\nWould you like to:\n\tbuy goods" +
                "\n\tsell goods");

        }


    }
}
