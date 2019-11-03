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
            Room entrance = new Room("entrance to PsychWard", "Entrance");
            Room merch = new Room("in the Merchant Room", "Merchant Room");
            Room mainHall = new Room("in the Main Hall", "Main Hall");
            Room cafeteria = new Room("in the Cafeteria", "Cafeteria");
            Room maleWard = new Room("in the Male Ward", "Male Ward");
            Room femaleWard = new Room("in the Female Ward", "Female Ward");
            Room maleShowers = new Room("in the Male Showers", "Male Showers");
            Room femaleShowers = new Room("in the Female Showers", "Female Showers");
            Room room1 = new Room("in male game room", "Male Game Room");
            Room room3 = new Room("in female game room", "Female Game Room");
            Room hallway = new Room("in the Hallway outside Male Ward", "Male Ward Hallway");
            Room room2 = new Room("in the Meeting Room", "Meeting Room");
            Room therapyRoom = new Room("in the therapyRoom", "Therapy Room");


            ladyMerchant = new Merchant(merch);
            HowToPlay task1 = new HowToPlay(mainHall);
            ladyMerchant.addTask(task1);

            return entrance;
        }

        //Create door
        

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
