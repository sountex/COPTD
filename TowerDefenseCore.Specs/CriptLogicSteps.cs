using System;
using NUnit.Core;
using TechTalk.SpecFlow;
using UnityEngine;

namespace TowerDefenseCore.Specs
{
    [Binding]
    public class CripLogicSteps
    {
        private HaveHitPoint _crip;

        [Given(@"Crip is alive")]
        public void GivenCripIsAlive()
        {
            var componentsHolder = new GameObject();
            componentsHolder.AddComponent<ApplyingDamage>();
            _crip = componentsHolder.AddComponent<HaveHitPoint>();
            _crip.Awake();
        }

        [When(@"Crip HP - (.*)")]
        public void WhenCripHP_(int dmg)
        {
            _crip.ImpactDamage(dmg);
        }

        [Then(@"Crip is dead")]
        public void ThenCripIsDead()
        {
            NUnitFramework.Assert.AreEqual(true, _crip.IsDead);
        }
    }
}
