using System;
using System.Collections.Generic;
using Loquacious.Ai;
using Loquacious.Interfaces;
using Loquacious.Values;

namespace Loquacious.Game
{
    public class SinglePlayerGame : IGame
    {
        private Result _result;
        
        public SinglePlayerGame()
        {
            Players = new List<IPlayer>() {new PlayerOne(),new ArtificalIntelligence()};
        }

        public IEnumerable<IPlayer> Players { get; }

        public void StartGame()
        {
            Task.Factory.StartNew(()=>{
                
                Thread.Sleep(1000);
                CountDownTickOne();

                ThreadSleep(1000);
                CountDownTickTwo();

                Thread.Sleep(1000);
                CountDownTickGo();

                Thread.Sleep(TimeAllowedForPicks);
                    
                if (GameEnds != null)
                {
                    GameEnds(Result.None, 0);
                }
                


            });
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
            get{ return 1000; }
        }
    }
}
