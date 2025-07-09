using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattleW
{
    internal class Game
    {
        public static void Igra()
        {
            while (true)
            {
                if (Pokemon.pokemoni1.Count > 0)
                {
                    Game.izbora(Pokemon.pokemoni1[Battle.activePokemonId1], Pokemon.pokemoni2[Battle.activePokemonId2], 1);
                }
                else
                {
                    Console.WriteLine("Играч 1 остана без покемони.");
                    Console.WriteLine("Играч 2 печели!");
                    break;
                }
                if (Pokemon.pokemoni2.Count > 0)
                {
                    Game.izbora(Pokemon.pokemoni2[Battle.activePokemonId2], Pokemon.pokemoni1[Battle.activePokemonId1], 2);
                }
                else
                {
                    Console.WriteLine("Играч 2 остана без покемони.");
                    Console.WriteLine("Играч 1 печели!");
                    break;
                }
            }
        }

        public static int ChoosePokemon(int activePlayer)
        {
            Pokemon.DisplayPokemonsOfPlayer(activePlayer);
            Console.Write($"Играч {activePlayer} избери своя покемон:");
            int id = int.Parse(Console.ReadLine()) - 1;
            Console.ForegroundColor = ConsoleColor.Blue;            
            if (activePlayer == 1)
            {
                Console.Write("\x1b[38;2;217;117;177m");
                Console.WriteLine($"Играч {activePlayer} избра покемон {Pokemon.pokemoni1[id].Name}");
                Console.WriteLine($"");
                Console.Write("\x1b[0m");
            }
            else if (activePlayer == 2)
            {
                Console.Write("\x1b[38;2;217;117;177m");
                Console.WriteLine($"Играч {activePlayer} избра покемон {Pokemon.pokemoni2[id].Name}");
                Console.WriteLine($"");
                Console.Write("\x1b[0m");
            }  
            Console.ResetColor();
            return id;
        }

        public static void izbora(Pokemon attacker, Pokemon defender, int activePlayer)
        {
            Console.WriteLine($"Играч {activePlayer} изберете следващия ви ход");
            Console.WriteLine("1.Атака");
            Console.WriteLine("2.Замяна на активния покемон с друг");
            Console.Write("Въведете вашия избор:");
            string choice = Console.ReadLine();
            Console.WriteLine($"");

            switch (choice)
            {
                case "1":
                    Battle.Attack(attacker, defender, activePlayer);
                    break;
                case "2":
                    if (activePlayer == 1) { Battle.activePokemonId1 = Game.ChoosePokemon(activePlayer); }
                    if (activePlayer == 2) { Battle.activePokemonId2 = Game.ChoosePokemon(activePlayer); }
                    break;
            }
        }
    }
}