using System;
using System.Collections.Generic;
using System.Text;

namespace ZuulCS
{
    class Inventory
    {
        public uint CheckInventory;
        private List<Item> contents = new List<Item>();
        internal List<Item> Contents { get => contents; }

        public Inventory()
        {

        }
        /*
        public void Grab(Item item)
        {
            contents.Add(item);
            if (HasItems())
            {
                Console.WriteLine("Picked up " + item);
            }
        }
        */

        public void GrabItem(Item item)
        {
            contents.Add(item);
        }

        public Item GrabItem(int index)
        {
            return contents[index];
        }

        private bool HasItems()
        {
            if (contents.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
    }
}
