using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattleW
{
    internal class Pokemon
    {
        public static List<Pokemon> pokemoni1 { get; private set; } = new List<Pokemon>();
        public static List<Pokemon> pokemoni2 { get; private set; } = new List<Pokemon>();

        public int ID;
        public string Name;
        public int Attack;
        public int Defence;
        public int Strength;
        public int Health;
        public int Owner;
        public bool IsAlive;

        public Pokemon(int id, string name, int attack, int defence, int strength, int health, int owner, bool isAlive)
        {
            ID = id;
            Name = name;
            Attack = attack;
            Defence = defence;
            Strength = strength;
            Health = health;
            Owner = owner;
            IsAlive = isAlive;
        }

        public static void LoadPokemons()
        {
            string filePath = "../../pokemoni.txt";
            List<Pokemon> pokemoni = new List<Pokemon>();
            foreach (string line in File.ReadAllLines(filePath))
            {
                string[] parts = line.Split(',');
                if (parts.Length == 8)
                {
                    Pokemon pokemonche = new Pokemon
                    {
                        //Id nqma
                        Name = parts[1],
                        Attack = int.Parse(parts[2]),
                        Defence = int.Parse(parts[3]),
                        Strength = int.Parse(parts[4]),
                        Health = int.Parse(parts[5]),
                        Owner = int.Parse(parts[6]),
                        IsAlive = bool.Parse(parts[7])
                    };
                    pokemoni.Add(pokemonche);
                }
            }
        }
    }
}

