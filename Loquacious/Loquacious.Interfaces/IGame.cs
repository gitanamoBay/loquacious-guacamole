using System;
using Loquacious.Values;

namespace Loquacious.Interfaces
{
    public interface IGame
    {
        void StartGame(IPlayer one, IPlayer two);
        Action CountDownTickOne { get; set; }
        Action CountDownTickTwo { get; set; }
        Action CountDownTickGo { get; set; }
        Action<Result> GameEnds { get; set; }
        Result Result { get; }
        double CountDown { get; }
        double TimeAllowedForPicks { get; }
    }
}
