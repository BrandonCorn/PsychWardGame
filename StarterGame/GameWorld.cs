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
        private Room connectionRoom;
        private List<Room> hotList;

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
            Room outside = new Room("outside the main entrance of the university", "outside");
            Room cctparking = new Room("in the parking lot at CCT", "CCT Parking");
            Room boulevard = new Room("on the boulevard", "boulevard");
            Room universityParking = new Room("in the parking lot at University Hall", "University Hall Parking");
            Room parkingDeck = new Room("in the parking deck", "Parking Deck");
            Room cct = new Room("in the CCT building", "CCT");
            Room theGreen = new Room("in the green in from of Schuster Center", "The Green");
            Room universityHall = new Room("in University Hall","University Hall");
            Room schuster = new Room("in the Schuster Center", "Schuster");

            //outside.setExit("west", outsideBoulevard);
            //boulevard.setExit("east", outsideBoulevard);

            Door door = Door.createDoor(outside, boulevard);
            //boulevard.setExit("south", cctparking);
            //cctparking.setExit("north", boulevard);

            door = Door.createDoor(boulevard, theGreen);
            //boulevard.setExit("west", theGreen);
            //theGreen.setExit("east", boulevard);

            door = Door.createDoor(universityParking, boulevard);
            //boulevard.setExit("north", universityParking);
            //universityParking.setExit("south", boulevard);

            door = Door.createDoor(cct, cctparking);
            //cctparking.setExit("west", cct);
            //cct.setExit("east", cctparking);

            door = Door.createDoor(schuster, cct);
            //cct.setExit("north", schuster);
            //schuster.setExit("south", cct);

            door = Door.createDoor(universityHall, schuster);
            //schuster.setExit("north", universityHall);
            //universityHall.setExit("south", schuster);

            door = Door.createDoor(theGreen, schuster);
            //schuster.setExit("east", theGreen);
            //theGreen.setExit("west", schuster);

            door = Door.createDoor(universityParking, universityHall);
            //universityHall.setExit("east", universityParking);
            //universityParking.setExit("west", universityHall);

            door = Door.createDoor(universityParking, parkingDeck);
            //universityParking.setExit("north", parkingDeck);
            //parkingDeck.setExit("south", universityParking);

            connectionRoom = schuster;
            trigger = parkingDeck;

            hotList.Add(parkingDeck);
            hotList.Add(universityHall);
            hotList.Add(cct);
            return outside;
        }

        //Create door
        

        // callback method for PlayerEnteredRoom
        public void playerEnteredRoom(Notification notification)
        {
            Player player = (Player)notification.Object;
            if(player.currentRoom == trigger)
            {
                Console.WriteLine("Player entered the trigger room");
            }
            if (hotList.Count > 0 && hotList[0] == player.currentRoom)
            {
                hotList.Remove(player.currentRoom);
                if (hotList.Count == 0)
                {
                    player.outputMessage("\nAll the rooms have been visited!>>>\n");
                }
                
            }
        }
        
        //callback method for player speak word
        public void playerSpeak(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (player.currentRoom == trigger)
            {
                Dictionary<String, Object> userInfo = notification.userInfo;
                String word = (String)userInfo["word"];

            }
        }
    }
}
