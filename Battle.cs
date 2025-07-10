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
        public static Pokemon currentTurnPokemon;
        public static Pokemon lastTurnPokemon;

        public static List<string> PlayerName = new List<string> { null, "Kowwai", "Mag1sh" };

        public static void Attack(Pokemon attacker, Pokemon defender, int activePlayer)
        {
            if (defender.Health > 0)
            {
                Random rng = new Random();
                int A = rng.Next(0, attacker.Attack + 1);
                int D = rng.Next(0, attacker.Defence + 1);

                if (A > D)
                {
                    int damage = A - D;
                    int previousHealth = defender.Health;
                    defender.Health = Math.Max(0, defender.Health - damage);
                    Console.WriteLine($"{Game.cyan}{attacker.Name} нанесе щета на {defender.Name}{Game.reset} | {Game.red}{Game.red}{previousHealth}-{damage} {Game.reset}");
                    Console.WriteLine();
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{Game.cyan}{attacker.Name} не нанесе щета (D >= A){Game.reset}");
                    Console.WriteLine();
                    Console.ResetColor();
                }

            }
            if (defender.Health <= 0)
            {
                Console.WriteLine($"{Game.cyan}>-----*Покемонът {defender.Name} умря *-----<{Game.reset}");
                defender.IsAlive = false;
                if (Pokemon.pokemoni1.Contains(defender))
                {
                    int index = Pokemon.pokemoni1.IndexOf(defender);
                    Pokemon.pokemoni1.Remove(defender);
                    if (Pokemon.pokemoni1.Count > 0)

                    Battle.activePokemonId1 = Game.ChoosePokemon(1);
                    Console.WriteLine($">-----* {PlayerName[1]} Избра нов покемон. Играта продължава *-----<");

                }
                else if (Pokemon.pokemoni2.Contains(defender))
                {
                    int index = Pokemon.pokemoni2.IndexOf(defender);
                    Pokemon.pokemoni2.Remove(defender);
                    if (Pokemon.pokemoni2.Count > 0)

                    Battle.activePokemonId2 = Game.ChoosePokemon(2);
                    Console.WriteLine($">-----* {PlayerName[2]} Избра нов покемон. Играта продължава *-----<");

                }
            }
        }
    }
}