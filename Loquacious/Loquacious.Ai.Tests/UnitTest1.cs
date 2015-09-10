using System;
using NUnit.Framework;
using Loquacious.Ai;
using NSubstitute;
using System.Collections.Generic;
using Loquacious.Interfaces;

namespace Loquacious.Ai.Tests
{
    [TestFixture]
    public class AiTests
    {
        [Test]
        public void DoesPick()
        {
            List<IStratergy> strats = new List<IStratergy>();
            var exampleStrat = Substitute.For<IStratergy>();
            exampleStrat.SuggestedPick.Returns(Values.Pick.Rock);
            exampleStrat.MinimumConfidence.Returns(0);
            exampleStrat.Confidence.Returns(1);
            exampleStrat.DifficultyRequired.Returns(0);
            strats.Add(exampleStrat);
            var ai = new ArtificalIntelligence(strats);

            ai.LoadPlayersMoves(null);

            Assert.AreEqual(Values.Pick.Rock, ai.Pick);
        }

        [TestCase(Values.Pick.Rock,Result = Values.Pick.Rock)]
        [TestCase(Values.Pick.Paper, Result = Values.Pick.Paper)]
        [TestCase(Values.Pick.Scissors, Result = Values.Pick.Scissors)]
        public Values.Pick DoesPickRightPick(Values.Pick pick)
        {
            List<IStratergy> strats = new List<IStratergy>();
            var exampleStrat = Substitute.For<IStratergy>();
            exampleStrat.SuggestedPick.Returns(pick);
            exampleStrat.MinimumConfidence.Returns(0);
            exampleStrat.DifficultyRequired.Returns(0);
            exampleStrat.Confidence.Returns(1);
            strats.Add(exampleStrat);
            var ai = new ArtificalIntelligence(strats);

            ai.LoadPlayersMoves(null);

            return ai.Pick;
        }

        [Test]
        public void PicksMostConfident()
        {
            List<IStratergy> strats = new List<IStratergy>();
            var exampleStrat = Substitute.For<IStratergy>();
            exampleStrat.SuggestedPick.Returns(Values.Pick.Rock);
            exampleStrat.MinimumConfidence.Returns(0);
            exampleStrat.Confidence.Returns(1);
            exampleStrat.DifficultyRequired.Returns(0);

            strats.Add(exampleStrat);
            var mostConfident = Substitute.For<IStratergy>();
            mostConfident.SuggestedPick.Returns(Values.Pick.Scissors);
            mostConfident.MinimumConfidence.Returns(0);
            mostConfident.DifficultyRequired.Returns(0);

            mostConfident.Confidence.Returns(2);
            strats.Add(mostConfident);
            var ai = new ArtificalIntelligence(strats);

            ai.LoadPlayersMoves(null);

            Assert.AreEqual(Values.Pick.Scissors, ai.Pick);
        }

        [Test]
        public void WontPickBelowMinConfidence()
        {
            List<IStratergy> strats = new List<IStratergy>();
            var exampleStrat = Substitute.For<IStratergy>();
            exampleStrat.SuggestedPick.Returns(Values.Pick.Rock);
            exampleStrat.MinimumConfidence.Returns(0);
            exampleStrat.DifficultyRequired.Returns(0);
            exampleStrat.Confidence.Returns(1);
            strats.Add(exampleStrat);
            var mostConfident = Substitute.For<IStratergy>();
            mostConfident.SuggestedPick.Returns(Values.Pick.Scissors);
            mostConfident.MinimumConfidence.Returns(3);
            mostConfident.DifficultyRequired.Returns(0);
            mostConfident.Confidence.Returns(2);
            strats.Add(mostConfident);
            var ai = new ArtificalIntelligence(strats);

            ai.LoadPlayersMoves(null);

            Assert.AreEqual(Values.Pick.Rock, ai.Pick);
        }

        [Test]
        public void PicksBelowDifficulty()
        {
            List<IStratergy> strats = new List<IStratergy>();
            var exampleStrat = Substitute.For<IStratergy>();
            exampleStrat.SuggestedPick.Returns(Values.Pick.Rock);
            exampleStrat.MinimumConfidence.Returns(0);
            exampleStrat.Confidence.Returns(1);
            exampleStrat.DifficultyRequired.Returns(0);
            strats.Add(exampleStrat);
            var mostConfident = Substitute.For<IStratergy>();
            mostConfident.SuggestedPick.Returns(Values.Pick.Scissors);
            mostConfident.MinimumConfidence.Returns(0);
            mostConfident.DifficultyRequired.Returns(11);
            mostConfident.Confidence.Returns(2);
            strats.Add(mostConfident);
            var ai = new ArtificalIntelligence(strats);

            ai.LoadPlayersMoves(null);

            Assert.AreEqual(Values.Pick.Rock, ai.Pick);
        }
    }
}
