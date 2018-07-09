using System;
using System.Collections.Generic;
using System.Text;

namespace ZuulCS
{
     public class Pokedex
    {
        private List<Pokemon> contents = new List<Pokemon>();
        internal List<Pokemon> Contents { get => contents; }

        public Pokedex()
        {

        }


        public void AddPokemon(Pokemon pokemon)
        {
            contents.Add(pokemon);
        }



        public bool HasPokemon()
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
