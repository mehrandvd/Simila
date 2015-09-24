using NUnit.Framework;
using Simila.Core.SimilarityResolvers;

namespace Simila.Core.Tests.Old
{
    [TestFixture]
    public class WordCostResolverTests
    {
        //[Test(Description = "Raw CharacterSimilarityResolverDefault should work simply.")]
        //public void RawResolverShouldWorkForBasicActions()
        //{
        //    var leven = new WordSimilarityResolverDefault();

        //    var simila = SimilarityResolverFactory.CreateForWordMistakeBased().Build();

        //    Assert.AreEqual(simila.GetSimilarity("AAAA", "AAAB"), leven.GetSimilarity("AAAA", "AAAB"));
        //    Assert.AreEqual(simila.GetSimilarity("AA", "AABB"), leven.GetSimilarity("AA", "AABB"));
        //    Assert.AreEqual(simila.GetSimilarity("AAA", "AA"), leven.GetSimilarity("AAA", "AA"));
        //}

        //[Test]
        //public void MistakesShouldWork()
        //{
        //    var simila = SimilarityResolverFactory.CreateForWordMistakeBased().AddEnglishCommonMistakes().Build();

        //    Assert.AreEqual(0.8f, simila.GetSimilarity("color", "colour"));
        //}
        
        //public void DefaultResolverShouldWorkForBasicActions()
        //{
        //    var cr = SimilarityResolverFactory.CreateForWordMistakeBased().Default();

        //    //foreach (var mistake in new CommonCharacterMistakeRepository().GetCommonMistakes())
        //    //{
        //    //    Assert.AreEqual(cr.GetModificationCost(mistake.Left, mistake.Right), mistake.Similarity);
        //    //}
        //}
    }
}
