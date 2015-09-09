using System.Collections.Generic;
using System.Windows.Input;
using Loquacious.Values;

namespace Loquacious.Interfaces
{
    public interface INonNpc:IPlayer
    {
        void KeyStroke(Key key);
        IReadOnlyCollection<Key> KeysAccepted { get; }
        void OpenControls();
        void CloseControls();
        IReadOnlyCollection<Pick> PreviousPicks { get; } 
    }
}
