using System;
using System.Collections.Generic;

namespace ZuulCS
{
    public class Darkkrai : Pokemon
    {
        public Darkkrai()
        {
            moves = new List<string>();
            Name = "Darkkrai";
            type = "Dark";
            level = 80;
  
        }
        public override void UseMove(string m)
        {
            //use one of the moves
        }


    }
}