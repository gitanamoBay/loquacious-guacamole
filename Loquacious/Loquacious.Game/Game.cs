using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Loquacious.Ai;
using Loquacious.Interfaces;
using Loquacious.Values;

namespace Loquacious.Game
{
    public abstract class Game : IGame
    {
        public abstract GameMode GameMode
        {
            get;
        }

        private Result _result;

        public Game(IEnumerable<IPlayer> list)
        {
            Players = list;
        }

        public IEnumerable<IPlayer> Players { get; private set; }

        public void StartGame()
        {
            Task.Factory.StartNew(() =>
            {

                Thread.Sleep(1000);
                if (CountDownTickOne != null)
                    CountDownTickOne();

                Thread.Sleep(1000);
                if (CountDownTickTwo != null)
                    CountDownTickTwo();

                Thread.Sleep(1000);
                if (CountDownTickGo != null)
                    CountDownTickGo();

                var players = Players.Where(x => x is INonNpc).ToList();
                foreach (INonNpc player in players)
                {
                    player.OpenControls();
                }

                var ai = Players.Where(x => x is IAi).ToList();
                foreach (IAi playerAi in ai)
                {
                    playerAi.LoadPlayersMoves(Players.Single(x => x != playerAi).PreviousPicks);
                }

                Thread.Sleep((int)TimeAllowedForPicks);

                foreach (INonNpc player in players)
                {
                    player.CloseControls();
                }
                if (GameEnds != null)
                {
                    if (players.Any(x => x.Pick == Pick.None))
                    {
                        GameEnds(Result.NoPicks, -1);
                        return;
                    }

                    if (Players.ElementAt(0).Pick == Players.ElementAt(1).Pick)
                    {
                        GameEnds(Result.Tie, -1);
                    }
                    else
                    {
                        GameEnds(Result.Victory, GetVictor());
                    }
                }
            });
        }

        private int GetVictor()
        {
            var playerOnePick = Players.ElementAt(0).Pick;
            var playerTwoPick = Players.ElementAt(1).Pick;

            if (playerOnePick == Pick.Rock)
            {
                if (playerTwoPick == Pick.Scissors)
                    return 0;
            }
            else if (playerOnePick == Pick.Scissors)
            {
                if (playerTwoPick == Pick.Paper)
                    return 0;
            }
            else
            {
                if (playerTwoPick == Pick.Rock)
                    return 0;
            }

            return 1;
        }

        public Action CountDownTickOne { get; set; }
        public Action CountDownTickTwo { get; set; }
        public Action CountDownTickGo { get; set; }
        public Action<Result, int> GameEnds { get; set; }

        public Result Result
        {
            get { return _result; }
        }
        public double CountDown
        {
            get { return 3000; }
        }
        public double TimeAllowedForPicks
        {
            get { return 1000; }
        }
    }
}
