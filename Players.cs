using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattleW
{
    internal class Players
    {
        public int PokemonID;// ID на избрания покемон от играча
        public string Color;// Цвят, използван за визуализация в конзолата
        public string Name; // Име на играча
        public List<Pokemon> Pokemons;// Списък с покемони на играча
        public Pokemon Pokemon;// Активен покемон

        // Статични данни за двамата играчи (използват се като шаблон при създаване на обекти от класа)
        public static List<int> PokemonIDs = new List<int> { 0, 1, 1 };
        public static List<string> Colors = new List<string> { null, "\u001b[38;2;180;100;255m", "\u001b[38;2;255;105;180m" };
        public static List<string> Names = new List<string> { null, null, null };
        public static List<List<Pokemon>> AllPokemons = new List<List<Pokemon>> { null, Pokemon.pokemoni1, Pokemon.pokemoni2 }; // Покемони на двамата играчи

        public Players(int id)
        {
            // Инициализира играча с данни според ID (1 или 2)
            PokemonID = PokemonIDs[id];
            Color = Colors[id];
            Name = Names[id];
            Pokemons = AllPokemons[id];
            Pokemon = AllPokemons[id][PokemonID]; // Задава се текущ активен покемон
        }
    }
}
