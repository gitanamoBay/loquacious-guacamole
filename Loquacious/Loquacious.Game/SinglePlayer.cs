using System.Collections.Generic;
using System.Linq;
using Loquacious.Interfaces;
using Loquacious.Values;

namespace Loquacious.Game
{
    public class SinglePlayer : Game
    {
        public SinglePlayer(IEnumerable<IPlayer> players)
            : base(new List<IPlayer> {players.Single(x => x.Slot == 1), players.Single(x => x.Slot == 2 && x is IAi)})
        {
        }

        public override GameMode GameMode
        {
            get { return GameMode.PvsAi; }
        }

        public override double CountDown
        {
            get { return 3000; }
        }

        public override double TimeAllowedForPicks
        {
            get { return 1000; }
        }
    }
}