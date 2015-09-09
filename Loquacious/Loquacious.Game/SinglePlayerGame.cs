using System;
using System.Collections.Generic;
using Loquacious.Ai;
using Loquacious.Interfaces;
using Loquacious.Values;

namespace Loquacious.Game
{
    public class SinglePlayerGame : IGame
    {
        public SinglePlayerGame()
        {
            Players = new List<IPlayer>() {new PlayerOne(),new ArtificalIntelligence()};
        }

        public IEnumerable<IPlayer> Players { get; }

        public void StartGame()
        {
            if (GameEnds != null)
            {
                GameEnds(Result.None, 0);
            }
        }

        public Action CountDownTickOne { get; set; }
        public Action CountDownTickTwo { get; set; }
        public Action CountDownTickGo { get; set; }
        public Action<Result, int> GameEnds { get; set; }
        public Result Result { get; }
        public double CountDown { get; }
        public double TimeAllowedForPicks { get; }
    }
}
