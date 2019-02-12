using System;

namespace Arena_Fighter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("  You'r welcome in Arena Fighter game\n ");
            Console.WriteLine("Enter your hero's name: ");
            string playerName = Console.ReadLine(); Console.Clear();

            var player = new Character(playerName);// Creating the player           
            while (!player.IsDead) //  Loop
            {
                string FightOrEscape;

                Console.Clear();
                // output name, strength, damage, health
                player.PrintCharacterInfo();
                Console.WriteLine("Choose one of these!");
                Console.WriteLine("H - Picks up for an opponent");
                Console.WriteLine("R - Withdraws from battle");
                FightOrEscape = Console.ReadKey(true).Key.ToString();

                if (FightOrEscape == "H")
                {
                    var opponent = Character.GetRandomCharacter();  //  random opponent
                    Console.Clear();
                    // output: name, strength, damage, health
                    player.PrintCharacterInfo();
                    opponent.PrintCharacterInfo();
                    var battle = new Battle(player, opponent);  // Battle creating

                    // play rounds untill the battleEnd(one of the player Isdead)
                    while (!battle.IsBattleEnded())
                    {    
                        var round = new Round(battle); // Create new Round
                        round.GoRound();
                        Console.ReadKey(true);
                        Console.WriteLine("-------------------------");
                        // Start the round and print the result

                        // Save this round in battle history
                        battle.BattleRounds.Add(round);
                        // When battle end Print the winner
                    }
                    Console.ReadKey(true);

                    if (battle.Player.Health > battle.Opponenten.Health)
                        Console.WriteLine($"\n{battle.Player.Name} is the winner");// one line "no needs for brackets
                    else
                        Console.WriteLine($"\n{ battle.Opponenten.Name} is the winner");
                    Console.ReadKey(true);

                }

                else if (FightOrEscape == "R")
                {
                    Console.WriteLine("You have withdrawn from the battle. Good bye!" +
                        " \n Press any key to show your final score");
                    Console.ReadKey(true);
                    break;
                }
            }
            Console.Clear();
            // Final Statistics
            player.PrintCharacterFinalStatistics();
            //  Total Score
            player.PrintCharacterScore();

            Console.ReadKey();
        }//end of main

    }//end of class

}



