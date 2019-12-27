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
        private int enemiesKilled; 
        public int EnemiesKilled { get { return enemiesKilled; } set { enemiesKilled = value; } }
        private readonly int enemiesToKill = 2;
    
        private bool pickedUpItem { get; set; }

        //private Room taskRoom;
        //public Room TaskRoom { get { return taskRoom; } }

        private string description;
        public string Description { get { return description; } }


        public HowToPlay()
        {
            name = "How To Play";
            taskState = TaskState.Inactive;
            enemiesKilled = 0;
            //this.taskRoom = room;
            description = "This quest will give you a run down of playing the game, things ranging" +
            " from selecting commands to fighting enemies. \n\t Beat 2 enemies! \n\t Pick up an item!";
            NotificationCenter.Instance.addObserver("FirstBattle", FirstBattle);
            NotificationCenter.Instance.addObserver("FirstMerchantInteraction", FirstMerchantInteraction);
            NotificationCenter.Instance.addObserver("KilledEnemies", KilledEnemies);
            NotificationCenter.Instance.addObserver("PickedUpItem", PickedUpItem);
        }

        //Callback method to task that provides the player an explaination of how the combat system works. 
        public void FirstBattle(Notification notification)
        {
            Console.WriteLine("\n\n****************************************************");
            Console.WriteLine("Welcome to your first battle! \n\tTo attack your opponent type \"fight\".\n\t" +
                "To heal yourself in battle open your bag and type \"use\" + the name of the item to use.\n\t" +
                "To run away from the enemy type \"run\".");
            NotificationCenter.Instance.removeObserver("FirstBattle", FirstBattle);
        }

        public void FirstMerchantInteraction(Notification notification)
        {
            Console.WriteLine("\n****************************************************");
            Console.WriteLine("To view the merchant's inventory type \"merchandise\".\n" + "To buy an item " +
                "type \"buy\" + the item name.\n" + "To sell an item type \"sell\" + the item name.");
            Console.WriteLine("****************************************************\n");
            NotificationCenter.Instance.removeObserver("FirstMerchantInteraction", FirstMerchantInteraction);
        }

        //Callback method notifies the task that enemies have been killed and contributed to the amount 
        //the task requires. 
        public void KilledEnemies(Notification notification)
        {
            Player player = (Player)notification.Object;
            EnemiesKilled++;
            if (hasKilledEnemies())
            {
                player.outputMessage("\nYou've killed two enemies!");
                TaskComplete();
                NotificationCenter.Instance.removeObserver("KilledEnemies", KilledEnemies);
            }
        }
        
        public void PickedUpItem(Notification notification)
        {
            Player player = (Player)notification.Object;
            pickedUpItem = true;
            Console.WriteLine("\n****************************************************");
            player.outputMessage("You successfully picked up your first item!!\n");
            player.outputMessage("Anytime you need to pick up an item simply type \"pick up\" followed by the" +
                " name of the item.\n");
            Console.WriteLine("****************************************************\n");
            TaskComplete();
            NotificationCenter.Instance.removeObserver("PickedUpItem", PickedUpItem);
        }

        public bool hasKilledEnemies()
        {
            return EnemiesKilled == enemiesToKill;
        }

        public void TaskComplete()
        {
            if (pickedUpItem && hasKilledEnemies())
            {
                TaskState = TaskState.Complete;
                Console.WriteLine("\nYou completed the How to Play task!! Visit the merchant to get "
                    + "another task!\n");
                NotificationCenter.Instance.postNotification(new Notification("FinishedFirstTask", this));
            }
        }
    }
}
