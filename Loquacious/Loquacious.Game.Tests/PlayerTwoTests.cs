using System.Windows.Input;
using Loquacious.Interfaces;
using Loquacious.Values;
using NUnit.Framework;

namespace Loquacious.Game.Tests
{
    [TestFixture]
    public class PlayerTwoTests
    {
        [Test]
        public void KeysArentAccepted()
        {
            INonNpc npc = new PlayerTwo();
            for (int i = 1; i < 172; i++)
            {
                var key = (Key)i;
                npc.OpenControls();
                if (key != Key.Left && key != Key.Down && key != Key.Right)
                    Assert.AreEqual(false, npc.KeyStroke(key));
            }
        }


        [Test]
        public void KeysAreBound()
        {
            INonNpc npc = new PlayerTwo();

            npc.OpenControls();
            Assert.AreEqual(true, npc.KeyStroke(Key.Left));
            Assert.AreEqual(Pick.Rock,npc.Pick);

            npc.OpenControls();
            Assert.AreEqual(true, npc.KeyStroke(Key.Down));
            Assert.AreEqual(Pick.Paper, npc.Pick);

            npc.OpenControls();
            Assert.AreEqual(true, npc.KeyStroke(Key.Right));
            Assert.AreEqual(Pick.Scissors, npc.Pick);

        }
        [Test]
        public void PlayerSlot()
        {
            INonNpc npc = new PlayerTwo();
            Assert.AreEqual(2, npc.Slot);
        }
        [Test]
        public void KeysArentAcceptedWhenLocked()
        {
            INonNpc npc = new PlayerTwo();
            for (int i = 1; i < 172; i++)
            {
                var key = (Key)i;

                Assert.AreEqual(false, npc.KeyStroke(key));
            }
        }

    }
}