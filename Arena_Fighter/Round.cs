using System;
using System.Collections.Generic;
using System.Text;

namespace Arena_Fighter
{
    class Round
    {
        public Battle Battle { get; private set; }

        private Random randomly = new Random();
        public Round(Battle battle)
        {
            Battle = battle;
        }

        public void GoRound()
        {
            int player = randomly.Next(1, 7);
            int opponenten = randomly.Next(1, 7);
            int playerPlusLuck = player + Battle.Player.Strength;
            int opponentenPlusLuck = opponenten + Battle.Opponenten.Strength;

            dicesGo(player, opponenten);

            // Player attacks opponent
            if (playerPlusLuck > opponentenPlusLuck)
            {
                Battle.Opponenten.Health -= Battle.Player.Damage;
                attackingOccurrence(playerPlusLuck, opponentenPlusLuck);
            }
            // Opponent attacks player
            else if (playerPlusLuck < opponentenPlusLuck)
            {
                Battle.Player.Health -= Battle.Opponenten.Damage;
                attackingOccurrence(playerPlusLuck, opponentenPlusLuck);
            }
            // strenght equals betweeen the fighter
            else
            {
                Console.WriteLine("Both of you have the same power, try again and hit harder.");
            }

            // Print Remaining Health
            PrintRemainingHealth();
        }

        private void dicesGo(int playersDice, int opponentensDice)
        {
            Console.WriteLine($"Throws: " +
              $"{Battle.Player.Name} {Battle.Player.Strength + playersDice} ({Battle.Player.Strength}+{playersDice})" +
              $" vs " +
              $"{Battle.Opponenten.Name} {Battle.Opponenten.Strength + opponentensDice} ({Battle.Opponenten.Strength}+{opponentensDice})");
        }

        private void PrintRemainingHealth()
        {
            Console.WriteLine($"Remaining Health: " +
              $"{Battle.Player.Name} ({(Battle.Player.Health > 0 ? Battle.Player.Health.ToString() : "Dead")}) " +
              $"{Battle.Opponenten.Name} ({(Battle.Opponenten.Health > 0 ? Battle.Opponenten.Health.ToString() : "Dead")})");
        }

        private void attackingOccurrence(int playerStrengthPlusDice, int opponentStrenghtPlusDice)
        {
            Character attacker;
            Character defender;
            // Player is the attacker
            if (playerStrengthPlusDice > opponentStrenghtPlusDice)
            {
                attacker = Battle.Player;
                defender = Battle.Opponenten;
                Console.ForegroundColor = ConsoleColor.Green;
            }
            // Opponent is the attacker
            else
            {
                attacker = Battle.Opponenten;
                defender = Battle.Player;
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Write($"{attacker.Name} attacks {defender.Name}! " +
              $"{defender.Name} takes {attacker.Damage} damage" +
              $"{(Battle.endedBattle ? ", and falls to the ground dead." : ".")} \n");
            Console.ResetColor();
        }
    }
}
