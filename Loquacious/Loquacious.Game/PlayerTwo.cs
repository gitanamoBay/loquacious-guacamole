using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Loquacious.Game
{
    public class PlayerTwo : BasePlayer
    {
        public override int Slot { get { return 2; } }

        public override IReadOnlyCollection<Key> KeysAccepted
        {
            get
            {
                return new ReadOnlyCollection<Key>(new[] { Key.Left, Key.Down, Key.Right });
            }
        }
    }
}