using System.Collections.Generic;
using Loquacious.Values;

namespace Loquacious.Interfaces
{
    public interface IAi : IPlayer
    {
        IEnumerable<IStratergy> Stratergies { get; set; }
        int Difficulty { get; }
        void LoadPlayersMoves(IReadOnlyList<Pick> previousPicks);
    }
}