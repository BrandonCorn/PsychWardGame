using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class Player
    {
        private Room _currentRoom = null;
        public Room currentRoom { get { return _currentRoom; } set { _currentRoom = value; } }

        private int attack; 
        public int Attack { get { return attack;} set { attack = value; } }

        private int health; 
        public int Health { get { return health; } set { health = value; } }
        
        //Current Task is simply that, the task the player is currently trying to complete given by the merchant.
        private ITask currentTask; 
        public ITask CurrentTask { get { return currentTask; } }
        
        //The in battle status will allow us to know when certain commands should be available and not available.
        //Look at help command for example. 
        private bool inBattle; 
        public bool InBattle { get { return inBattle; } set { inBattle = value; } }

        public Player(Room room)//, GameOutput output)
        {
            _currentRoom = room;
            currentTask = null;
            attack = 6;
            health = 100; 
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
