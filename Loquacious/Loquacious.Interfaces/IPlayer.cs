using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loquacious.Values;

namespace Loquacious.Interfaces
{
    public interface IPlayer
    {
        bool IsAi { get; set; }

        Pick Pick { get; }
 
    }

    public interface INonNpc
    {
        void KeyStroke();
        IEnumerable<object> KeysAccepted { get; }
        void OpenControls();
        void CloseControls();
    }

}
