using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Loquacious.Interfaces;
using Loquacious.Values;

namespace Loquacious.Game
{
    public abstract class BasePlayer : INonNpc
    {
        private readonly object _keyLock = new object();
        private List<Pick> _previousPicks = new List<Pick>();
        private volatile bool _keysOpen;
        public abstract int Slot { get; }
        public Pick Pick { get; private set; }

        public IReadOnlyList<Pick> PreviousPicks
        {
            get { return new ReadOnlyCollection<Pick>(_previousPicks); }
        }

        public abstract IReadOnlyCollection<Key> KeysAccepted { get; }

        public void OpenControls()
        {
            Pick = Pick.None;
            _keysOpen = true;
        }

        public void CloseControls()
        {
            _keysOpen = false;
        }

        public bool KeyStroke(Key key)
        {
            lock (_keyLock)
            {
                if (_keysOpen)
                {

                    var keyidx = KeysAccepted.ToList().IndexOf(key);
                    if (keyidx == -1)
                        return false;
                    Pick = (Pick) (keyidx + 1);
                    _previousPicks.Add(Pick);
                    _keysOpen = false;
                    return true;
                }
            }
            return false;
        }
    }
}