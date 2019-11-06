using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simila.Core.Levenstein;

namespace Simila.Core.Tests.LevenshteinAlgorithmTests
{
    [TestClass]
    class LevenshteinPhraseAlgorithmTests
    {
        [TestMethod]
        public void LevenshteinPhraseAlgorithm_ShouldWork_Default()
        {
            var algorithm =
                new LevensteinAlgorithm<Phrase, Word>(
                    new WordSimilarityResolver()
                );

            AreSimilar(algorithm, "Mehran Davoudi", "Nehran Dawoody");
            AreSimilar(algorithm, "Afshin Alizadeh", "Aphshin Alizade");

            NotSimilar(algorithm, "Lilian Alpha", "Lamborghini Beta");
            NotSimilar(algorithm, "Crash the world", "Clash of clawns");
        }


        private void AreSimilar(LevensteinAlgorithm<Phrase, Word> algorithm, string left, string right)
        {
            var similarity = algorithm.GetSimilarity(left, right);
            Assert.IsTrue(similarity > 0.6, $"{left}-{right} should be similar (Similarity: {similarity})");
        }

        private void NotSimilar(LevensteinAlgorithm<Phrase, Word> algorithm, string left, string right)
        {
            var similarity = algorithm.GetSimilarity(left, right);
            Assert.IsTrue(similarity < 0.5, $"{left}-{right} should NOT be similar (Similarity: {similarity})");
        }
    }
}
