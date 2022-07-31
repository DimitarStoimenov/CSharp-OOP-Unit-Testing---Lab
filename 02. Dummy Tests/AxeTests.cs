using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [TestCase(10, 10)]

        public void ConstructorValidator(int num , int num1)
        {
            Axe axe = new Axe(num, num1);

            Assert.AreEqual(axe.AttackPoints, 10);
            Assert.AreEqual(axe.DurabilityPoints, 10);
        }
          
        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);
            int expected = axe.DurabilityPoints;

            Assert.AreEqual(expected, 9, "Axe Durability doesn't change after attack.");


        }

        [TestCase(10, 0)]
        [TestCase(10, -1)]

       public void WeaponIsBroken(int points, int durability)
        {
            Axe axe = new Axe(points, durability);
            Dummy dummy = new Dummy(10, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            }, "Axe is broken.");

        }
    }
}