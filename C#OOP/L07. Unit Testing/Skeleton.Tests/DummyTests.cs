using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int axeAtack = 1;

        private const int aliveDummyHealth = 10;

        private const int deadDummyHealth = 0;

        private const int deadDummyExperience = 20;

        private const int aliveDummyExperience = 30;


        private Dummy aliveDummy;

        private Dummy deadDummy;

        
        [SetUp]
        public void TestInit()
        {
            aliveDummy = new Dummy(aliveDummyHealth, aliveDummyExperience);
            deadDummy = new Dummy(deadDummyHealth, deadDummyExperience);
        }


        [Test]
        public void DummyLosesHealthIfAtacked()
        {
            aliveDummy.TakeAttack(axeAtack);

            Assert.That(aliveDummy.Health, Is.EqualTo(9), "Dummy health doesn't change after attack");
        }


        [Test]
        public void AttackDeadDummy()
        {
            Assert.That(() => deadDummy.TakeAttack(axeAtack),
                Throws.InvalidOperationException);
        }

        [Test]
        public void DeadDummyCantGiveExp()
        {
            Assert.That(deadDummy.GiveExperience(), Is.EqualTo(20));
        }

        [Test]
        public void AliveDummyCannotGiveExperience()
        {
            aliveDummy.TakeAttack(axeAtack);

            Assert.That(() => { aliveDummy.GiveExperience(); }, Throws.InvalidOperationException);
        }


    }
}