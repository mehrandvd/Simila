using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simila.Core.Resolver;
using Simila.Core.Resolver.GeneralResolver;
using Simila.Core.Resolver.LevenshteinResolver;

namespace Simila.Core.Test.SimilarityResolverTests
{
    [TestClass]
    public class WordSimilarityResolverTests
    {
        [TestMethod]
        public void WordSimilarityResolverTests_DefaultNotCaseSensitive_ShouldWork()
        {
            var simila = new WordSimilarityResolver(
                characterSimilarityResolver: new CharacterSimilarityResolver(
                    mistakesRepository: new BuiltInCharacterMistakeRepository()
                )
            );

            AreSimilar(simila, "Mehran", "Nehran");
            AreSimilar(simila, "MEHRAN", "mehran");
            AreSimilar(simila, "Afshin", "Aphshin");
            AreSimilar(simila, "Mehran", "Nahran");
            AreSimilar(simila, "Monica", "Monika");
            AreSimilar(simila, "Nonica", "Nomika");
            AreSimilar(simila, "Crespo", "Krespo");
            AreSimilar(simila, "Monica", "Numyka");

            NotSimilar(simila, "Mehran", "RamMeh");
            NotSimilar(simila, "Penalty", "People");

        }

        [TestMethod]
        public void WordSimilarityResolverTests_Default_CaseSensitive_ShouldWork()
        {
            //var algorithm = new LevensteinAlgorithm<Word, char>(new CharacterSimilarityResolver(isCaseSensitive: true));
            var simila = new WordSimilarityResolver(
                characterSimilarityResolver: new CharacterSimilarityResolver(isCaseSensitive: true));

            AreSimilar(simila, "Mehran", "Nehran");
            NotSimilar(simila, "MEHRAN", "mehran");

            AreSimilar(simila, "Afshin", "Aphshin");
            AreSimilar(simila, "Mehran", "Nahran");
            AreSimilar(simila, "Monica", "Monika");
            AreSimilar(simila, "Nonica", "Nomika");
            AreSimilar(simila, "Crespo", "Krespo");


            NotSimilar(simila, "XXXXX", "AAAAA");
            NotSimilar(simila, "xxxxx", "aaaaa");

            NotSimilar(simila, "Mehran", "RamMeh");
            NotSimilar(simila, "Penalty", "People");
            NotSimilar(simila, "Monica", "Numyka");


        }

        [TestMethod]
        public void WordSimilarityResolverTests_CustomCharacterSimilarityResolver_ShouldWork()
        {
            var characterSimilarityResolver = new CharacterSimilarityResolver(isCaseSensitive: true);
            characterSimilarityResolver.RegisterMistake('m', 'n', 0.8f);
            characterSimilarityResolver.RegisterMistake('o', 'u', 0.7f);
            characterSimilarityResolver.RegisterMistake('i', 'y', 0.8f);
            characterSimilarityResolver.RegisterMistake('c', 'k', 0.6f);
            characterSimilarityResolver.RegisterMistake('X', 'A', 0.9f);

            var simila = new WordSimilarityResolver(
                characterSimilarityResolver: characterSimilarityResolver);

            AreSimilar(simila, "XXXXX", "AAAAA");
            NotSimilar(simila, "xxxxx", "aaaaa");


            AreSimilar(simila, "Mehran", "Nehran");
            NotSimilar(simila, "MEHRAN", "mehran");
            AreSimilar(simila, "Afshin", "Aphshin");
            AreSimilar(simila, "Mehran", "Nahran");
            AreSimilar(simila, "Monica", "Monika");
            AreSimilar(simila, "Nonica", "Nomika");
            AreSimilar(simila, "Crespo", "Krespo");
            NotSimilar(simila, "Mehran", "RamMeh");
            NotSimilar(simila, "Penalty", "People");


            AreSimilar(simila, "Monica", "Numyka");
            NotSimilar(simila, "Monica", "NUmYkA");

        }

        [TestMethod]
        public void WordSimilarityResolverTests_CustomCharacterSimilarityResolverNotCaseSensitive_ShouldWork()
        {
            var resolver = new CharacterSimilarityResolver();

            resolver.RegisterMistake('m', 'n', 0.8f);
            resolver.RegisterMistake('o', 'u', 0.7f);
            resolver.RegisterMistake('i', 'y', 0.8f);
            resolver.RegisterMistake('c', 'k', 0.6f);
            resolver.RegisterMistake('X', 'A', 0.9f);

            var simila = new WordSimilarityResolver(characterSimilarityResolver: resolver);

            AreSimilar(simila, "XXXXX", "AAAAA");
            AreSimilar(simila, "xxxxx", "aaaaa");

            AreSimilar(simila, "Monica", "Numyka");
            AreSimilar(simila, "Monica", "NUmYkA");

        }

        [TestMethod]
        public void WordSimilarityResolverTests_MistakeAndAlgorithm_ShouldWork()
        {
            var characterSimilarityResolver = new CharacterSimilarityResolver(isCaseSensitive: true);
            characterSimilarityResolver.RegisterMistake('m', 'n', 0.8f);
            characterSimilarityResolver.RegisterMistake('o', 'u', 0.7f);
            characterSimilarityResolver.RegisterMistake('i', 'y', 0.8f);
            characterSimilarityResolver.RegisterMistake('c', 'k', 0.6f);
            characterSimilarityResolver.RegisterMistake('X', 'A', 0.9f);

            var simila = new WordSimilarityResolver(
                characterSimilarityResolver: characterSimilarityResolver,
                mistakeAlgorithm: (l, r) => (l.Length != r.Length ? 0f : (float?) null)
            );

            AreSimilar(simila, "XXXXX", "AAAAA");
            NotSimilar(simila, "xxxxx", "aaaaa");


            AreSimilar(simila, "Mehran", "Nehran");
            NotSimilar(simila, "MEHRAN", "mehran");
            
            // Because of the algorithm
            NotSimilar(simila, "Afshin", "Aphshin");
            
            AreSimilar(simila, "Mehran", "Nahran");
            AreSimilar(simila, "Monica", "Monika");
            AreSimilar(simila, "Nonica", "Nomika");
            AreSimilar(simila, "Crespo", "Krespo");
            NotSimilar(simila, "Mehran", "RamMeh");
            NotSimilar(simila, "Penalty", "People");


            AreSimilar(simila, "Monica", "Numyka");
            NotSimilar(simila, "Monica", "NUmYkA");

        }

        private void AreSimilar(WordSimilarityResolver algorithm, string left, string right)
        {
            var similarity = algorithm.GetSimilarity((Word) left, (Word) right);
            Assert.IsTrue(similarity > 0.6, string.Format("{0}-{1} should be similar (Similarity: {2})", left, right, similarity));
        }

        private void NotSimilar(WordSimilarityResolver algorithm, string left, string right)
        {
            var similarity = algorithm.GetSimilarity((Word) left, (Word) right);
            Assert.IsTrue(similarity < 0.5, string.Format("{0}-{1} should NOT be similar (Similarity: {2})", left, right, similarity));
        }
    }


}
