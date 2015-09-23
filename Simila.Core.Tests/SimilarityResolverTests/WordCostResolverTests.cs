using System;
using LevenshtienAlgorithm;
using NUnit.Framework;
using Simila.Core.Levenstein;
using Simila.Core.Levenstein.CostResolvers;

namespace Simila.Core.Tests
{
    [TestFixture]
    public class WordCostResolverTests
    {
        [Test(Description = "Raw DefaultCharacterSimilarityResolver should work simply.")]
        public void RawResolverShouldWorkForBasicActions()
        {
            var leven = new DefaultWordLevensteinAlgorithm();

            var simila = SimilarityResolverFactory.CreateForWord().Build();

            Assert.AreEqual(simila.GetSimilarity("AAAA", "AAAB"), leven.GetSimilarity("AAAA", "AAAB"));
            Assert.AreEqual(simila.GetSimilarity("AA", "AABB"), leven.GetSimilarity("AA", "AABB"));
            Assert.AreEqual(simila.GetSimilarity("AAA", "AA"), leven.GetSimilarity("AAA", "AA"));
        }

        [Test]
        public void MistakesShouldWork()
        {
            var simila = SimilarityResolverFactory.CreateForWord().AddEnglishCommonMistakes().Build();

            Assert.AreEqual(0.8f, simila.GetSimilarity("color", "colour"));
        }
        
        public void DefaultResolverShouldWorkForBasicActions()
        {
            var cr = SimilarityResolverFactory.CreateForWord().Default();

            //foreach (var mistake in new CommonCharacterMistakeRepository().GetCommonMistakes())
            //{
            //    Assert.AreEqual(cr.GetModificationCost(mistake.Left, mistake.Right), mistake.Similarity);
            //}
        }
    }
}
