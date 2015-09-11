using System;
using System.Collections.Generic;
using System.Linq;
using Loquacious.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Loquacious.Game.Tests
{
    [TestFixture]
    public class GameModeTests
    {
        [Test]
        public void BuildsSinglePlayer()
        {
            List<IPlayer> collection = new List<IPlayer>();

            var p1 = Substitute.For<INonNpc>();
            p1.Slot.Returns(1);
            collection.Add(p1);

            var p2 = Substitute.For<INonNpc>();
            p2.Slot.Returns(2);
            collection.Add(p2);

            var ai = Substitute.For<IAi>();
            ai.Slot.Returns(2);
            collection.Add(ai);
            
            var singlePlayer = new SinglePlayer(collection);

            Assert.AreEqual(true,singlePlayer.Players.ElementAt(0) is INonNpc);
            Assert.AreEqual(true, singlePlayer.Players.ElementAt(1) is IAi);
            Assert.AreEqual(2, singlePlayer.Players.Count());
        }

        [Test]
        public void BuildsMultiPlayer()
        {
            List<IPlayer> collection = new List<IPlayer>();

            var p1 = Substitute.For<INonNpc>();
            p1.Slot.Returns(1);
            collection.Add(p1);

            var p2 = Substitute.For<INonNpc>();
            p2.Slot.Returns(2);
            collection.Add(p2);

            var ai = Substitute.For<IAi>();
            ai.Slot.Returns(2);
            collection.Add(ai);

            var singlePlayer = new MultiPlayer(collection);

            Assert.AreEqual(true, singlePlayer.Players.ElementAt(0) is INonNpc);
            Assert.AreEqual(true, singlePlayer.Players.ElementAt(1) is INonNpc);
            Assert.AreEqual(2, singlePlayer.Players.Count());
        }

        [Test]
        public void ThrowWithOnePlayerMultiPlayer()
        {
            List<IPlayer> collection = new List<IPlayer>();

            var p1 = Substitute.For<INonNpc>();
            p1.Slot.Returns(1);
            collection.Add(p1);
            Assert.Throws(typeof(InvalidOperationException),() => {
                var singlePlayer = new MultiPlayer(collection);
            });
        }

        [Test]
        public void ThrowWithOnePlayerSinglePlayer()
        {
            List<IPlayer> collection = new List<IPlayer>();

            var p1 = Substitute.For<INonNpc>();
            p1.Slot.Returns(1);
            collection.Add(p1);
            Assert.Throws(typeof(InvalidOperationException), () => {
                var singlePlayer = new SinglePlayer(collection);
            });
        }
    }

}
