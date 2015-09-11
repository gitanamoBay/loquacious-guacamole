using NUnit.Framework;

namespace Loquacious.Ai.Tests
{
    [TestFixture]
    public class RandomStratTest
    {
        [Test]
        [Repeat(1000)]
        public void RandomStratDoesntReturnNoPick()
        {
            var rando = new RandomStratergy();

            rando.Consider(null);

            Assert.AreNotEqual(Values.Pick.None,rando.SuggestedPick);
        }

        [Test]
        [Repeat(1000)]
        public void RandomStratDoesntThrow()
        {
            var rando = new RandomStratergy();
            Assert.DoesNotThrow(() => {
                rando.Consider(null);
            });
        }

        [Test]
        public void RandomStratDefaultsToNoPick()
        {
            var rando = new RandomStratergy();
            Assert.AreEqual(Values.Pick.None, rando.SuggestedPick);
        }

    }
}
