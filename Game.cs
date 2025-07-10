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

        public static void PlayerNaming()
        {
            Console.Write($"{purple}>---------------* Играч 1 избери си име:  {reset}");
            Battle.PlayerName[1] = Console.ReadLine();
            Console.Write($"");
            Console.Write($"{pink}>---------------* Играч 2 избери си име:  {reset}");
            Battle.PlayerName[2] = Console.ReadLine();
            Console.WriteLine("");
        }
        public static void GameLogic()
        {
            int br = 0;
            while (true)
            {
                if (Pokemon.pokemoni1.Count > 0)
                {
                    Console.WriteLine($"");
                    Console.WriteLine($"{cyan}---------------| ROUND {br} {reset}");
                    Console.WriteLine($"");
                    RegenerateHealth("1");

                    Game.izbora(Pokemon.pokemoni1[Battle.activePokemonId1], Pokemon.pokemoni2[Battle.activePokemonId2], 1);
                }
                else
                {
                    Console.WriteLine($"{Battle.PlayerName[1]} | остана без покемони");
                    Console.WriteLine($"|-----*-----| {Battle.PlayerName[1]} Спечели |-----*-----|");
                    break;
                }

                if (Pokemon.pokemoni2.Count > 0)
                {
                    RegenerateHealth("2");

                    Game.izbora(Pokemon.pokemoni2[Battle.activePokemonId2], Pokemon.pokemoni1[Battle.activePokemonId1], 2);
                }
                else
                {
                    Console.WriteLine($"{Battle.PlayerName[2]} | остана без покемони");
                    Console.WriteLine($"|-----*-----| {Battle.PlayerName[2]} Спечели |-----*-----|");
                    break;
                }
                br++;

                Console.WriteLine("Натиснете клавиш за следващия рунд...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public static void RegenerateHealth(string activePlayer)
        {
            List<Pokemon> pokemons;
            int activePokemonId;
            string playerName;
            string Color;

            if (activePlayer == "1")
            {
                pokemons = Pokemon.pokemoni1;
                activePokemonId = Battle.activePokemonId1;
                playerName = Battle.PlayerName[1];
                Color = purple;
            }
            else
            {
                pokemons = Pokemon.pokemoni2;
                activePokemonId = Battle.activePokemonId2;
                playerName = Battle.PlayerName[2];
                Color = pink;
            }

            Console.WriteLine($"{Color}---------------| {playerName} *-----> {pokemons[activePokemonId].Name} | {reset} HP: {pokemons[activePokemonId].Health}");
            foreach (var p in pokemons)
            {
                int previousHealth = p.Health;
                if (p.IsAlive && pokemons.IndexOf(p) != activePokemonId)
                {
                    if (p.Health < 100)
                    {
                        p.Health += p.Strength / 10;
                        if (p.Health >= 100)
                            p.Health = 100;

                        Console.WriteLine($"{slightGreen}{p.Name} | HP: {p.Health} {reset} ({previousHealth}+{p.Strength / 10})");
                    }
                    else
                    {
                        p.Health = 100;
                        Console.WriteLine($"{p.Name} HP: MAX");
                    }
                }
            }
        }
        public static int ChoosePokemon(int activePlayer)
        {
            Pokemon.DisplayPokemonsOfPlayer(activePlayer);
            Console.WriteLine($"");

            int id = 0;
            switch (activePlayer)
            {

                case 1:
                    Console.Write($"{purple}{Battle.PlayerName[activePlayer]} | избери своя покемон:{reset}");
                    id = int.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine($"{cyan}{Battle.PlayerName[activePlayer]} | избра покемон {Pokemon.pokemoni1[id].Name}{reset}");
                    Console.WriteLine($"");

                    break;

                case 2:
                    Console.Write($"{pink}{Battle.PlayerName[activePlayer]} | избери своя покемон:{reset}");
                    id = int.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine($"{cyan}{Battle.PlayerName[activePlayer]} | избра покемон {Pokemon.pokemoni2[id].Name}{reset}");
                    Console.WriteLine($"");

                    break;

            }
            Console.ResetColor();
            return id;
        }

        public static void izbora(Pokemon attacker, Pokemon defender, int activePlayer)
        {
            string color = "";

            if (activePlayer == 1) color = purple;
            if (activePlayer == 2) color = pink;

            Console.WriteLine("|-----------* 1.Атака  |  2.Замяна на покемон *-----------|");
            Console.WriteLine($"{color}----------------------------------------------------------|{reset}");
            Console.Write($">-------------* Изберете следващия ви ход:");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":

                    if (!defender.IsAlive || defender.Health <= 0)
                    {

                        if (activePlayer == 1 && Pokemon.pokemoni2.Contains(defender))
                        {
                            Pokemon.pokemoni2.Remove(defender);
                            // Ако има още живи покемони - избираме нов
                            if (Pokemon.pokemoni2.Count > 0)
                            {
                                Battle.activePokemonId2 = Game.ChoosePokemon(2);
                            }
                        }
                        else if (activePlayer == 2 && Pokemon.pokemoni1.Contains(defender))
                        {
                            Pokemon.pokemoni1.Remove(defender);
                            if (Pokemon.pokemoni1.Count > 0)
                            {
                                Battle.activePokemonId1 = Game.ChoosePokemon(1);
                            }
                        }
                    }

                    else
                    {
                        Battle.Attack(attacker, defender, activePlayer);
                    }
                    break;
                case "2":
                    ;
                    if (activePlayer == 1) { Battle.activePokemonId1 = Game.ChoosePokemon(activePlayer); }
                    if (activePlayer == 2) { Battle.activePokemonId2 = Game.ChoosePokemon(activePlayer); }

                    break;
            }
        }
        public static Pokemon CurrentTurnPokemon(int activePlayer)
        {
            switch (activePlayer)
            {
                case 1:
                    Battle.currentTurnPokemon = Pokemon.pokemoni1[Battle.activePokemonId1];
                    return Battle.currentTurnPokemon;
                    ;
                case 2:
                    Battle.currentTurnPokemon = Pokemon.pokemoni2[Battle.activePokemonId2];
                    return Battle.currentTurnPokemon;

                default: return Battle.currentTurnPokemon;
            }
        }
    }
}
