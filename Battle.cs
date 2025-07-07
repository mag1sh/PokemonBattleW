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

        public static void ChoosePokemon()
        {
            Pokemon.DisplayPokemonsOfPlayer1();
            Console.Write("Играч 1 избери своя покемон:");
            activePokemonId1 = int.Parse(Console.ReadLine()) - 1;
            Console.ForegroundColor = ConsoleColor.Blue;
            //Console.Write("\x1b[38;2;217;117;177m");
            Console.WriteLine($"Играч 1 избра покемон {Pokemon.pokemoni1[activePokemonId1].Name}\n");
            //Console.Write("\x1b[0m");
            Console.ResetColor();

            Pokemon.DisplayPokemonsOfPlayer2();
            Console.Write("Играч 2 избери своя покемон:");
            activePokemonId2 = int.Parse(Console.ReadLine()) - 1;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"Играч 2 избра покемон {Pokemon.pokemoni2[activePokemonId2].Name}");
            Console.ResetColor();
        }


        public static void AttackPlayer1()
        {
            int min = 0;

            int max = Pokemon.pokemoni1[activePokemonId1].Attack;

            Random attack = new Random();
            int A = attack.Next(min, max + 1);
            int maxD = Pokemon.pokemoni1[activePokemonId1].Defence;

            Random defense = new Random();
            int D = defense.Next(min, maxD + 1);

            if(A > D) 
            {
                Pokemon.pokemoni2[activePokemonId2].Health -= A-D;
            }
            else if(D > A)
            {
                Console.WriteLine("Играч 1 не нанесе щета (D => A)");
                Console.WriteLine(Pokemon.pokemoni2[activePokemonId2].Health);
            }
        }

        public static void AttackPlayer2()
        {
            int min = 0;

            int max = Pokemon.pokemoni2[activePokemonId2].Attack;

            Random attack = new Random();
            int A = attack.Next(min, max + 1);
            int maxD = Pokemon.pokemoni2[activePokemonId2].Defence;

            Random defense = new Random();
            int D = defense.Next(min, maxD + 1);

            if (A > D)
            {
                Pokemon.pokemoni1[activePokemonId1].Health -= A - D;
            }
            else
            {
                Console.WriteLine("Играч 2 не нанесе щета (D => A)");
                Console.WriteLine(Pokemon.pokemoni1[activePokemonId1].Health);
            }
        }


    }
}
