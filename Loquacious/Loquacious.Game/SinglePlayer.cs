using System.Collections.Generic;
using System.Linq;
using Loquacious.Interfaces;
using Loquacious.Values;

namespace Loquacious.Game
{
    public class SinglePlayer : Game
    {
        public override GameMode GameMode
        {
            get { return GameMode.PvsAi;}
        }

        public SinglePlayer(IEnumerable<IPlayer> players):base( new List<IPlayer> { players.Single(x => x.Slot == 1), players.Single(x => x.Slot == 2 && x is IAi)})
        {
            
        }
    }
}