using System;

namespace DungeonStats
{
    public class Program
    {
        private static void Main(string[] args)
        {
        
        }

        private static int Damage(int attack, int defense)
        {
            int stat = attack - defense;

            if (stat > 0)
            {
                return stat;
            }
            else
            {
                return 0;
            }
        }

        private static int Damage(int attack)
        {
            if (attack > 0)
            {
                return attack;
            }
            else
            {
                return 0;
            }
        }

        private static int CriticalHit(int damage)
        {
            if (damage <= 0)
            {
                return 0;
            }
            else
            {
                return damage + CriticalHit(damage - 1);
            }

        }
    }
}
