﻿using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class GameWorld
    {
        static private GameWorld _instance;
        static public GameWorld Instance {
            get {
                if (_instance == null)
                    _instance = new GameWorld();
                return _instance;
            }
        }
        private Room _entrance;
        public Room Entrance { get { return _entrance; } }
        private Room trigger;
        private string triggerWord;
        private List<Room> hotList;
        private Merchant ladyMerchant;
        //public Merchant LadyMerchant { get; }

        private GameWorld()
        {
            hotList = new List<Room>();
            _entrance = createWorld();
            // GameWorld subscribes to the notification PlayerEnteredRoom
            NotificationCenter.Instance.addObserver("PlayerEnteredRoom", playerEnteredRoom);
            NotificationCenter.Instance.addObserver("Player has spoken", playerSpeak);
            NotificationCenter.Instance.addObserver("BattleSequence", battleSequence);
        }

        private Room createWorld()
        {
            Room entrance = new Room(" at the entrance of the PsychWard", "entrance");
            Room merch = new Room("in the merchant's room", "merchant room");
            Room mainHall = new Room("in the main hall", "main hall",3);
            Room cafeteria = new Room("in the cafeteria", "cafeteria");
            Room maleWard = new Room("in the male ward", "male ward");
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
            door = Door.createDoor(mainHall, maleWard);
            door = Door.createDoor(mainHall, femaleWard);
            door = Door.createDoor(mainHall, cafeteria);
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

            ladyMerchant = new Merchant(merch);
            HowToPlay task1 = new HowToPlay(mainHall);
            ladyMerchant.addTask(task1);

            return entrance;
        }

        
        

        // callback method for PlayerEnteredRoom
        public void playerEnteredRoom(Notification notification)
        {
            Player player = (Player)notification.Object;

            //Notifies the merchant when a player enters the room, a task is set by the merchant. The player
            //is notified that they have received a task. An updated set of commands are given if they player 
            //interacts with the merchant. 
            if (player.currentRoom == ladyMerchant.MerchantRoom)
            {
                NotificationCenter.Instance.postNotification(new Notification("EnteredMerchantRoom", this));
                if (player.CurrentTask == null || player.CurrentTask.Complete == true)
                {
                    player.setCurrentTask(ladyMerchant.TaskList.Dequeue());
                    NotificationCenter.Instance.postNotification(new Notification("TaskSet", this));
                }
                //Need to put an option to interact with merchant to allow buy/sell commands
                Console.WriteLine("\n\nHere's an updated set of commands: ");
                Console.WriteLine(new CommandWords().description(CommandType.MerchantCommand));   
            }

        }
        
        //callback method for player speak word
        public void playerSpeak(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (player.currentRoom == ladyMerchant.MerchantRoom)
            {
                Dictionary<String, Object> userInfo = notification.userInfo;
                Console.WriteLine(notification.Name);
            }
        }

        //This method is callback method from player entering a room, it will initiate and conduct a battle
        //between a player and randomly generated enemy.
        public void battleSequence(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (player.currentRoom.ChanceEnemy != 0)
            {
                IEnemy enemy = Room.getAnEnemy(player);
                if (enemy != null)
                {
                    player.InBattle = true;
                    Console.WriteLine("\n****************************************************");
                    Console.WriteLine("\n" + enemy.battleGreeting() + "\nThe battle begins!");
                    Console.WriteLine("\nHere are your battle commands: \n" +
                        new CommandWords().description(CommandType.BattleCommand));
                    while (player.InBattle)
                    {
                        //This will change the commands available for the sake of battle. 
                        CommandWords commands = new CommandWords();
                        commands.setBattleCommands();
                        Parser parser = new Parser(commands);
                        Console.WriteLine("Choose a command!");
                        Console.Write("\n>");
                        Command command = parser.parseCommand(Console.ReadLine());
                        while (command == null)
                        {
                            Console.WriteLine("I don't understand...");
                            command = parser.parseCommand(Console.ReadLine());
                        }
                        player.InBattle = command.execute(player);
                    }
                }
            }
        }

    }
}
