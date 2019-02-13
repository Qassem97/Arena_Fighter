using System;
using System.Collections.Generic;
using System.Text;

namespace Arena_Fighter
{
    class Character
    {
        public string Name { get; private set; }
        public int Strength { get; private set; }
        public int Damage { get; private set; }
        public int Health { get; set; }
        Random random = new Random();
        public bool IsDead
        {
            get
            {
                return Health <= 0;
            }
        }
        // after = :create auto new instance if needed
        public List<Battle> Battles { get; set; } = new List<Battle>(); 

        public Character(string name)
        {
            Name = name;
            Strength = random.Next(2, 9);
            Damage = random.Next(2, 5);
            Health = random.Next(3, 11);
        }

        public int GetPlayerScore()
        {
            int result = 0;
            foreach (var battle in Battles)
            {
                //As fast the player starts a battle , will get +1 to score
                result += 1;
                if (battle.Opponenten.IsDead)
                {
                    // when the player wins a battle will get +3 to score  
                    result += 3;
                }
            }
            return result;
        }

        public void PrintCharacterInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Strength: {Strength}");
            Console.WriteLine($"Damage: {Damage}");
            Console.WriteLine($"Health: {(Health > 0 ? Health.ToString() : "Dead")}\n");
        }

        public void PrintCharacterScore()
        {
            Console.WriteLine($"{this.Name} score is {this.GetPlayerScore()}.");
        }

        public void PrintCharacterFinalStatistics()
        {
            Console.WriteLine("Final Statistics: \n");
            PrintCharacterInfo();
            foreach (var battle in Battles)
            {
                Console.WriteLine($"{this.Name} " +
                  $"{(battle.Opponenten.IsDead ? "  killed " : "was killed by")} " +
                  $"{battle.Opponenten.Name}");
            }
        }

        public static Character GetRandomCharacter()
        {
            var names = new string[]
            {
                " Adam joesfsson ", "Samir Abdo", "Mats Johansson", "Marlon Brando", //decided names to show
                "Leo Abdi", "Humphrey Bogart", "Abdullah Hasan", "Johnny Depp", "Ali Pacino"
            };
            return new Character(names[new Random().Next(0, names.Length)]);
        }
    }
}
