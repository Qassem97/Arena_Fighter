using System;

namespace Arena_Fighter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name of your character: ");
            string playerName = Console.ReadLine(); Console.Clear();

            // Creat the player
            var player = new Character(playerName);

            // Game Loop
            while (!player.IsDead)
            {
                string HuntOrRetire;
                do
                {
                    Console.Clear();
                    // Print the player info name, strength, damage, health
                    player.PrintCharacterInfo();
                    Console.WriteLine("What do you want to do?");
                    Console.WriteLine("H - Hunt for an opponent");
                    Console.WriteLine("R - Retire from fighting");
                    HuntOrRetire = Console.ReadKey(true).Key.ToString();
                } while (!(HuntOrRetire == "H" ^ HuntOrRetire == "R"));

                // Ended the violence
                if (HuntOrRetire == "R")
                {
                    Console.WriteLine("You have ended the violence by not fighting.");
                    Console.ReadKey(true);
                    break;
                }
                // Hunt for an opponent
                else
                {
                    // Get random opponent
                    var opponent = Character.GetRandomCharacter();

                    Console.Clear();
                    // Print the players info name, strength, damage, health
                    player.PrintCharacterInfo();
                    opponent.PrintCharacterInfo();

                    // Creat a battle
                    var battle = new Battle(player, opponent);
                    // Keep playing rounds untill the battleEnd(one of the player is dead)
                    while (!battle.endedBattle)
                    {
                        // Creat new round
                        var round = new Round(battle);
                        Console.ReadKey(true);
                        Console.WriteLine("-------------------------");
                        // Start the round and print the result
                        round.GoRound();
                        // Save this round in battle history
                        battle.BattleRounds.Add(round);

                        // When battle end Print the winner
                        if (battle.endedBattle)
                        {
                            Console.ReadKey(true);
                            var winer = battle.Player.Health > battle.Opponenten.Health
                                ? battle.Player : battle.Opponenten;
                            Console.WriteLine($"\n{winer.Name} is victory");
                            Console.ReadKey(true);
                        }
                    }
                }
            }
            Console.Clear();
            // Print Final Statistics
            player.PrintCharacterFinalStatistics();
            // Print Total Score
            player.PrintCharacterScore();

            Console.ReadKey();
        }

    }
}
