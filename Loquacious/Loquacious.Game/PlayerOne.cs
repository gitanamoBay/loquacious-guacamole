using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Loquacious.Interfaces;
using Loquacious.Values;

namespace Loquacious.Game
{
    public class PlayerOne:INonNpc
    {
        private volatile bool _keysOpen;
        private object _keyLock = new object();
        private List<Pick> _previousPicks = new List<Pick>();

        public bool IsAi
        {
            get { return false; }
        }

        public Pick Pick { get; private set; }

        public IReadOnlyCollection<Key> KeysAccepted
        {
            get
            {
                return new ReadOnlyCollection<Key>( new []{ Key.W, Key.E, Key.R });
            }
        }

        public IReadOnlyCollection<Pick> PreviousPicks
        {
            get
            {
                return new ReadOnlyCollection<Pick>(_previousPicks);
            }
        }
        public void OpenControls()
        {
            Pick = Pick.None;
            _keysOpen = true;
        }

        public void CloseControls()
        {
            _keysOpen = false;
        }

        public void KeyStroke(Key key)
        {
            lock (_keyLock)
            {
                if (_keysOpen)
                {
                    Pick = (Pick) (KeysAccepted.ToList().IndexOf(key) + 1);
                    _previousPicks.Add(Pick);
                    _keysOpen = false;
                }
            }
        }
    }
}
