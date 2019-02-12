using System;
using System.Collections.Generic;
using System.Text;

namespace Arena_Fighter
{
    class Round
    {
        public Battle Battle { get; private set; }

        public static Random randomly = new Random();

        public Round(Battle battle)
        {
            Battle = battle;

        }

        public void GoRound()
        {

            int playerDice = randomly.Next(1, 9);
            int opponentenDice = randomly.Next(1, 8);
            int playerPlusLuck = playerDice + Battle.Player.Strength;
            int opponentenPlusLuck = opponentenDice + Battle.Opponenten.Strength;

            dicesGo(playerDice, opponentenDice);

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
            // strength equals betweeen the fighter and opponent
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Both of you have the same power, try again and hit harder.");
                Console.ResetColor();
            }

            // Print Remaining Health
            PrintRemainingHealth();
            Console.WriteLine();
        }

        private void dicesGo(int playersDice, int opponentensDice)
        {
            Console.WriteLine($"Throws dice: " +
              $"{Battle.Player.Name} {Battle.Player.Strength + playersDice} ({Battle.Player.Strength}+{playersDice})" +
              $" vs " +
              $"{Battle.Opponenten.Name} {Battle.Opponenten.Strength + opponentensDice} ({Battle.Opponenten.Strength}+{opponentensDice})");
        }

        private void PrintRemainingHealth()
        {
            Console.WriteLine($" \nRemaining Health: " +
              $"{Battle.Player.Name} ({(Battle.Player.Health > 0 ? Battle.Player.Health.ToString() : "Dead")}) " +
              $"{Battle.Opponenten.Name} ({(Battle.Opponenten.Health > 0 ? Battle.Opponenten.Health.ToString() : "Dead")})");
        }
        //to do 
        private void attackingOccurrence(int playerStrengthPlusDice, int opponentStrenghtPlusDice)
        {
            // Player is the fighting
            if (playerStrengthPlusDice > opponentStrenghtPlusDice)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(Battle.Player.Name + " attacks " + Battle.Opponenten.Name +
               "! " + "\n" + Battle.Opponenten.Name + " takes " + Battle.Player.Name +"s" + " damage ");
                Console.ResetColor();
            }
            // Opponent is the fighting
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write( Battle.Opponenten.Name + " attacks " + Battle.Player.Name  +
                "! " + "\n" + Battle.Player.Name + " takes " + Battle.Opponenten.Name+ "s"  + " damage ");
                Console.ResetColor();
            }
        }
    }//endofclass
}
