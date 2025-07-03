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
    }
}
