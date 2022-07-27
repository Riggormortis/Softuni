using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {

        private const int axeAtack = 10;

        private const int axeDurability = 10;

        private const int brokenAxeDurability = 0;

        private const int dummyHealth = 10;

        private const int dummyExperience = 10;

        private Axe axe;

        private Axe brokenAxe;

        private Dummy dummy;


        [SetUp]
        public void TestInit()
        {
            axe = new Axe(axeAtack, axeDurability);
            brokenAxe = new Axe(axeAtack, brokenAxeDurability);
            dummy = new Dummy(dummyHealth, dummyExperience);
        }

        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe durability doesn't change after attack");
        }

        [Test]
        public void AttackWithBrokenWeaponThrowsInvalidOperationException()
        {
            Assert.That(() => brokenAxe.Attack(dummy), Throws.InvalidOperationException);
        }

    }


}