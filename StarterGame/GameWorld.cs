using System.Collections;
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
        private Room connectionRoom;
        private List<Room> hotList;
        private Merchant ladyMerchant;

        private GameWorld()
        {
            hotList = new List<Room>();
            _entrance = createWorld();
            // GameWorld subscribes to the notification PlayerEnteredRoom
            NotificationCenter.Instance.addObserver("PlayerEnteredRoom", playerEnteredRoom);
            NotificationCenter.Instance.addObserver("Player has spoken", playerSpeak);
        }

        private Room createWorld()
        {
            Room entrance = new Room(" at the entrance of the PsychWard", "entrance");
            Room merch = new Room("in the merchant's room", "merchant room");
            Room mainHall = new Room("in the main hall", "main hall");
            Room cafeteria = new Room("in the cafeteria", "cafeteria");
            Room maleWard = new Room("in the male ward", "male ward");
            Room femaleWard = new Room("in the female ward", "female ward");
            Room maleShowers = new Room("in the male showers", "male showers");
            Room femaleShowers = new Room("in the female showers", "female showers");
            Room maleGame = new Room("in male game room", "male game room");
            Room femaleGame = new Room("in female game room", "female game room");
            Room hallway = new Room("in the hallway outside the male ward", "male ward hallway");
            Room maleMeetingRoom = new Room("in the male's meeting room", "male meeting room");
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
            door = Door.createDoor(hallway, maleMeetingRoom);
            door = Door.createDoor(hallway, maleTherapy);
            door = Door.createDoor(femaleWard, femaleGame);
            door = Door.createDoor(femaleWard, femaleShowers);
            door = Door.createDoor(femaleWard, femaleTherapy);
            door = Door.createDoor(femaleTherapy, alley);
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
            if(player.currentRoom == trigger)
            {
                Console.WriteLine("Player entered the trigger room\n");
            }
            /*if (hotList.Count > 0 && hotList[0] == player.currentRoom)
            {
                hotList.Remove(player.currentRoom);
                if (hotList.Count == 0)
                {
                    player.outputMessage("\nAll the rooms have been visited!>>>\n");
                }
                
            }*/
            if (player.currentRoom == ladyMerchant.MerchantRoom)
            {
                Console.WriteLine("\nYou have entered the Merchants room\n");
            }

                       
        }
        
        //callback method for player speak word
        public void playerSpeak(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (player.currentRoom == trigger)
            {
                Dictionary<String, Object> userInfo = notification.userInfo;
                Console.WriteLine(notification.Name);
                //String word = (String)userInfo["boom"];
                //Console.WriteLine(userInfo.Keys);
                

            }
        }
    }
}
