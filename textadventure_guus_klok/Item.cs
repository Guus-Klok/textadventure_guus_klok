using System;
using System.Collections.Generic;
using System.Text;

namespace ZuulCS
{
    public class Item
    {
        protected string name;
        protected string description;

        public Item()
        {
            name = "";
            description = "";
        }

        public virtual void Use()
        {
            //dostuff
        }

    }
}
