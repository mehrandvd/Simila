using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Simila.Core.Levenstein;

namespace Simila.Core.Tests.LevensteinAlgorithmTests
{
    [TestFixture]
    public class WordLevensteinAlgorithmTests
    {
        [Test]
        public void WordLevensteinAlgorithm_ShouldWork_Default_NotCaseSensitive()
        {
            var algorithm = new LevensteinAlgorithm<Word, char>(new CharacterSimilarityResolverDefault(){IsCaseSensitive = false});

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

        [Test]
        public void WordLevensteinAlgorithm_ShouldWork_Default_CaseSensitive()
        {
            var algorithm = new LevensteinAlgorithm<Word, char>(new CharacterSimilarityResolverDefault() { IsCaseSensitive = true });

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

        [Test]
        public void WordLevensteinAlgorithm_ShouldWork_CustomCharacterSimiarityResolver()
        {
            var resolver = new CharacterSimilarityResolverDefault(null) {IsCaseSensitive = true};

            resolver.SetMistakeSimilarity('m', 'n', 0.8f);
            resolver.SetMistakeSimilarity('o', 'u', 0.7f);
            resolver.SetMistakeSimilarity('i', 'y', 0.8f);
            resolver.SetMistakeSimilarity('c', 'k', 0.6f);
            
            resolver.SetMistakeSimilarity('X', 'A', 0.9f);

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

        [Test]
        public void WordLevensteinAlgorithm_ShouldWork_CustomCharacterSimiarityResolver_NotCaseSensitive()
        {
            var resolver = new CharacterSimilarityResolverDefault(null) { IsCaseSensitive = false };

            resolver.SetMistakeSimilarity('m', 'n', 0.8f);
            resolver.SetMistakeSimilarity('o', 'u', 0.7f);
            resolver.SetMistakeSimilarity('i', 'y', 0.8f);
            resolver.SetMistakeSimilarity('c', 'k', 0.6f);
            resolver.SetMistakeSimilarity('X', 'A', 0.9f);

            var algorithm = new LevensteinAlgorithm<Word, char>(resolver);

            AreSimilar(algorithm, "XXXXX", "AAAAA");
            AreSimilar(algorithm, "xxxxx", "aaaaa");

            AreSimilar(algorithm, "Monica", "Numyka");
            AreSimilar(algorithm, "Monica", "NUmYkA");

        }

        private void AreSimilar(LevensteinAlgorithm<Word, char> algorithm, string left, string right)
        {
            var similarity = algorithm.GetSimilarity(left, right);
            Assert.Greater(similarity, 0.6, string.Format("{0}-{1} should be similar (Similarity: {2})", left, right, similarity));
        }

        private void NotSimilar(LevensteinAlgorithm<Word, char> algorithm, string left, string right)
        {
            var similarity = algorithm.GetSimilarity(left, right);
            Assert.Less(similarity, 0.5, string.Format("{0}-{1} should NOT be similar (Similarity: {2})", left, right, similarity));
        }
    }


}
