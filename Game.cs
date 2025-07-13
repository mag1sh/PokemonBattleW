using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattleW
{
    internal class Game
    {
        public static string green = "\x1b[38;2;80;220;120m";
        public static string red = "\x1b[38;2;255;80;80m";
        public static string reset = "\x1b[0m";
        public static string pink = "\x1b[38;2;255;105;180m";
        public static string purple = "\x1b[38;2;180;100;255m";
        public static string cyan = "\x1b[38;2;80;230;255m";
        public static string slightGreen = "\x1b[38;2;140;220;140m";

        public static void PlayerNaming(Players Player, Players Opponent)
        {
            Console.Write($"{purple}>---------------* Играч 1 избери си име: {reset}");
            Player.Name = Console.ReadLine();
            Console.Write($"");
            Console.Write($"{pink}>---------------* Играч 2 избери си име: {reset}");
            Opponent.Name = Console.ReadLine();
            Console.WriteLine("");
        }

        public static void GameLogic(Players Player, Players Opponent)
        {
            int br = 1;
            while (true)
            {
                Console.WriteLine($"");
                Console.WriteLine($"{cyan}---------------| ROUND {br} {reset}");
                Console.WriteLine($"");

                if (Player.Pokemons.Count > 0)
                {
                    Battle.RegenerateHealth(Player);
                    Game.izbora(Player, Opponent);
                }
                else
                {
                    Console.WriteLine($"{Player.Name} | остана без покемони");
                    Console.WriteLine($"{Opponent.Color}|-----*-----| {Opponent.Name} Спечели |-----*-----|{reset}");
                    break;
                }

                if (Opponent.Pokemons.Count > 0)
                {
                    Battle.RegenerateHealth(Opponent);
                    Game.izbora(Opponent, Player);
                }
                else
                {
                    Console.WriteLine($"{Opponent.Name} | остана без покемони");
                    Console.WriteLine($"{Player.Color}|-----*-----| {Player.Name} Спечели |-----*-----|{reset}");
                    break;
                }
                br++;

                Console.WriteLine("Натиснете клавиш за следващия рунд...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void izbora(Players Player, Players Opponent)
        {
            Console.WriteLine("|-----------* 1.Атака  |  2.Замяна на покемон *-----------|");
            Console.WriteLine($"{Player.Color}----------------------------------------------------------|{reset}");
            Console.Write($">-------------* Изберете следващия ви ход:");

            int izbora = ReadIntInRange($"", 1, 2);

            switch (izbora)
            {
                case 1:
                    if (!Opponent.Pokemon.IsAlive || Opponent.Pokemon.Health <= 0)
                    {
                        if (Opponent.Pokemons.Contains(Opponent.Pokemon))
                        {
                            Opponent.Pokemons.Remove(Opponent.Pokemon);

                            if (Opponent.Pokemons.Count > 0)
                            {
                                Game.ChoosePokemon(Opponent);
                                Battle.Attack(Player, Opponent);
                            }
                        }
                    }
                    else
                    {
                        Battle.Attack(Player, Opponent);
                    }
                    break;

                case 2:                    
                    Game.ChoosePokemon(Player);
                    break;
            }
        }
    
        public static void ChoosePokemon(Players activePlayer)
        {
            Pokemon.DisplayPokemonsOfPlayer(activePlayer);
            Console.WriteLine("");

            activePlayer.PID = ReadIntInRange($"{activePlayer.Color} {activePlayer.Name} | избери своя покемон:{reset}", 1, activePlayer.Pokemons.Count) - 1;
            activePlayer.Pokemon = activePlayer.Pokemons[activePlayer.PID];
            Console.WriteLine($"{cyan}{activePlayer.Name} | избра покемон {activePlayer.Pokemon.Name}{reset}");
            Console.WriteLine("");
            Console.ResetColor();
        }

        public static int ReadIntInRange(string prompt, int min, int max)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out value) && value >= min && value <= max)
                {
                    return value;
                }
                Console.WriteLine($"{red}Моля, въведете число между {min} и {max}.{reset}");
            }
        }
    }
}
