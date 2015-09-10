using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Loquacious.Interfaces;
using Loquacious.Values;

namespace Loquacious.Ai
{
    public class ArtificalIntelligence:IAi
    {
        public int Slot { get { return 2; } }

        private List<Pick> _previousPicks = new List<Pick>();  
        public Pick Pick
        {
            get { return _previousPicks.Last(); }
        }

        public void LoadPlayersMoves(IReadOnlyList<Pick> previousPicks)
        {
            Parallel.ForEach(Stratergies,
                x => x.Consider(previousPicks));

            _previousPicks.Add(
                Stratergies.Where(x => x.Confidence > x.MinimumConfidence)
                    .OrderByDescending(y => y.Confidence)
                    .First()
                    .SuggestedPick);
        }

        public IEnumerable<IStratergy> Stratergies { get; set; }

        public int Difficulty
        {
            get { return 10; }
        }


        public ArtificalIntelligence(IEnumerable<IStratergy> strats)
        {
            Stratergies = strats;
        }

        public IReadOnlyList<Pick> PreviousPicks
        {
            get
            {
                return new ReadOnlyCollection<Pick>(_previousPicks);
            }
        }
    }
}
