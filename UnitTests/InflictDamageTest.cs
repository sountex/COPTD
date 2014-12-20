using System.Threading;
using NUnit.Framework;
using UnityEngine;

namespace UnitTests
{
    /// <summary>
    /// Пример теста для Coroutine
    /// </summary>
    [TestFixture]
    public class InflictDamageTest
    {
        [Test]
        [MaxTime(10000)]
        public void InflictDamage_BeginDPS()
        {
            var target = new GameObject();
            target.AddComponent<ApplyingDamage>();
            var hittable = target.AddComponent<HaveHitPoint>();
            hittable.Awake();
            var tower = new GameObject();
            var dmger = tower.AddComponent<InflictDamage>();
            dmger.BeginDPS(hittable);
            //Симулируем работу Coroutine
            while (dmger.inflictDamage().MoveNext())
                Thread.Sleep(100);
            Assert.True(hittable.IsDead);
        }
    }
}