using NUnit.Framework;
using UnityEngine;

namespace UnitTests
{
    /// <summary>
    /// Простой пример теста компонента без GameObject.Instantiate объекта
    /// </summary>
    [TestFixture]
    public class HittableTest
    {
        [Test]
        public void ApplyingDamage_ImpactDamage()
        {
            var damageDealer = new ApplyingDamage();
            var hp = damageDealer.ImpactDamage(100, 10);
            Assert.AreEqual(90f, hp);
        }

        [Test]
        public void HaveHitPoint_ImpactDamageAndDead()
        {
            var componentsHolder = new GameObject();
            componentsHolder.AddComponent<ApplyingDamage>();
            var hittable = componentsHolder.AddComponent<HaveHitPoint>();
            hittable.Awake();//!Важно: мы не сделали инстанс объекта, потому вручную внедрим зависимость от ApplyingDamage
            hittable.ImpactDamage(50);
            Assert.AreEqual(50, hittable.HP);

            hittable.ImpactDamage(50);
            Assert.AreEqual(true, hittable.IsDead);
        }
    }
}
