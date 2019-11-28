using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class Merchant : INPC
    {

        private readonly string name = "Merchant"; 
        public string Name { get { return name; } }
        private readonly string description = "Nice person who wants to trade with you!";
        public string Description { get { return description; } }

        //The tasks can be assigned to rooms by the GameWorld, but the Merchant has control of them
        //only she can take away from the taskList, or access them to mark them as completed to move through 
        //the game. 

        private Queue<ITask> taskList;

        private ITask[] tasks = { new HowToPlay() }; 
        public Queue<ITask> TaskList { get { return taskList; } }
        //created a merchant room, this can be changed in the game world

        private Room merchantRoom;

        //we want access to the merchant room to see if the player is in there and can then start interacting
        //with her. 
        public Room MerchantRoom { get { return this.merchantRoom; } }
        public Merchant(Room room)
        {
            this.merchantRoom = room;
            this.taskList = new Queue<ITask>(tasks);
            //NotificationCenter.Instance.addObserver("EnteredMerchantRoom", enteredMerchantRoom);
            NotificationCenter.Instance.addObserver("PlayerSpeak_merchant", PlayerSpeak_merchant);
            NotificationCenter.Instance.addObserver("LeaveMerchant", LeaveMerchant);
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
            if (player.Backpack == null)
            {
                Console.WriteLine("\nOh a new traveler. You're going to have trouble carrying things around in " +
                "your arms. Take this, it will help!");
                player.Backpack = new Backpack();
                player.Backpack.giveItem(new SutureKit());
                Console.WriteLine(player.Backpack.Description);
            }
            NotificationCenter.Instance.postNotification(new Notification("PushMerchantCommands", this));
            if (player.CurrentTask == null || player.CurrentTask.TaskState == TaskState.Complete)
            {
                player.setCurrentTask(TaskList.Dequeue());
                NotificationCenter.Instance.postNotification(new Notification("TaskSet", this));
            }

            Console.WriteLine("\nWould you like to: \n\tsell goods" + "\n\tbuy goods");

        }
        
        //Displays when interaction with merchent ends. 
        public void LeaveMerchant(Notification notification)
        {
            Console.WriteLine("\n\nThank's for your business. Come again soon!\n\n");
            
        }


    }
}
