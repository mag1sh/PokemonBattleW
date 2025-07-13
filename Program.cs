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
            Pokemon.LoadPokemons();
            Players Player = new Players(1);
            Players Opponent = new Players(2);

            Console.WriteLine($"{Game.cyan}>------------------| POKEMON BATTLES W2 |-------------------< {Game.reset}\n");

            Game.PlayerNaming(Player, Opponent);
            Game.ChoosePokemon(Player);
            Game.ChoosePokemon(Opponent);

            //Pokemon.DisplayPokemonsOfPlayer1();
            //Pokemon.DisplayPokemonsOfPlayer2();

            Game.GameLogic(Player, Opponent);
            Console.ReadLine();
        }
    }
}