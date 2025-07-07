using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattleW
{
    internal class Battle
    {
        public static int activePokemonId1;
        public static int activePokemonId2;
        public static void Attack(Pokemon attacker, Pokemon defender, int activePlayer)
        {
            if (defender.Health > 0)
            {
                Random rng = new Random();
                int A = rng.Next(0, attacker.Attack + 1);
                int D = rng.Next(0, attacker.Defence + 1);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Играч {activePlayer} H:{attacker.Health} A:{A} ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"/ D:{D} H:{defender.Health}");
                Console.ResetColor();
                Console.WriteLine(); // optional line break

                if (A > D)
                {
                    int damage = A - D;
                    defender.Health = Math.Max(0, defender.Health - damage);
                    Console.WriteLine($"Играч {activePlayer} / {attacker.Name} нанесе щета на {defender.Name} | {defender.Health + damage}-{damage} ");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Играч {activePlayer} / {attacker.Name} не нанесе щета (D >= A)");
                    Console.WriteLine();
                }
            }

            if (defender.Health <= 0)
            {
                Console.WriteLine($" Pokemona {defender.Name} umrq");
                Console.WriteLine();


                if (Pokemon.pokemoni1[activePokemonId1].ID == defender.ID)
                {
                    Pokemon.pokemoni1.RemoveAt(activePokemonId1);

                }
                if (Pokemon.pokemoni2[activePokemonId2].ID == defender.ID)
                {
                    Pokemon.pokemoni2.RemoveAt(activePokemonId2);
                }
                //Game.izbora();
            }

        }

    }
}