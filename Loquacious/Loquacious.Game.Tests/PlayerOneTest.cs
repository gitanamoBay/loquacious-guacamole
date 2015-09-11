using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Loquacious.Interfaces;
using Loquacious.Values;
using NSubstitute;
using NUnit.Framework;

namespace Loquacious.Game.Tests
{
    [TestFixture]
    public class PlayerOneTests
    {
        [Test]
        public void KeysArentAccepted()
        {
            INonNpc npc = new PlayerOne();
            for (int i = 1; i < 172; i ++)
            {
                var key = (Key) i;
                npc.OpenControls();
                if (key != Key.W && key != Key.E && key != Key.R)
                    Assert.AreEqual(false, npc.KeyStroke(key));
            }
        }

        [Test]
        public void KeysAreBound()
        {
            INonNpc npc = new PlayerOne();

            npc.OpenControls();
            Assert.AreEqual(true, npc.KeyStroke(Key.W));
            Assert.AreEqual(Pick.Rock, npc.Pick);

            npc.OpenControls();
            Assert.AreEqual(true, npc.KeyStroke(Key.E));
            Assert.AreEqual(Pick.Paper, npc.Pick);

            npc.OpenControls();
            Assert.AreEqual(true, npc.KeyStroke(Key.R));
            Assert.AreEqual(Pick.Scissors, npc.Pick);

        }

        [Test]
        public void PlayerSlot()
        {
            INonNpc npc = new PlayerOne();
            Assert.AreEqual(1,npc.Slot);
        }

        [Test]
        public void KeysArentAcceptedWhenLocked()
        {
            INonNpc npc = new PlayerOne();
            for (int i = 1; i < 172; i++)
            {
                var key = (Key)i;

                Assert.AreEqual(false, npc.KeyStroke(key));
            }
        }

    }
}
