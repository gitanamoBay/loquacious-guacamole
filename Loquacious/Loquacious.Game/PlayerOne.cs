using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Loquacious.Game
{
    public class PlayerOne : BasePlayer
    {
        public override int Slot
        {
            get { return 1; }
        }

        public override IReadOnlyCollection<Key> KeysAccepted
        {
            get { return new ReadOnlyCollection<Key>(new[] {Key.W, Key.E, Key.R}); }
        }
    }
}