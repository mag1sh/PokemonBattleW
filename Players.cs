using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattleW
{
    internal class Players
    {
        public int PID;
        public string Color;
        public string Name;
        public List<Pokemon> Pokemons;
        public Pokemon Pokemon;

        public static List<int> PIDs = new List<int> { 0, 1, 1 };
        public static List<string> Colors = new List<string> { null, "\u001b[38;2;180;100;255m", "\u001b[38;2;255;105;180m" };
        public static List<string> Names = new List<string> { null, "Kowwai", "Mag1sh" };
        public static List<List<Pokemon>> AllPokemons = new List<List<Pokemon>> { null, Pokemon.pokemoni1, Pokemon.pokemoni2 };

        public Players(int id)
        {

            PID = PIDs[id];
            Color = Colors[id];
            Name = Names[id];
            Pokemons = AllPokemons[id];
            Pokemon = AllPokemons[id][PID];
        }
    }
}
