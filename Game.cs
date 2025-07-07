using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattleW
{
    internal class Game
    {
        public static int ChoosePokemon(int activePl,string pokemonName)
        {          
            Pokemon.DisplayPokemonsOfPlayer1();
            Console.Write($"Играч {activePl} избери своя покемон:");
            int id = int.Parse(Console.ReadLine()) - 1;
            Console.ForegroundColor = ConsoleColor.Blue;
            //Console.Write("\x1b[38;2;217;117;177m");
            Console.WriteLine($"Играч {activePl} избра покемон {pokemonName}");
            //Console.Write("\x1b[0m");
            Console.ResetColor();
            return id;
        }

        public static void izbora(Pokemon attacker, Pokemon defender, string attackerName) 
        {
            Console.WriteLine("Изберете следващия ви ход");
            Console.WriteLine("1.Атака");
            Console.WriteLine("2.Замяна на активния покемон с друг");
            Console.Write("Въведете вашия избор:");
            string choice=Console.ReadLine();
            switch (choice) 
            {
                case "1":
                    Battle.Attack(attacker, defender, attackerName);
                    break;
                case "2":
                    //ChoosePokemon();
                    break;

            }
        }


    }
}
