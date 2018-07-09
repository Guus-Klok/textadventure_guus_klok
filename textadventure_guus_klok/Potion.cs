using System;

namespace ZuulCS
{
    public class Potion : Item
    {
        public Potion()
        {

        }
        public void HealthBoost(uint amount, Player player)
        {
            player.health += 20;
            name = "Super Potion";
            description = "It's a potion that gives you more health";
        }
    }
}