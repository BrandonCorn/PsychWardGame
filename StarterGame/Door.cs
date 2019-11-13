using System;

namespace StarterGame
{

    public class Door
    {

        private Room roomA;
        private Room roomB;
        private bool locked;

       
        public Door(Room roomA, Room roomB)
        {
            this.roomA = roomA;
            this.roomB = roomB;
            
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
	    //Checking things.
        }


    }
}
