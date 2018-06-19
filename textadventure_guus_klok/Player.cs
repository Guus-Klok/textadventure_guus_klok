using System;
using ZuulCS;

namespace ZuulCS
{
    public class Player
    {
        public Room currentRoom;

        public Player()
        {

        }

        public Room CurrentRoom
        {
            get { return currentRoom; }
            set { currentRoom = value; }
        }


    }

}
