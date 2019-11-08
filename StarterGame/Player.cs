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
        private ITask currentTask; 
        public ITask CurrentTask { get { return currentTask; } }
        private bool inBattle; 
        //The in battle status will allow us to know when certain commands should be available and not available.
        //Look at help command for example. 
        public bool InBattle { get { return inBattle; } set { inBattle = value; } }

        public Player(Room room)//, GameOutput output)
        {
            _currentRoom = room;
            currentTask = null;
            NotificationCenter.Instance.addObserver("TaskSet", TaskSet);
        }

        public void waltTo(string direction)
        {
            Door door = this._currentRoom.getExit(direction);
            if (door != null)
            {
                this._currentRoom = door.room(this.currentRoom);
                // Player posts a notification PlayerEnteredRoom
                this.outputMessage("\n" + this._currentRoom.description());
                NotificationCenter.Instance.postNotification(new Notification("PlayerEnteredRoom", this));
                
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

        public void TaskSet(Notification notification)
        {
             Console.WriteLine("\nA task has been set! (You can view the task description with the \"task\" command");
            
        }

        public void setCurrentTask(ITask task)
        {
           
                this.currentTask = task;
            
        }

        public void outputMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

}
