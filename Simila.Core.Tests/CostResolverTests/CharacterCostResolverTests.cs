using System;
using NUnit.Framework;
using Simila.Core.Levenstein.CostResolvers;

namespace Simila.Core.Tests
{
    [TestFixture]
    public class CharacterCostResolverTests
    {
        [Test(Description = "Raw CharacterCostResolver should work simply.")]
        public void RawResolverShouldWorkForBasicActions()
        {
            var cr = CostResolverFactory.CreateForCharacter().Build();

            Assert.AreEqual(cr.GetUpdateCost('a', 'a'), 0);
            Assert.AreEqual(cr.GetUpdateCost('A', 'a'), 0);
            Assert.AreEqual(cr.GetUpdateCost('a', 'A'), 0);
            
            Assert.AreEqual(cr.GetUpdateCost('a', 'b'), 1);
            Assert.AreEqual(cr.GetUpdateCost('a', 'B'), 1);
        }

        public void DefaultResolverShouldWorkForBasicActions()
        {
            var cr = CostResolverFactory.CreateForCharacter().Default();

            //foreach (var mistake in new CommonCharacterMistakeRepository().GetCommonMistakes())
            //{
            //    Assert.AreEqual(cr.GetUpdateCost(mistake.Left, mistake.Right), mistake.Cost);
            //}
        }
    }
}
