using System;
using System.Collections.Generic;

namespace ZuulCS
{
    public class Pokemon
    {
        protected List<string> moves;
        protected string Name;
        protected string type;
        protected int level;

        public Pokemon()
        {
            moves = new List<string>();
            Name = "Unnamed";
            type = "Undefined";
            level = 0;
  
        }
        public virtual void UseMove(string m)
        {
            //use one of the moves
        }


    }
}