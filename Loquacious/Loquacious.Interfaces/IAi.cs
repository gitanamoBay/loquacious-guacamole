using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loquacious.Values;

namespace Loquacious.Interfaces
{
    public interface IAi:IPlayer
    {
        void LoadPlayersMoves(IEnumerable<Pick> previousPicks);
        IEnumerable<IStratergy> Stratergies { get; set; }
        int Difficulty { get; }
    }
}
