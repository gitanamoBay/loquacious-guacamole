using System.Collections.Generic;
using Loquacious.Values;

namespace Loquacious.Interfaces
{
    public interface IPlayer
    {
        int Slot { get; }
        Pick Pick { get; }
        IReadOnlyList<Pick> PreviousPicks { get; }
    }
}