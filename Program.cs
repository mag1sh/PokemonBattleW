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

            Battle.activePokemonId1 = Game.ChoosePokemon(1, Pokemon.pokemoni1[Battle.activePokemonId1].Name);
            Battle.activePokemonId2 = Game.ChoosePokemon(2, Pokemon.pokemoni2[Battle.activePokemonId2].Name);
            //Pokemon.DisplayPokemonsOfPlayer1();
            //Pokemon.DisplayPokemonsOfPlayer2();
            while (true)
            {
                Game.izbora(Pokemon.pokemoni1[Battle.activePokemonId1], Pokemon.pokemoni2[Battle.activePokemonId2], "Играч 1");
                Game.izbora(Pokemon.pokemoni2[Battle.activePokemonId2], Pokemon.pokemoni1[Battle.activePokemonId1], "Играч 2");
            }
            Console.ReadLine();
        }
    }
}
