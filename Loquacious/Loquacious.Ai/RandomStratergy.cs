using System;
using System.Collections.Generic;
using Loquacious.Interfaces;
using Loquacious.Values;

namespace Loquacious.Ai
{
    public class RandomStratergy : IStratergy
    {
        public int DifficultyRequired
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

        public Pick SuggestedPick { get; private set; }

        public void Consider(IReadOnlyList<Pick> previousPicks)
        {
            SuggestedPick = (Pick) new Random().Next(1, 4);
        }
    }
}