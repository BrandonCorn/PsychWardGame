using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class Player
    {
        private Room _currentRoom = null;
        public Room currentRoom { get { return _currentRoom; } set { _currentRoom = value; } }

        //player's current strength
        private int attack; 
        public int Attack { get { return attack;} set { attack = value; } }
        
        //player's temporary attack increase 
        private int tempAttack; 
        public int TempAttack { get { return tempAttack; } set { tempAttack = value; } }

        //player's current speed
        private int speed; 
        public int Speed { get { return speed; } set { speed = value; } }

        //player's temporary speed increase
        private int tempSpeed;
        public int TempSpeed { get { return tempSpeed; } set { tempSpeed = value; } }

        //player current defense
        private int block; 
        public int Block {  get { return block; } set { block = value;  } }

        //player's current health. 
        private int health; 
        public int Health { get { return health; } set { health = value; } }

        //player's maximum health
        private int maxHealth; 
        public int MaxHealth { get { return maxHealth; } set { maxHealth = value; } }

        //Player level up system, starts at level 1 
        private int level; 
        public int Level { get { return level; } set { level = value; } }

        //Experience will be total experience for player and is used for level up. 
        private int experience; 
        public int Experience { get { return experience; } set { experience = value; } }

        //ExpLimit is the amount of experience the player needs to reach the next level. 
        private int expNeeded; 
        public int ExpNeeded { get { return expNeeded; } set { expNeeded = value; } }

        private int coins; 
        public int Coins { get { return coins; } set { coins = value; } }
        
        //Current Task is simply that, the task the player is currently trying to complete given by the merchant.
        private ITask currentTask; 
        public ITask CurrentTask { get { return currentTask; } }

        //The player will be capable of holding one weapon at a time. The players weapon attack will 
        //stack onto the players attack damage and each battle will degrade the weapons use by one. 
        private IWeapon weapon; 
        public IWeapon Weapon { get { return weapon; } set { weapon = value; } }

        //Allows the player to keep a limited inventory with them. 
        private Backpack backpack; 
        public Backpack Backpack { get { return backpack; } set { backpack = value; } }

        //Chance of landing hit on the enemy 
        private int hitProbability;
        public int HitProbability { get { return hitProbability; } }

        //Player State may be used to define the different circumstances the player may be in. 
        private PlayerState playerState;
        public PlayerState PlayerState { get { return playerState; }  set { playerState = value; } }

        //The players battle state will be the condition of their health i.e. paralyzed, confused, poisoned. 
        private BattleState battleState;
        public BattleState BattleState { get { return battleState; } set { battleState = value; } }

        public Player(Room room)//, GameOutput output)
        {
            _currentRoom = room;
            currentTask = null;
            attack = new Random().Next(3,7);
            tempAttack = 0;
            speed = new Random().Next(1, 5);
            tempSpeed = 0;
            block = 0; 
            level = 1;
            maxHealth = 10;
            health = MaxHealth;
            experience = 0;
            expNeeded = 15;
            coins = 0;
            weapon = null;
            backpack = null; 
            hitProbability = 2;
            playerState = PlayerState.Wandering; 
            NotificationCenter.Instance.addObserver("TaskSet", TaskSet);
        }

        /**
         * Called each time the player walks to a new room. Notifies the gameworld so that possible battle may occur notifies
         * that the room contains an NPC. 
         * @params: String direction is name of room player is traveling to so that associated door can be retrieved.  
         **/
        public void waltTo(string direction)
        {
            Door door = this._currentRoom.getExit(direction);
            if (door != null)
            {
                if (door.Open)
                {
                    this._currentRoom = door.room(this.currentRoom);
                    // Player posts a notification PlayerEnteredRoom
                    this.outputMessage("\n" + this._currentRoom.description());
                    NotificationCenter.Instance.postNotification(new Notification("EnteredNpcRoom", this));
                    NotificationCenter.Instance.postNotification(new Notification("BattleSequence", this));
                }
                else
                {
                    this.outputMessage("\n The door to " + direction + " is closed.\n");
                    this.outputMessage("\n" + this._currentRoom.description());
                }
            }
            else
            {
                this.outputMessage("\nThere is no door to " + direction);
                this.outputMessage("\n" + this._currentRoom.description());
            }
        }

        /**
         * Method for output of spoken word by the player. Sends out notification that the player has spoken. 
         * @params: String word is the message the player speaks provided for output. 
         * @returns: void
         **/
        public void speak(String word)
        {
            outputMessage(word);
            NotificationCenter.Instance.postNotification(new Notification("Player has spoken", this));
        }

        /**
         *Method providing the current enemy of the player from the room they are in. 
         * @params: None
         * @return: (IEnemy) current enemy of the player. 
         **/
        public IEnemy getEnemy()
        {
            return currentRoom.CurrentEnemy;
        }

        /**
         * Method performs an attack on the current enemy of the player. Resets the players temp stat increases each attack as
         * game will only have items that perform this increase for one use/attack
         *@params: none
         * @returns: void
         **/
        public void attackEnemy()
        {
            playerAttackDescription();
            int discount = new Random().Next(1, (Attack / 2) + 1);
            currentRoom.CurrentEnemy.Health -= (this.totalAttack()-discount);
            if (Weapon != null)
            {
                Weapon.useWeapon(this);
            }
            TempAttack = 0;
            TempSpeed = 0; 
        }

        /**
         * Describes the attack of the player towards their enemy which varies based on whether they possess a weapon or not.
         * @params: none
         * @returns: void
         **/
        public void playerAttackDescription()
        {
            if (Weapon != null)
            {
                this.Weapon.useWeaponDescription(this);
            }
            else { outputMessage("\nYou punch aggressively at the enemy"); }
        }

        /**
         * Provides the total attack of the player adding up their attack with that of their current weapon. 
         * @return: (int) the total attack of the player. 
         **/
        public int totalAttack()
        {
            if (weapon == null)
            {
                return playerAttack();
            }
            return Weapon.getStrength(this);
        }

        /**
         * The combined value of the player's attack the items they've used for temporary attack increase. 
         * @params: none
         * @return: (int) combined attack power
         **/
         public int playerAttack()
        {
            return this.Attack + tempAttack;
        }

        /**
         * Determines if the current player has defeated their enemy. If true it notifies the GameWorld so that it can 
         * note the progress. 
         * @param: Player: The current player of the game. Enemy: The current enemy of the player. 
         * @return: True/false value based on whether the enemy has been defeated. 
         **/
        public bool defeatedEnemy(Player player,IEnemy enemy)
        {
            if (enemy.Health <= 0)
            {
                NotificationCenter.Instance.postNotification(new Notification("BattleOver",player));
                return true;
            }
            return false;
        }

        /**
         * Check to see if player is alive or defeated by enemy. 
         * @return: (bool) whether the player is alive or not. 
         **/
        public bool playerDefeated()
        {
            return Health <= 0;
        }
        
        /**A notification to the player that a task has been set. The task is then set to active. 
         * @params: (Notification) from merchant that task is set. 
         **/
        public void TaskSet(Notification notification)
        {
            this.CurrentTask.TaskState = TaskState.Active;
            Console.WriteLine("\n****************************************************");
            Console.WriteLine("A task has been set! (To view the task type \"task\")");
            Console.WriteLine("****************************************************\n");
        }

        /**Sets the task given to the player. 
         * @params: (ITask) task to be set for player. 
         **/
        public void setCurrentTask(ITask task)
        {   
                this.currentTask = task; 
        }

        /**
         * outputs messages directly from the player. 
         * @params: (String) message to be output from player. 
         **/
        public void outputMessage(string message)
        {
            Console.WriteLine(message);
        }

        /**Current stats of player health, attack, and what weapon they possess. 
        ****At the moment speed is accessed directly, will be altered once armor and items have an effect on speed. 
        **/
        public void currentStats()
        {
            outputMessage("Player \nHealth: " + this.Health + (Weapon == null ? "\nNo Weapon" : "\nWeapon: " + Weapon.Name) +
                "\nAttack: " + this.totalAttack() + "\nSpeed: " + this.Speed + "\nBlock: " + this.Block);
        }

        /**
         * Picks up an item to be placed in backpack if it will fit in the bag and notifies subscribers. 
         * @params: (String) name of the item to be picked up. 
         **/
        public void pickUpItem(string itemName)
        {
            I_Item item = currentRoom.takeItem(itemName);
            if (item != null)
            {
                NotificationCenter.Instance.postNotification(new Notification("PickedUpItem",this));
                if ((Backpack.weightInBag() + item.Weight) >= Backpack.Capacity)
                {
                    Console.WriteLine("Backpack is full.");
                    currentRoom.giveItem(item);
                }
                else if (item.ItemTypes.Contains(ItemType.Weapon) && Weapon == null)       
                {
                    Weapon = (IWeapon)item;
                    Console.WriteLine("\nYour weapon has been set to the " + itemName + "!\n");
                }

                else
                {
                    Backpack.giveItem(item);
                    Console.WriteLine("\nYou picked up a " + itemName + "!\n"); 
                }
            }
        }

        /**
         * Takes an item out of the backpack
         * @params: (String) name of the item to be taken from backpack
         **/
        public I_Item takeFromBackpack(string item)
        {
            return Backpack.takeItem(item);
        }

        /**
         * Places item in the backpack
         * @param: (I_Item) item object to be placed in backpack. 
         **/
        public void addToBackpack(I_Item item)
        {
            Backpack.giveItem(item);
        }

        /**
         * All the changes to stats for player when they level up. 
         * @params: experience earned from defeat of enemy. 
         **/
        public void LevelUp(int experience)
        {
            Experience += experience;
            while (reachNextLevel())
            {
                Level++;
                Attack = (int)(attack * 1.35f);
                Speed = (int)(speed * 1.3f);
                MaxHealth = MaxHealth + 5;
                Health = MaxHealth;
                ExpNeeded = ExpNeeded + (int)(ExpNeeded * 1.5f);
                
                outputMessage("\nYou grew to level " + (Level));
            }
            
        }

        /**
         * Returns whether a player has reached the next level or not.
         * @return: (bool) value indicating whether next level achieved. 
         **/
        public bool reachNextLevel()
        {
            if (Experience >= ExpNeeded)
            {
                return true;
            }
            return false;
        }

        /**
         * Experience needed to get to next Level
         * @return: (int) experience needed for next level. 
         **/
        public int expToNextLvl()
        {
            return ExpNeeded - Experience;
        }

        /**
         * Sets the players current weapon
         * @params: (IWeapon) weapon to be set for player. 
         **/
        public void setWeapon(IWeapon weapon)
        {
            Weapon = weapon; 
        }

        /**
         * Takes players current weapon 
         * @return: (IWeapon) weapon taken from player. 
         **/
        public IWeapon takeWeapon()
        {
            IWeapon current = this.Weapon;
            this.Weapon = null;
            return current;
        }

        /**
         * Player counts their coins to see if they have enough for item
         * @params: (I_Item) item player would like to purchase. Need access for value of item. 
         * @return: (bool) player has enough coins for purchase of item. 
         **/
        public bool hasEnoughCoins(I_Item item)
        {
            if (Coins < item.PurchasePrice)
            {
                this.outputMessage("\nYou don't have enough money for " + item);
                return false;
            }
            return true;
        }

        /**
         * Player uses their coins for item to purchase 
         * @params: (int) How much coin the player has spent on purhase. 
         **/
        public void spendCoins(int amount)
        {
            this.Coins -= amount;
        }

        /**
         * Player accepts coins 
         * @params: (int) amount coins to give to player
         **/
        public void receiveCoins(int amount)
        {
            this.Coins += amount;
        }
    }

}
