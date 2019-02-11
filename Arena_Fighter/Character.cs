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
        public bool IsDead
        {
            get
            {
                return Health <= 0;
            }
        }

        public List<Battle> Battles { get; set; } = new List<Battle>();

        public Character(string name)
        {
            this.Name = name;
            var random = new Random();
            this.Strength = random.Next(4, 8);
            this.Damage = Strength / 2;
            this.Health = random.Next(5, 10);
        }

        public Character(string name, int strength, int damage, int health)
        {
            this.Name = name;
            this.Strength = strength;
            this.Damage = damage;
            this.Health = health;
        }

        public int GetPlayerScore()
        {
            int result = 0;
            foreach (var battle in Battles)
            {
                // Reword with 2 for each battle the player join
                result += 2;
                if (battle.endedBattle && battle.Opponenten.Health <= 0)
                {
                    // Reword with 3 for each battle the player win
                    result += 3;
                }
            }
            return result;
        }

        public void PrintCharacterInfo()
        {
            Console.WriteLine($"Name: {this.Name}");
            Console.WriteLine($"Strength: {this.Strength}");
            Console.WriteLine($"Damage: {this.Damage}");
            Console.WriteLine($"Health: {(this.Health > 0 ? this.Health.ToString() : "Dead")}\n");
        }

        public void PrintCharacterScore()
        {
            Console.WriteLine($"{this.Name} all result is {this.GetPlayerScore()}.");
        }

        public void PrintCharacterFinalStatistics()
        {
            Console.WriteLine("Final Statistics: \n");
            PrintCharacterInfo();
            foreach (var battle in Battles)
            {
                Console.WriteLine($"{this.Name} " +
                  $"{(battle.Opponenten.IsDead ? "fought and killed" : "was killed by")} " +
                  $"{battle.Opponenten.Name}");
            }
        }

        public static Character GetRandomCharacter()
        {
            var names = new string[]
            {
        " Adam joesfsson ", "Samir Abdo", "Mats Johansson", "Marlon Brando", "Leo Messi", "Humphrey Bogart", "Johnny Depp", "Ali Pacino"
            };
            return new Character(names[new Random().Next(0, names.Length)]);

        }
    }
}
