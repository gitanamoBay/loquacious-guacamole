using System;
using System.Collections.Generic;
using Loquacious.Values;

namespace Loquacious.Interfaces
{
    public interface IGame
    {
        GameMode GameMode { get; }
        Action CountDownTickOne { get; set; }
        Action CountDownTickTwo { get; set; }
        Action CountDownTickGo { get; set; }
        Action<Result, int> GameEnds { get; set; }
        double CountDown { get; }
        double TimeAllowedForPicks { get; }
        IEnumerable<IPlayer> Players { get; }
        void StartGame();
    }
}