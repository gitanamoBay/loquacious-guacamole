using Loquacious.Values;

namespace Loquacious.Interfaces
{
    public interface IPlayer
    {
        bool IsAi { get; }
        Pick Pick { get; }
    }
}
