using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattleW
{
    internal class Battle
    {
        // Метод за извършване на атака към противника
        public static void Attack(Players Player, Players Opponent)
        {
            // Проверка дали покемонът на противника е жив
            if (Opponent.Pokemon.Health > 0)
            {
                Random rng = new Random();

                // Генериране на случайни стойности за атака и защита
                int A = rng.Next(0, Player.Pokemon.Attack + 1);
                int D = rng.Next(0, Player.Pokemon.Defence + 1);

                // Ако атаката е по-силна от защитата, се нанася щета
                if (A > D)
                {
                    int damage = A - D;
                    int previousHealth = Opponent.Pokemon.Health;

                    // Намаляване на здравето на противниковия покемон
                    Opponent.Pokemon.Health = Math.Max(0, previousHealth - damage);
                    Console.WriteLine($"{Game.cyan}{Player.Pokemon.Name} нанесе щета на {Opponent.Pokemon.Name}{Game.reset} | {Game.red}{Game.red}{previousHealth}-{damage} {Game.reset}");
                    Console.WriteLine();
                    Console.ResetColor();
                }
                else
                {
                    // Атаката не е достатъчно силна, за да пробие защитата
                    Console.WriteLine($"{Game.cyan}{Player.Pokemon.Name} не нанесе щета (D >= A){Game.reset}");
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }

            // Ако покемонът на противника е с 0 живот, го премахваме от играта
            if (Opponent.Pokemon.Health <= 0)
            {
                Console.WriteLine($"{Game.red}>-----*Покемонът {Opponent.Pokemon.Name} умря *-----<{Game.reset}");
                Opponent.Pokemon.IsAlive = false;

                if (Opponent.Pokemons.Contains(Opponent.Pokemon))
                {
                    Opponent.Pokemons.Remove(Opponent.Pokemon);

                    //Ако останали покемони -> избор на нов активен покемон
                    if (Opponent.Pokemons.Count > 0)
                    {
                        Game.ChoosePokemon(Opponent);
                        Console.WriteLine($">-------*{Opponent.Name} избра {Opponent.Pokemon.Name}. Играта продължава *-------<\n");
                    }
                }
            }
        }

        //Метод за регенерация на здраве на всички неактивни покемони на играча
        public static void RegenerateHealth(Players activePlayer)
        {
            Console.WriteLine($"{activePlayer.Color}---------------| {activePlayer.Name} *-----> {activePlayer.Pokemon.Name} | {Game.reset} HP: {activePlayer.Pokemon.Health}");

            foreach (var pokemon in activePlayer.Pokemons)
            {
                int previousHealth = pokemon.Health;

                // Регенерира само живите и неактивни покемони
                if (pokemon.IsAlive && activePlayer.Pokemons.IndexOf(pokemon) != activePlayer.PokemonID)
                {
                    if (pokemon.Health < 100)
                    {
                        // Възстановява здравето на базата на силата
                        pokemon.Health += pokemon.Strength / 10;
                        if (pokemon.Health >= 100) pokemon.Health = 100;
                        Console.WriteLine($"{Game.slightGreen}{pokemon.Name} | HP: {pokemon.Health} {Game.reset} ({previousHealth}+{pokemon.Strength / 10})");
                    }
                    else
                    {
                        //Здравето вече е на максимум
                        pokemon.Health = 100;
                        Console.WriteLine($"{pokemon.Name} HP: MAX");
                    }
                }
            }
        }
    }
}