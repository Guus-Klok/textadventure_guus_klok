using System;
using System.Collections.Generic;
using System.Text;

namespace textadventure_guus_klok
{
    class Inventory
    {
        public uint CheckInventory;

        private List<Item> contents = new List<Item>();
        
        public void Add(Item item)
        {
            contents.Add(item);
        }

        public void Remove(Item item)
        {
            contents.Remove(item);
        }

        public Item GetItem(int index)
        {
            return contents[index];
        }

        public void Grab(Item item)
        {
            if (HasItems())
            {
               Console.WriteLine("Picked up " + item);
            }
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
