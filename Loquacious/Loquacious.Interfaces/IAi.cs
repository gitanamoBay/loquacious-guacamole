using System.Collections.Generic;
using Loquacious.Values;

namespace Loquacious.Interfaces
{
    public interface IAi:IPlayer
    {
        void LoadPlayersMoves(IReadOnlyList<Pick> previousPicks);
        IEnumerable<IStratergy> Stratergies { get; set; }
        int Difficulty { get; }
    }
}
