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
                Console.Write($"/ D:{D} H:{defender.Health}");
                Console.WriteLine();
                Console.ResetColor();
                
                if (A > D)
                {
                    int damage = A - D;
                    defender.Health = Math.Max(0, defender.Health - damage);
                    Console.WriteLine($"Играч {activePlayer} / {attacker.Name} нанесе щета на {defender.Name} | {defender.Health + damage}-{damage} ");
                    Console.WriteLine();
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"Играч {activePlayer} / {attacker.Name} не нанесе щета (D >= A)");
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }

            if (defender.Health <= 0)
            {
                Console.WriteLine($"Покемонът {defender.Name} умря.");

                if (Pokemon.pokemoni1.Contains(defender))
                {
                    int index = Pokemon.pokemoni1.IndexOf(defender);
                    Pokemon.pokemoni1.Remove(defender);
                    if (Pokemon.pokemoni1.Count > 0) Battle.activePokemonId1 = Game.ChoosePokemon(1);
                }
                else if (Pokemon.pokemoni2.Contains(defender))
                {
                    int index = Pokemon.pokemoni2.IndexOf(defender);
                    Pokemon.pokemoni2.Remove(defender);
                    if (Pokemon.pokemoni2.Count > 0) Battle.activePokemonId2 = Game.ChoosePokemon(2);
                }
            }
        }
    }
}