using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattleW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pokemon.LoadPokemons();

            Battle.activePokemonId1 = Game.ChoosePokemon(1);
            Battle.activePokemonId2 = Game.ChoosePokemon(2);
            //Pokemon.DisplayPokemonsOfPlayer1();
            //Pokemon.DisplayPokemonsOfPlayer2();
            while (true)
            {
                Game.izbora(Pokemon.pokemoni1[Battle.activePokemonId1], Pokemon.pokemoni2[Battle.activePokemonId2], 1);
                Game.izbora(Pokemon.pokemoni2[Battle.activePokemonId2], Pokemon.pokemoni1[Battle.activePokemonId1], 2);
            }
            Console.ReadLine();
        }
    }

}