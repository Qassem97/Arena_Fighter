using System;
using System.Collections.Generic;
using System.Text;

namespace Arena_Fighter
{
    class Battle
    {

        public Character Player { get; private set; }
        public Character Opponenten { get; private set; }


        public List<Round> BattleRounds { get; set; } = new List<Round>();  // after = :create auto new instance if needed

        public Battle(Character player, Character opponent)
        {
            Player = player;
            Player.Battles.Add(this);
            Opponenten = opponent;
            Opponenten.Battles.Add(this);

        }
        public bool IsBattleEnded()
        {
            if (Player.IsDead || Opponenten.IsDead)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
