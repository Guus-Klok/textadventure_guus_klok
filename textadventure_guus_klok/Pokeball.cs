using System;

namespace ZuulCS
{
    public class Pokeball : Item
    {
        private Player player;
        public Pokeball(Player p)
        {
            player = p;
        }

        public void catchPokemon(Pokemon p)
        {
            if (catched())
            {
                player.pokedex.AddPokemon(p);
            }
            else
            {
                Console.WriteLine("you didn't catch the pokemon");
            }
        }

        public bool catched()
        {
            if (RandomNumber(0, 3) <= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

    }
}