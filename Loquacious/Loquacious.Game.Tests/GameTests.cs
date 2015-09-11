using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using NSubstitute;
using Loquacious.Game;
using Loquacious.Interfaces;
using Loquacious.Values;

namespace Loquacious.Game.Tests
{
    [TestFixture]
    public class GameTests
    {
        [TestCase(Pick.Rock, Pick.Scissors, Result = 0)]
        [TestCase(Pick.Rock, Pick.Paper, Result = 1)]
        [TestCase(Pick.Paper, Pick.Rock, Result = 0)]
        [TestCase(Pick.Paper, Pick.Scissors, Result = 1)]
        [TestCase(Pick.Scissors, Pick.Paper, Result = 0)]
        [TestCase(Pick.Scissors, Pick.Rock, Result = 1)]
        public int GetsCorrectVictor(Pick p1, Pick p2)
        {
            List<IPlayer> players = new List<IPlayer>();
            IPlayer player1 = Substitute.For<IPlayer>();
            player1.Pick.Returns(p1);
            player1.Slot.Returns(1);
            players.Add(player1);
            IPlayer player2 = Substitute.For<IPlayer>();
            player2.Pick.Returns(p2);
            player2.Slot.Returns(2);

            players.Add(player2);

            var game = new Game(players);

            var gameResult = Result.None;
            var victor = -1;

            game.GameEnds = (result, i) =>
            {
                gameResult = result;
                victor = i;
            };

            game.StartGame();
            Thread.Sleep(100);
            Assert.AreEqual(Result.Victory, gameResult);

            return victor;
        }

        [TestCase(Pick.Rock, Pick.Rock)]
        [TestCase(Pick.Paper, Pick.Paper)]
        [TestCase(Pick.Scissors, Pick.Scissors)]
        public void Ties(Pick p1, Pick p2)
        {
            List<IPlayer> players = new List<IPlayer>();
            IPlayer player1 = Substitute.For<IPlayer>();
            player1.Pick.Returns(p1);
            player1.Slot.Returns(1);
            players.Add(player1);
            IPlayer player2 = Substitute.For<IPlayer>();
            player2.Pick.Returns(p2);
            player2.Slot.Returns(2);

            players.Add(player2);

            var game = new Game(players);

            var gameResult = Result.None;
            var victor = -1;

            game.GameEnds = (result, i) =>
            {
                gameResult = result;
                victor = i;
            };

            game.StartGame();
            Thread.Sleep(100);
            Assert.AreEqual(Result.Tie, gameResult);
        }

        [Test]
        public void CallsAllDelegates()
        {
            var game = new Game(null);
            bool cd1 = false;
            bool cd2 = false;
            bool cd3 = false;
            game.CountDownTickOne = () => cd1 = true;
            game.CountDownTickTwo = () => cd2 = true;
            game.CountDownTickGo = () => cd3 = true;
            game.StartGame();
            Thread.Sleep(100);
            Assert.AreEqual(true, cd1);
            Assert.AreEqual(true, cd2);
            Assert.AreEqual(true, cd3);

        }
    }
}
