using System.Collections.Generic;
using System.Windows.Input;

namespace Loquacious.Interfaces
{
    public interface INonNpc:IPlayer
    {
        void KeyStroke(Key key);
        IEnumerable<Key> KeysAccepted { get; }
        void OpenControls();
        void CloseControls();
    }
}
