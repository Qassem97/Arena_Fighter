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
            while (!player.IsDead) // Game Loop
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
                    if (battle.IsBattleEnded())
                    {
                        Console.ReadKey(true);

                        if (battle.Player.Health > battle.Opponenten.Health)
                            Console.WriteLine($"\n{battle.Player.Name} is the winner");// one line "no needs for brackets
                        else
                            Console.WriteLine($"\n{ battle.Opponenten.Name} is the winner");
                        Console.ReadKey(true);
                    }
                    else 
                    {
                        // Create new Round
                        var round = new Round(battle);
                        Console.ReadKey(true);
                        Console.WriteLine("-------------------------");
                        // Start the round and print the result
                        //round.GoRound();
                        // Save this round in battle history
                        battle.BattleRounds.Add(round);
                        // When battle end Print the winner
                    }  
                }

                else if (FightOrEscape == "R")
                {
                    Console.WriteLine("You have withdrawn from the battle. You pussy!");
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
        }

    }

}



