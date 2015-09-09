using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loquacious.Interfaces;
using Loquacious.Values;

namespace Loquacious.Game
{
    public class SinglePlayerGame : IGame
    {
        public IEnumerable<IPlayer> Players; 

        public void StartGame()
        {
            
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
