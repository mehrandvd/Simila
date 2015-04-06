using System;
using LevenshtienAlgorithm;
using NUnit.Framework;
using Simila.Core.Levenstein.CostResolvers;

namespace Simila.Core.Tests
{
    [TestFixture]
    public class WordCostResolverTests
    {
        [Test(Description = "Raw CharacterCostResolver should work simply.")]
        public void RawResolverShouldWorkForBasicActions()
        {
            var leven = new WordLevenshteinAlgorithm();

            var cr = CostResolverFactory.CreateForWord().Build();

            Assert.AreEqual(cr.GetUpdateCost("AAAA", "AAAB"), 1 - leven.GetSimilarity("AAAA", "AAAB"));
            Assert.AreEqual(cr.GetUpdateCost("AA", "AABB"), 1 - leven.GetSimilarity("AA", "AABB"));
            Assert.AreEqual(cr.GetUpdateCost("AAA", "AA"), 1 - leven.GetSimilarity("AAA", "AA"));
        }

        [Test]
        public void MistakesShouldWork()
        {
            var cr = CostResolverFactory.CreateForWord().AddEnglishCommonMistakes().Build();

            Assert.AreEqual(cr.GetUpdateCost("color", "colour"), 0.2);
        }
        
        public void DefaultResolverShouldWorkForBasicActions()
        {
            var cr = CostResolverFactory.CreateForWord().Default();

            //foreach (var mistake in new CommonCharacterMistakeRepository().GetCommonMistakes())
            //{
            //    Assert.AreEqual(cr.GetUpdateCost(mistake.Left, mistake.Right), mistake.Cost);
            //}
        }
    }
}
