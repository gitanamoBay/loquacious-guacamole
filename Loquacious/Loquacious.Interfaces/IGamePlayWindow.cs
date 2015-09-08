using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loquacious.Interfaces
{
    public interface IGamePlayWindow
    {
        void DisplayGame();
        IGame Game { get; set; }
    }
}
