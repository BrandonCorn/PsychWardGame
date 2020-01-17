using System.Collections;
using System.Collections.Generic;
using System;
using StarterGame.Items.StatItems;

namespace StarterGame
{
    public class GameWorld
    {
        static private GameWorld _instance;
        static public GameWorld Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameWorld();
                return _instance;
            }
        }

        private Room _entrance;
        public Room Entrance { get { return _entrance; } }
        private Room gameBeginTrigger;
        private Room firstTaskFinished;
        private Room bossBattleDoor;
        private string triggerWord;
        private List<Room> hotList;
        
        private GameWorld()
        {
            hotList = new List<Room>();
            _entrance = createWorld();

           
            // GameWorld subscribes to the notification PlayerEnteredRoom
            NotificationCenter.Instance.addObserver("Player has spoken", playerSpeak);
            NotificationCenter.Instance.addObserver("EnteredNpcRoom", EnteredNpcRoom);
            NotificationCenter.Instance.addObserver("BattleSequence", battleSequence);
            NotificationCenter.Instance.addObserver("SpokeToMerchant", SpokeToMerchant);
            NotificationCenter.Instance.addObserver("FinishedFirstTask", FinishedFirstTask);
            NotificationCenter.Instance.addObserver("BattleOver", BattleOver);
        }

        private Room createWorld()
        {

            Room entrance = new Room(" at the entrance of the PsychWard", "entrance");
            Room merch = new Room("in the merchant's room", "merchant room");
            Room mainHall = new Room("in the main hall", "main hall", 1);
            Room cafeteria = new Room("in the cafeteria", "cafeteria");
            Room maleWard = new Room("in the male ward", "male ward", 1);
            Room femaleWard = new Room("in the female ward", "female ward");
            Room maleShowers = new Room("in the male showers", "male showers");
            Room femaleShowers = new Room("in the female showers", "female showers");
            Room maleGame = new Room("in male game room", "male game room");
            Room femaleGame = new Room("in female game room", "female game room");
            Room hallway = new Room("in the hallway outside the male ward", "male ward hallway");
            Room lounge = new Room("in the guy's lounge", "male lounge");
            Room maleTherapy = new Room("in the therapy room", "male therapy room");
            Room femaleTherapy = new Room("in female ward therapy room", "female therapy room");
            Room alley = new Room("outside in the alley", "alley");
            Room kitchen = new Room("in the kitchen", "kitchen");
            Room mainCourtYard = new Room("outside in main courtyard", "main courtyard");
            Room westCourtYard = new Room("in west courtyard", "west courtyard");
            Room eastCourtYard = new Room("in east courtyard", "east courtyard");
            Room shed = new Room("in the shed", "shed");

            Door door = Door.createDoor(entrance, merch);
            door = Door.createDoor(entrance, mainHall);
            door.Closed = true;
            door.Lock();
            door = Door.createDoor(mainHall, maleWard);
            door.Closed = true;
            door.Lock();
            door = Door.createDoor(mainHall, femaleWard);
            door.Closed = true;
            door.Lock();
            door = Door.createDoor(mainHall, cafeteria);
            door.Closed = true;
            door.Lock();
            door = Door.createDoor(maleWard, maleGame);
            door = Door.createDoor(maleWard, maleShowers);
            door = Door.createDoor(maleWard, hallway);
            door = Door.createDoor(hallway, lounge);
            door = Door.createDoor(hallway, maleTherapy);
            door = Door.createDoor(femaleWard, femaleGame);
            door = Door.createDoor(femaleWard, femaleShowers);
            door = Door.createDoor(femaleWard, femaleTherapy);
            //need to create this door as task, will say it's a window. 
            //door = Door.createDoor(femaleTherapy, alley);
            door = Door.createDoor(cafeteria, kitchen);
            door = Door.createDoor(kitchen, alley);
            door = Door.createDoor(cafeteria, mainCourtYard);
            door = Door.createDoor(mainCourtYard, westCourtYard);
            door = Door.createDoor(mainCourtYard, eastCourtYard);
            door = Door.createDoor(eastCourtYard, shed);
            //door.Closed = true;
            //door.Lock();

            //Rooms that have doors that need to be unlocked. 
            gameBeginTrigger = entrance;
            firstTaskFinished = mainHall;
            bossBattleDoor = eastCourtYard;

            merch.addNPC(new Merchant(merch));

            //Testing if items placed in room correctly. 
            entrance.giveItem(new frag());
            entrance.giveItem(new Bat());
            entrance.giveItem(new AttackMegaBoost());

            maleShowers.giveItem(new Key());
            

            return entrance;
        }


        /**callback method for player speak word, will be able to use for player answering riddles in tasks
         * @params: Notification from class stating the player has spoken. 
         **/
        public void playerSpeak(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (player.currentRoom == null)
            {
                Dictionary<String, Object> userInfo = notification.userInfo;
                Console.WriteLine(notification.Name);
            }
        }


        /**This method is callback method from player entering a room, it will initiate and conduct a battle
        *between a player and randomly generated enemy.
        * @params: Notification from the player that they have entered a new room and require a possible new battle sequence.
        **/
        public void battleSequence(Notification notification)
        {
            Player player = (Player)notification.Object;

            if (player.currentRoom == bossBattleDoor)
            {
                NotificationCenter.Instance.postNotification(new Notification("PushBattleCommands", this));
                IEnemy enemy = new FinalBoss();
                player.currentRoom.CurrentEnemy = enemy;
                Console.WriteLine("\n****************************************************");
                Console.WriteLine("\n" + enemy.battleGreeting() + "\n\nThe final battle begins!\n");
                player.currentStats();
                enemy.currentStats();
            }

            else if (player.currentRoom.ChanceEnemy != 0)
            {
                player.currentRoom.getAnEnemy(player.Level);

                if (player.currentRoom.CurrentEnemy != null)
                {
                    //First Battle placed here so that player always notified by the game world how to fight. 
                    NotificationCenter.Instance.postNotification(new Notification("FirstBattle", this));
                    NotificationCenter.Instance.postNotification(new Notification("PushBattleCommands", this));
                    IEnemy enemy = player.currentRoom.CurrentEnemy;
                    player.PlayerState = PlayerState.InBattle;
                    Console.WriteLine("\n****************************************************");
                    Console.WriteLine("\n" + enemy.battleGreeting() + "\n\nThe battle begins!\n");
                    player.currentStats();
                    enemy.currentStats();
                }
            }
        }
        /**callback method to the game world, notifies that battle is over and allows the players level and stats be
        *increased as well as the dead enemy give items to the room and coins to the player before dying.
        * @params: Notiication from the player that the battle is over. 
        **/
        public void BattleOver(Notification notification)
        {
            Player player = (Player)notification.Object;
            IEnemy enemy = player.currentRoom.CurrentEnemy;
            player.outputMessage("\nYou win!!!\n");
            player.LevelUp(enemy.PlayerExp);
            player.outputMessage("You gained " + enemy.PlayerExp + " experience"
                + "\n\t" + player.expToNextLvl() + " exp to next level!" +
                "\n\t You earned " + enemy.KillValue + " coins!!");
            player.outputMessage("\n****************************************************");
            enemy.deadEnemyItems(player.currentRoom);
            player.receiveCoins(enemy.KillValue);
            player.currentRoom.CurrentEnemy = null;
            player.PlayerState = PlayerState.Wandering; 
            
            NotificationCenter.Instance.postNotification(new Notification("PopCommands"));
            NotificationCenter.Instance.postNotification(new Notification("KilledEnemies",player));
        }

        /**Player enter room with NPC for first time, lets the player know how to interact with them. 
        * @params: Notification from the current player that they have entered their first room with an NPC. 
        **/
        public void EnteredNpcRoom(Notification notification)
        {
            Console.WriteLine("\n****************************************************");
            Console.WriteLine("To interact with NPC's type \"interact\" and then the name of the NPC");
            Console.WriteLine("****************************************************");
            NotificationCenter.Instance.removeObserver("EnteredNpcRoom", EnteredNpcRoom);
        }

        /** 
        *Notifies the gameworld to unlock the main hall to allow the player to advance since they have now spoke
        * with the merchant.
        * @params: Notification from the merchant that the have spoke to the current player. 
        **/
        public void SpokeToMerchant(Notification notification)
        {
            Door door = gameBeginTrigger.getExit("main hall");
            door.Unlock();
            door.Closed = false;
            Console.WriteLine("****************************************************");
            Console.WriteLine("The main hall door has been unlocked!!");
            Console.WriteLine("****************************************************");
            NotificationCenter.Instance.removeObserver("SpokeToMerchant", SpokeToMerchant);
        }

        /**
         * Notification from the first task HowToPlay that the current player has completed it. Opens more locked doors
         * for continued exploration by the player. 
         * @params: Notification from the HowToPlay task. 
         **/
        public void FinishedFirstTask (Notification notification)
        {
            Door door;
            string splitter = firstTaskFinished.getExits();
            string[] exits = splitter.Split(","); 
            foreach(string room in exits)
            {
                splitter = room.TrimStart();
                door = firstTaskFinished.getExit(splitter);
                if (door.isLocked())
                {
                    door.Unlock();
                    door.Closed = false;
                }
            }
            Console.WriteLine("****************************************************\n" +
                "You can now explore the PsychWard further!\n"
                + "****************************************************\n");
        }

    }
}
