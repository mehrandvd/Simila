using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simila.Core.Levenstein;

namespace Simila.Core.Tests.LevenshteinAlgorithmTests
{
    [TestClass]
    public class LevenshteinWordAlgorithmTests
    {
        [TestMethod]
        public void LevenshteinWordAlgorithm_DefaultNotCaseSensitive_ShouldWork()
        {
            var algorithm = new LevensteinAlgorithm<Word, char>(new CharacterSimilarityResolver(mistakesRepository: new BuiltInCharacterMistakeRepository()));

            AreSimilar(algorithm, "Mehran", "Nehran");
            AreSimilar(algorithm, "MEHRAN", "mehran");
            AreSimilar(algorithm, "Afshin", "Aphshin");
            AreSimilar(algorithm, "Mehran", "Nahran");
            AreSimilar(algorithm, "Monica", "Monika");
            AreSimilar(algorithm, "Nonica", "Nomika");
            AreSimilar(algorithm, "Crespo", "Krespo");
            AreSimilar(algorithm, "Monica", "Numyka");

            NotSimilar(algorithm, "Mehran", "RamMeh");
            NotSimilar(algorithm, "Penalty", "People");

        }

        [TestMethod]
        public void LevenshteinWordAlgorithm_Default_CaseSensitive_ShouldWork()
        {
            var algorithm = new LevensteinAlgorithm<Word, char>(new CharacterSimilarityResolver(isCaseSensitive: true));

            AreSimilar(algorithm, "Mehran", "Nehran");
            NotSimilar(algorithm, "MEHRAN", "mehran");

            AreSimilar(algorithm, "Afshin", "Aphshin");
            AreSimilar(algorithm, "Mehran", "Nahran");
            AreSimilar(algorithm, "Monica", "Monika");
            AreSimilar(algorithm, "Nonica", "Nomika");
            AreSimilar(algorithm, "Crespo", "Krespo");


            NotSimilar(algorithm, "XXXXX", "AAAAA");
            NotSimilar(algorithm, "xxxxx", "aaaaa");

            NotSimilar(algorithm, "Mehran", "RamMeh");
            NotSimilar(algorithm, "Penalty", "People");
            NotSimilar(algorithm, "Monica", "Numyka");


        }

        [TestMethod]
        public void LevenshteinWordAlgorithm_CustomCharacterSimilarityResolver_ShouldWork()
        {
            var resolver = new CharacterSimilarityResolver(isCaseSensitive: true);

            resolver.RegisterMistake('m', 'n', 0.8f);
            resolver.RegisterMistake('o', 'u', 0.7f);
            resolver.RegisterMistake('i', 'y', 0.8f);
            resolver.RegisterMistake('c', 'k', 0.6f);

            resolver.RegisterMistake('X', 'A', 0.9f);

            var algorithm = new LevensteinAlgorithm<Word, char>(resolver);

            AreSimilar(algorithm, "XXXXX", "AAAAA");
            NotSimilar(algorithm, "xxxxx", "aaaaa");


            AreSimilar(algorithm, "Mehran", "Nehran");
            NotSimilar(algorithm, "MEHRAN", "mehran");
            AreSimilar(algorithm, "Afshin", "Aphshin");
            AreSimilar(algorithm, "Mehran", "Nahran");
            AreSimilar(algorithm, "Monica", "Monika");
            AreSimilar(algorithm, "Nonica", "Nomika");
            AreSimilar(algorithm, "Crespo", "Krespo");
            NotSimilar(algorithm, "Mehran", "RamMeh");
            NotSimilar(algorithm, "Penalty", "People");


            AreSimilar(algorithm, "Monica", "Numyka");
            NotSimilar(algorithm, "Monica", "NUmYkA");

        }

        [TestMethod]
        public void LevenshteinWordAlgorithm_CustomCharacterSimilarityResolverNotCaseSensitive_ShouldWork()
        {
            var resolver = new CharacterSimilarityResolver();

            resolver.RegisterMistake('m', 'n', 0.8f);
            resolver.RegisterMistake('o', 'u', 0.7f);
            resolver.RegisterMistake('i', 'y', 0.8f);
            resolver.RegisterMistake('c', 'k', 0.6f);
            resolver.RegisterMistake('X', 'A', 0.9f);

            var algorithm = new LevensteinAlgorithm<Word, char>(resolver);

            AreSimilar(algorithm, "XXXXX", "AAAAA");
            AreSimilar(algorithm, "xxxxx", "aaaaa");

            AreSimilar(algorithm, "Monica", "Numyka");
            AreSimilar(algorithm, "Monica", "NUmYkA");

        }

        private void AreSimilar(LevensteinAlgorithm<Word, char> algorithm, string left, string right)
        {
            var similarity = algorithm.GetSimilarity(left, right);
            Assert.IsTrue(similarity > 0.6, $"{left}-{right} should be similar (Similarity: {similarity})");
        }

        private void NotSimilar(LevensteinAlgorithm<Word, char> algorithm, string left, string right)
        {
            var similarity = algorithm.GetSimilarity(left, right);
            Assert.IsTrue(similarity < 0.5, $"{left}-{right} should NOT be similar (Similarity: {similarity})");
        }
    }


}
