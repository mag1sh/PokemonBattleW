using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PokemonBattleW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //new brach add comement


            Pokemon.LoadPokemons();
            Players Player = new Players(1);
            Players Opponent = new Players(2);

            // Принтиране на заглавие
            Console.WriteLine($"{Game.cyan}>------------------| POKEMON BATTLES W2 |-------------------< {Game.reset}\n");

            // Извиква метод за въвеждане на имената на двамата играчи
            Game.PlayerNaming(Player, Opponent);

            // Всеки играч избира с кой покемон да започне битката
            Game.ChoosePokemon(Player);
            Game.ChoosePokemon(Opponent);

            //Логиката
            Game.GameLogic(Player, Opponent);
            Console.ReadLine();
        }
    }
}
