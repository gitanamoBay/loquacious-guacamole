using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loquacious.Interfaces;
using Loquacious.Values;

namespace Loquacious.Ai
{
    public class ArtificalIntelligence:IAi
    {
        public bool IsAi { get { return true; } }

        public Pick Pick
        {
            get
            {
                return
                    Stratergies.Where(x => x.Confidence > x.MinimumConfidence)
                        .OrderByDescending(y => y.Confidence)
                        .First()
                        .SuggestedPick;
            }
        }

        public void LoadPlayersMoves(IEnumerable<Pick> previousPicks)
        {
            Parallel.ForEach(Stratergies,
                x => x.Consider(previousPicks));
        }

        public IEnumerable<IStratergy> Stratergies { get; set; }
        public int Difficulty { get; }
    }
}
