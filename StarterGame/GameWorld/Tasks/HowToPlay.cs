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

        /**Callback method to task that provides the player an explaination of how the combat system works. 
           @param: Notification from the GameWorld that this is the first battle
        **/
        public void FirstBattle(Notification notification)
        {
            Console.WriteLine("\n\n****************************************************");
            Console.WriteLine("Welcome to your first battle! \n\tTo attack your opponent type \"fight\".\n\t" +
                "To heal yourself in battle open your bag and type \"use\" + the name of the item to use.\n\t" +
                "To run away from the enemy type \"run\".");
            NotificationCenter.Instance.removeObserver("FirstBattle", FirstBattle);
        }

        /**Callback method that notifies the task that the player has interacted with the merchant for the first time
         * @param: Notification from the Interaction command that the first interaction has been initiated, this can only 
         *  be the merchant due to the other rooms being closed and the merchant being the only NPC. 
        **/
        public void FirstMerchantInteraction(Notification notification)
        {
            Console.WriteLine("\n****************************************************");
            Console.WriteLine("To view the merchant's inventory type \"merchandise\".\n" + "To buy an item " +
                "type \"buy\" + the item name.\n" + "To sell an item type \"sell\" + the item name.");
            Console.WriteLine("****************************************************\n");
            NotificationCenter.Instance.removeObserver("FirstMerchantInteraction", FirstMerchantInteraction);
        }

        /**Callback method notifies the task that enemies have been killed and contributed to the amount the task requires. 
         * @params: Notification from the GameWorld that the player has killed an enemy. 
         **/
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
        
        /**Callback method that notifies the task that the player has picked up their first item. 
         * @params: Notification from the player that they have picked up an item. 
         **/
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

        /**Checks whether the player has killed the number of enemies necessary to complete the task.
         * return: Boolean value that player has killed num enemies necessary for task completion. 
         **/
        public bool hasKilledEnemies()
        {
            return EnemiesKilled == enemiesToKill;
        }

        /**Checks whether the challenges required for task completion have been fulfilled. Notifies the GameWorld the task
         * has been completed to open the rooms doors for further exploration. 
         * @return: Boolean value of task completion. 
         **/
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
