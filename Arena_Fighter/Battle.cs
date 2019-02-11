using System;
using System.Collections.Generic;
using System.Text;

namespace Arena_Fighter
{
    class Battle
    {

        public Character Player { get; private set; }
        public Character Opponenten { get; private set; }
        public bool endedBattle => (Player.IsDead || Opponenten.IsDead);

        public List<Round> BattleRounds { get; set; }
          = new List<Round>();

        public Battle(Character player, Character opponent)
        {
            this.Player = player;
            this.Player.Battles.Add(this);

            this.Opponenten = opponent;
            this.Opponenten.Battles.Add(this);

        }  
}   }
