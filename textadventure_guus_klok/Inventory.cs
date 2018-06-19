using System;
using System.Collections.Generic;
using System.Text;

namespace textadventure_guus_klok
{
    class Inventory
    {
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
    }
}
