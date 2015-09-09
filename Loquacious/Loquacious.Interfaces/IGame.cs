using System;
using Loquacious.Values;

namespace Loquacious.Interfaces
{
    public interface IGame
    {
        void StartGame();
        Action CountDownTickOne { get; set; }
        Action CountDownTickTwo { get; set; }
        Action CountDownTickGo { get; set; }
        Action<Result,int> GameEnds { get; set; }
        Result Result { get; }
        double CountDown { get; }
        double TimeAllowedForPicks { get; }
    }
}
