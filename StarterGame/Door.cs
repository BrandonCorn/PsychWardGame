using System;

namespace StarterGame
{

    public class Door
    {

        private Room roomA;
        private Room roomB;
        private bool closed;
        public bool Closed
        {
            get
            {
                return closed;
            }
            set
            {
                closed = value; 
            }
        }
        public bool Open
        {
            get
            {
                return !closed;
            }
            set
            {
                closed = !value;
            }
        }

       
        public Door(Room roomA, Room roomB)
        {
            this.roomA = roomA;
            this.roomB = roomB;
            closed = false;
            
        }

        public Room room(Room from)
        {
            if (roomA == from)
            {
                return roomB;
            }
            else
            {
                return roomA;
            }
        }

        public static Door createDoor(Room roomA, Room roomB)
        {
            Door door = new Door(roomA, roomB);
            roomA.setExit(roomB.shortName,door);
            roomB.setExit(roomA.shortName, door);
            return door;
        }

        public void Unlock(Object key)
        {
            //this will unlock the door if the correct key is possessed. 
        }
    }
}
