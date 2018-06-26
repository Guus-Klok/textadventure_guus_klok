using System;
using ZuulCS;

namespace ZuulCS
{
    public class Player
    {
        public Room currentRoom;
        public uint health = 100;

        public Player()
        {

        }

        public Room CurrentRoom
        {
            get { return currentRoom; }
            set { currentRoom = value; }
        }

        public void Damage(uint amount)
        {
            health -= amount;
        }

        public void Heal(uint amount)
        {
            health += amount;
        }

        public void IsAlive() {

            if (health < 1)
            {
               Environment.Exit(0);
            }

        }

    }

}
