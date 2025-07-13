using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattleW
{
    internal class Battle
    {
        public static void Attack(Players Player, Players Opponent)
        {
            if (Opponent.Pokemon.Health > 0)
            {
                Random rng = new Random();
                int Attack = rng.Next(0, Player.Pokemon.Attack + 1);
                int Deffence = rng.Next(0, Player.Pokemon.Defence + 1);

                if (Attack > Deffence)
                {
                    int damage = Attack - Deffence;
                    int previousHealth = Opponent.Pokemon.Health;
                    Opponent.Pokemon.Health = Math.Max(0, Opponent.Pokemon.Health - damage);
                    Console.WriteLine($"{Game.cyan}{Player.Pokemon.Name} нанесе щета на {Opponent.Pokemon.Name}{Game.reset} | {Game.red}{Game.red}{previousHealth}-{damage} {Game.reset}");
                    Console.WriteLine();
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{Game.cyan}{Player.Pokemon.Name} не нанесе щета (D >= A){Game.reset}");
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }

            if (Opponent.Pokemon.Health <= 0)
            {
                Console.WriteLine($"{Game.cyan}>-----*Покемонът {Opponent.Pokemon.Name} умря *-----<{Game.reset}");
                Opponent.Pokemon.IsAlive = false;

                if (Opponent.Pokemons.Contains(Opponent.Pokemon))
                {
                    Opponent.Pokemons.Remove(Opponent.Pokemon);
                    if (Opponent.Pokemons.Count > 0)
                    {
                        Game.ChoosePokemon(Opponent);
                        Console.WriteLine($">-------* {Opponent.Name} Избра {Opponent.Pokemon.Name}. Играта продължава *-------<\n");
                    }
                }
            }
        }

        public static void RegenerateHealth(Players activePlayer)
        {
            Console.WriteLine($"{activePlayer.Color}---------------| {activePlayer.Name} *-----> {activePlayer.Pokemon.Name} | {Game.reset} HP: {activePlayer.Pokemon.Health}");

            foreach (var pokemon in activePlayer.Pokemons)
            {
                int previousHealth = pokemon.Health;

                if (pokemon.IsAlive && activePlayer.Pokemons.IndexOf(pokemon) != activePlayer.PID)
                {
                    if (pokemon.Health < 100)
                    {
                        pokemon.Health += pokemon.Strength / 10;
                        if (pokemon.Health >= 100) pokemon.Health = 100;
                        Console.WriteLine($"{Game.slightGreen}{pokemon.Name} | HP: {pokemon.Health} {Game.reset} ({previousHealth}+{pokemon.Strength / 10})");
                    }
                    else
                    {
                        pokemon.Health = 100;
                        Console.WriteLine($"{pokemon.Name} HP: MAX");
                    }
                }
            }
        }
    }
}