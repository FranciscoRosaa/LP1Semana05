using System;
using Spectre.Console;

namespace DungeonStats
{
    public class Program
    {
        private static void Main(string[] args)
        {
            int attack = 0;
            int defense = 2;

            if (args.Length >= 1)
            {
                if (int.TryParse(args[0], out int parsedAttack))
                {
                    attack = parsedAttack;
                }
            }

            if (args.Length >= 2)
            {
                if (int.TryParse(args[1], out int parsedDefense))
                {
                    defense = parsedDefense;
                }
            }

            var table = new Table();
            table.AddColumn("Operation");
            table.AddColumn(new TableColumn("Result").RightAligned());

            table.AddRow($"Damage({attack})", Damage(attack).ToString());
            table.AddRow($"Damage({attack}, {defense})", Damage(attack, defense).ToString());
            table.AddRow($"CriticalHit({Damage(attack, defense)})", CriticalHit(Damage(attack, defense)).ToString());

            AnsiConsole.Write(table);
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
