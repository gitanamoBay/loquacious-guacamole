using Loquacious.Values;

namespace Loquacious.Interfaces
{
    public interface IPlayer
    {
        bool IsAi { get; set; }
        Pick Pick { get; }
    }
}
