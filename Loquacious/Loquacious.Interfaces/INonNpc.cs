using System.Collections.Generic;
using System.Windows.Input;

namespace Loquacious.Interfaces
{
    public interface INonNpc : IPlayer
    {
        IReadOnlyCollection<Key> KeysAccepted { get; }
        void KeyStroke(Key key);
        void OpenControls();
        void CloseControls();
    }
}