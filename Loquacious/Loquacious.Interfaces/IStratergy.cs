using System.Collections.Generic;
using Loquacious.Values;

namespace Loquacious.Interfaces
{
    public interface IStratergy
    {
        int DifficultyRequired { get; }
        int MinimumConfidence { get; }
        int Confidence { get; }
        Pick SuggestedPick { get; }
        void Consider(IEnumerable<Pick> previousPicks);
    }
}
