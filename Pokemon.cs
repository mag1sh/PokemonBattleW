using PokemonBattleW;
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
        // Списъци с покемони за играч 1 и играч 2
        public static List<Pokemon> pokemoni1 { get; private set; } = new List<Pokemon>();
        public static List<Pokemon> pokemoni2 { get; private set; } = new List<Pokemon>();

        //свойства на всеки покемон
        public int ID;
        public string Name;
        public int Attack;
        public int Defence;
        public int Strength;
        public int Health;
        public int Owner; 
        public bool IsAlive;

        //kонструктор за създаване на нов покемон
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

        // Зарежда покемоните от външен текстов файл
        public static void LoadPokemons()
        {
            string filePath = "../../pokemoni.txt";

            // Изчистваме списъците, за да няма повтарящи се записи при повторно зареждане
            pokemoni1.Clear();
            pokemoni2.Clear();

            // Четене на всички редове от файла
            string[] lines = File.ReadAllLines(filePath);

            // Пропускаме заглавния ред и обхождаме останалите
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(',');

                // Извличаме и преобразуваме данните на героя от масива parts
                int id = int.Parse(parts[0]);
                string name = parts[1];
                int attack = int.Parse(parts[2]);
                int defence = int.Parse(parts[3]);
                int strength = int.Parse(parts[4]);
                int health = int.Parse(parts[5]);
                int owner = int.Parse(parts[6]);
                bool isAlive = bool.Parse(parts[7]);

                //Създаваме нов покемон с прочетените стойности и го добавяме в съответния списък според собственика
                Pokemon pokemonche = new Pokemon(id, name, attack, defence, strength, health, owner, isAlive);

                if (owner == 1) pokemoni1.Add(pokemonche);
                else if (owner == 2) pokemoni2.Add(pokemonche);
            }
        }

        // Показва имената на покемоните на текущия играч
        public static void DisplayPokemonsOfPlayer(Players activePlayer)
        {
            int br = 1;

            //обхождаме всички покемони на играча и ги отпечатваме под формата: 1.Pikachu, 2.Chirizard,...
            foreach (Pokemon Pokemon in activePlayer.Pokemons)
            {
                Console.Write($"{br}.{Pokemon.Name}, ");
                br++;
            }
        }
    }
}