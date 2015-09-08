using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loquacious.Interfaces;
using Loquacious.Values;

namespace Loquacious.Ai
{
    public class RandomStratergy:IStratergy
    {
        public int DifficultRequired
        {
            get { return 0; }
        }

        public int MinimumConfidence
        {
            get { return 0; }
        }

        public int Confidence
        {
            get { return 1; }
        }

        private Pick _pick;

        public Pick SuggestedPick { get; }
        public void Consider(IEnumerable<Pick> previousPicks)
        {
           Random r = new Random();
           _pick = (Pick)r.Next(3);
        }
    }
}
