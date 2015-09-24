using NUnit.Framework;
using Simila.Core.Levenstein;
using Simila.Core.SimilarityResolvers;

namespace Simila.Core.Tests.LevensteinAlgorithmTests
{
    [TestFixture]
    class PhraseLevensteinAlgorithmTests
    {
        [Test]
        public void PhraseLevensteinAlgorithm_ShouldWork_NotCaseSensitive()
        {
            var algorithm = 
                new LevensteinAlgorithm<Phrase, Word>(
                    new WordSimilarityResolverDefault()
                );

            AreSimilar(algorithm, "Mehran Davoudi", "Nehran Dawoody");
            AreSimilar(algorithm, "Afshin Alizadeh", "Aphshin Alizade");

            NotSimilar(algorithm, "Lilian Alpha", "Lamborghini Beta");
            NotSimilar(algorithm, "Crash the world", "Clash of clawns");
        }


        private void AreSimilar(LevensteinAlgorithm<Phrase, Word> algorithm, string left, string right)
        {
            var similarity = algorithm.GetSimilarity(left, right);
            Assert.Greater(similarity, 0.6, string.Format("{0}-{1} should be similar (Similarity: {2})", left, right, similarity));
        }

        private void NotSimilar(LevensteinAlgorithm<Phrase, Word> algorithm, string left, string right)
        {
            var similarity = algorithm.GetSimilarity(left, right);
            Assert.Less(similarity, 0.5, string.Format("{0}-{1} should NOT be similar (Similarity: {2})", left, right, similarity));
        }









        //readonly PhraseSimilarityResolverLevenstein _leven = new PhraseSimilarityResolverLevenstein();

        //[Test]
        //public void SimpleSimilarityMustWork()
        //{
        //    AreSimilar("Mehran Davoudi", "Nehran Dawoody");
        //    AreSimilar("Afshin Alizadeh", "Aphshin Alizade");

        //    NotSimilar("Lilian Alpha", "Lamborghini Beta");
        //    NotSimilar("Crash the world", "Clash of clawns");
        //}


        //private void AreSimilar(string left, string right)
        //{
        //    Assert.IsTrue(_leven.GetSimilarity(left, right) > 0.7, string.Format("{0}-{1} should be similar,", left, right));
        //}

        //private void NotSimilar(string left, string right)
        //{
        //    Assert.IsTrue(_leven.GetSimilarity(left, right) < 0.3, string.Format("{0}-{1} should NOT be similar,", left, right));
        //}
        
    }
}
