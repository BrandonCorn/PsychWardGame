using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class Player
    {
        private Room _currentRoom = null;
        public Room currentRoom
        {
            get
            {
                return _currentRoom;
            }
            set
            {
                _currentRoom = value;
            }
        }

        public Player(Room room)//, GameOutput output)
        {
            _currentRoom = room;
        }

        public void waltTo(string direction)
        {
            Door door = this._currentRoom.getExit(direction);
            if (door != null)
            {
                this._currentRoom = door.room(this.currentRoom);
                // Player posts a notification PlayerEnteredRoom
                NotificationCenter.Instance.postNotification(new Notification("PlayerEnteredRoom", this));
                this.outputMessage("\n" + this._currentRoom.description());
            }
            else
            {
                this.outputMessage("\nThere is no door on " + direction);
                this.outputMessage("\n" + this._currentRoom.description());
            }
        }

        public void speak(String word)
        {
            outputMessage(word);
            NotificationCenter.Instance.postNotification(new Notification("Player has spoken", this));
        }

        public void outputMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

}
