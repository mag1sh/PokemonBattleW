using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

            pokemoni1.Clear();
            pokemoni2.Clear();

            foreach (string line in File.ReadAllLines(filePath))
            {
                string[] parts = line.Split(',');
                if (parts.Length == 8)
                {
                    int id = int.Parse(parts[0]);
                    string name = parts[1];
                    int attack = int.Parse(parts[2]);
                    int defence = int.Parse(parts[3]);
                    int strength = int.Parse(parts[4]);
                    int health = int.Parse(parts[5]);
                    int owner = int.Parse(parts[6]);
                    bool isAlive = bool.Parse(parts[7]);

                    Pokemon pokemonche = new Pokemon(id, name, attack, defence, strength, health, owner, isAlive);

                    if (owner == 1) pokemoni1.Add(pokemonche);
                    if (owner == 2) pokemoni2.Add(pokemonche);

                }

            }
        }

        public static void DisplayPokemonsOfPlayer1()
        {
            int br = 0;
            foreach (Pokemon p in pokemoni1)
            {
                br++;
                Console.WriteLine($"{br}. {p.Name}");
            }

        }

        public static void DisplayPokemonsOfPlayer2()
        {
            int br = 0;
            foreach (Pokemon p in pokemoni2)
            {
                br++;
                Console.WriteLine($"{br}. {p.Name}");
            }
        }
    }
}

