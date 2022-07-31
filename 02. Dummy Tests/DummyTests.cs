using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        public void ConstructorValidator(int num, int num1)
        {
            Dummy dummy = new Dummy(num, num1);

            Assert.AreEqual(dummy.Health, 10);
            Assert.AreEqual(num1, 10);
        }
        [TestCase(10, 11)]
        [TestCase(4, 6)]
        
        public void DoomiLoosesHealtIfAttack(int attackpoints, int health)
        {
            
            Dummy dummy = new Dummy(health, attackpoints);

           dummy.TakeAttack(attackpoints);
            int isresult = health - attackpoints;
            var current = dummy.Health;
            

            Assert.AreEqual(isresult, current);
        }

        [TestCase(0, 10)]
        [TestCase(-1, 10)]
         public void TheDummyIsDead(int health, int experience)
        {
           
             Dummy dummy = new Dummy(health, experience);
           
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(10));

        }

        [TestCase(0, 10)]
        [TestCase(-1, 10)]
        [TestCase(-10, 10)]
        [TestCase(-15, 10)]

        public void DeadDummyCanGiveExperience(int healt, int experience)
        {
            Dummy dummy = new Dummy(healt, experience);

            var result = dummy.GiveExperience();
            Assert.AreEqual(result, experience);
        }

        [TestCase(1, 10)]
        [TestCase(5, 10)]
       
        

        public void AliveDummyCantGiveExperience(int healt, int experience)
        {
              Dummy dummy = new Dummy(healt, experience);
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());

        }
    }
}