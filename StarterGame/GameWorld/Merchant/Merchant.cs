using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class Merchant : INPC
    {

        private readonly string name = "merchant"; 
        public string Name { get { return name; } }
        private readonly string description = "Nice person who wants to trade with you!";
        public string Description { get { return description; } }

        //The tasks can be assigned to rooms by the GameWorld, but the Merchant has control of them
        //only she can take away from the taskList, or access them to mark them as completed to move through 
        //the game. 

        private Queue<ITask> taskList;
        public Queue<ITask> TaskList { get { return taskList; } }

        private ITask[] tasks = { new HowToPlay(), new KeyTask() }; 

        //This inventory is everything the merchant has available for purchase. 
        private Dictionary<string, I_Item> inventory;
        public Dictionary<string, I_Item> Inventory { get { return inventory; } set { inventory = value; } }

        private static I_Item[] MerchantItems = { new Axe(), new BandAid(), new Bat(),
            new FirstAidKit(), new Hammer(), new Knife(), 
            new Machete(), new SutureKit()};

        //The room that the merchant is currently in. 
        private Room merchantRoom;
        public Room MerchantRoom { get { return this.merchantRoom; } }
        public Merchant(Room room)
        {
            this.merchantRoom = room;
            this.taskList = new Queue<ITask>(tasks);
            inventory = new Dictionary<string, I_Item>();
            foreach (I_Item item in MerchantItems) { inventory[item.Name] = item; }

            NotificationCenter.Instance.addObserver("PlayerSpeak_merchant", PlayerSpeak_merchant);
            NotificationCenter.Instance.addObserver("LeaveMerchant", LeaveMerchant);
            NotificationCenter.Instance.addObserver("ViewInventory", ViewInventory);
            NotificationCenter.Instance.addObserver("PlayerPurchaseMessage", PlayerPurchaseMessage);
            NotificationCenter.Instance.addObserver("RepairWeapon", RepairWeapon);

        }

        /**
         * Add tasks to the merchants list
         * @params: (ITask)The task to be added to the merchant's list. 
         * @returns: void
         **/

        public void addTask(ITask task)
        {
            this.taskList.Enqueue(task);
        } 

        /**When the player enters the merchant room, the commands allowed in the merchant room are set. 
         * @params: (Notification) notification that is sent from the Game World letting the merchant know the player has 
         * entered the room
         * @returns: void
         **/
        private void PlayerSpeak_merchant(Notification notification)
        {
            Player player = (Player)notification.Object;
            NotificationCenter.Instance.postNotification(new Notification("PushMerchantCommands", this));
            giveBackpack(player);
            givePlayerTask(player);
            NotificationCenter.Instance.postNotification(new Notification("SpokeToMerchant", player));
            player.outputMessage("\nPlayer Coins: " + player.Coins);
            Console.WriteLine("\nWould you like to: \n\tbuy goods" + "\n\tsell goods" + "\n\trepair weapon");
        }
        
        /**Displays when interaction with merchent ends. 
         * @params: (Notification) notification from player's walk away command that ends the let's the merchant know the 
         * interaction with the player is over. 
         * @returns: void
         **/
        public void LeaveMerchant(Notification notification)
        {
            Console.WriteLine("\n\nThank's for your business. Come again soon!\n\n");
            
        }

        /**Gives the new player a backpack. 
         * @params: The player who the merchant is giving the key item backpack. 
         * @returns: void
         **/
        public void giveBackpack(Player player)
        {
            if (player.Backpack == null)
            {
                Console.WriteLine("\nOh a new traveler. You're going to have trouble carrying things around in " +
                "your arms. Take this, it will help!");
                player.Backpack = new Backpack();
                player.Backpack.giveItem(new SutureKit());
                Console.WriteLine(player.Backpack.Description);
            }
        }

        /**
         * Gives the player a task on the condition that they have completed their current task or do not have one currently set. 
         * @params: (Player) The player who is being given the task. 
         * @returns: void
         **/
        public void givePlayerTask(Player player)
        {
            if (player.CurrentTask == null || player.CurrentTask.TaskState == TaskState.Complete)
            {
                if (TaskList.Count > 0)
                {
                    player.setCurrentTask(TaskList.Dequeue());
                    NotificationCenter.Instance.postNotification(new Notification("TaskSet", player));
                }
                else
                {
                    Console.WriteLine("\nYou have completed all current tasks available!");
                }
            }
        }

        /**
         * Displays the inventory the merchant has for sale. 
         * @params: (Notification) notification from the player's merchandise command that they would like to view the inventory
         * the merchant has for sale. 
         * @return: void
         **/
        public void ViewInventory(Notification notification)
        {
            string itemDisplay = "";
            Dictionary<string, I_Item>.ValueCollection values = Inventory.Values;
            foreach(I_Item item in values)
            {
                itemDisplay += item.Name + ": " + item.PurchasePrice + " | " + item.SellPrice + "\n";
            }
            Console.WriteLine("\n****************************************************");
            Console.WriteLine("Item Name: Purchase Value | Sell Value");
            Console.WriteLine("_____________________________________________________");
            Console.WriteLine(itemDisplay);
            Console.WriteLine("****************************************************\n");
        }

        /**
         * Retrieves an item from the merchant's inventory that they have available for purchase. 
         * @params: (String) The name of the item to be retrieved. 
         * @returns: (I_Item) The item that is in the inventory if available. 
         **/
        public I_Item itemFromInventory(string name)
        {
            I_Item item = null;
            Inventory.TryGetValue(name, out item);
            return item;
        }

        /**
         * Message thanking the player for purchasing an item. 
         * @params: (Notification) notification from the player's buy command that they have purchased an item. 
         * @returns: void 
         **/
        public void PlayerPurchaseMessage(Notification notification)
        {
            Console.WriteLine("Thank you for your purchase!");
        }

        /**
         * Let's the merchant know that they player has purchased the repair of a weapon and the merchant repairs it. 
         * @params: (Notification) notification from the player's repair command that they have purchased a weapon repair. The
         * notification object provides the weapon to be repaired. 
         * @returns: void
         **/
        public void RepairWeapon(Notification notification)
        {
            IWeapon weapon = (IWeapon)notification.Object;
            weapon.Uses = weapon.MaxUse; 
        }
    }
}
