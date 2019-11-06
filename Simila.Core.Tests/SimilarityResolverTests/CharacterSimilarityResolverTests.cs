using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simila.Core.Tests
{
    [TestClass]
    public class CharacterSimilarityResolverTests
    {
        [TestMethod]
        public void CharacterSimilarityResolver_RawCaseSensitive_ShouldWork()
        {
            var simila = new CharacterSimilarityResolver(isCaseSensitive: true);

            Assert.AreEqual(1, simila.GetSimilarity('a', 'a'), "'a', 'a'");
            Assert.AreEqual(0, simila.GetSimilarity('A', 'a'), "'A', 'a'");
            Assert.AreEqual(0, simila.GetSimilarity('a', 'A'), "'a', 'A'");

            Assert.AreEqual(0, simila.GetSimilarity('a', 'b'), "'a', 'b'");
            Assert.AreEqual(0, simila.GetSimilarity('a', 'B'), "'a', 'B'");
            Assert.AreEqual(0, simila.GetSimilarity('c', 'k'), "'c', 'k'");
        }

        [TestMethod]
        public void CharacterSimilarityResolver_NotCaseSensitive_ShouldWork()
        {
            var simila = new CharacterSimilarityResolver(isCaseSensitive: false);

            Assert.AreEqual(simila.GetSimilarity('a', 'a'), 1);
            Assert.AreEqual(simila.GetSimilarity('A', 'a'), 1);
            Assert.AreEqual(simila.GetSimilarity('a', 'A'), 1);

            Assert.AreEqual(simila.GetSimilarity('a', 'b'), 0);
            Assert.AreEqual(simila.GetSimilarity('a', 'B'), 0);
        }

        [TestMethod]
        public void CharacterSimilarityResolver_RegisterMistakesCaseSensitive_ShouldWork()
        {
            var simila = new CharacterSimilarityResolver(isCaseSensitive: true);

            simila.RegisterMistake('c', 'k', 0.7f);


            Assert.AreEqual(simila.GetSimilarity('a', 'b'), 0);
            Assert.AreEqual(simila.GetSimilarity('a', 'B'), 0);

            Assert.AreEqual(simila.GetSimilarity('c', 'k'), 0.7f);
            Assert.AreEqual(simila.GetSimilarity('k', 'c'), 0.7f);

            Assert.AreEqual(simila.GetSimilarity('c', 'K'), 0);
            Assert.AreEqual(simila.GetSimilarity('K', 'c'), 0);

            Assert.AreEqual(simila.GetSimilarity('C', 'k'), 0);
            Assert.AreEqual(simila.GetSimilarity('k', 'C'), 0);
        }

        [TestMethod]
        public void CharacterSimilarityResolver_DefinedMistakesNotCaseSensitive_ShouldWork()
        {
            var simila = new CharacterSimilarityResolver(isCaseSensitive: false);

            simila.RegisterMistake('c', 'k', 0.7f);


            Assert.AreEqual( 0   , simila.GetSimilarity('a', 'b'));
            Assert.AreEqual( 0   , simila.GetSimilarity('a', 'B'));
                                 
            Assert.AreEqual( 0.7f, simila.GetSimilarity('c', 'k'));
            Assert.AreEqual( 0.7f, simila.GetSimilarity('k', 'c'));
                                  
            Assert.AreEqual( 0.7f, simila.GetSimilarity('c', 'K'));
            Assert.AreEqual( 0.7f, simila.GetSimilarity('K', 'c'));
                                  
            Assert.AreEqual( 0.7f, simila.GetSimilarity('C', 'k'));
            Assert.AreEqual( 0.7f, simila.GetSimilarity('k', 'C'));
        }

        [TestMethod]
        public void CharacterSimilarityResolver_WithEmptyAndNumericInputs_ShouldWork()
        {
            var simila = new CharacterSimilarityResolver(numericSimilarityRate: .3f);

            Assert.AreEqual(0f, simila.GetSimilarity('c', 'k'));
            Assert.AreEqual(0f, simila.GetSimilarity(default(char), 'k'));
            Assert.AreEqual(0f, simila.GetSimilarity('k', default(char)));
            Assert.AreEqual(0.3f, simila.GetSimilarity('3', default(char)));
            Assert.AreEqual(0.3f, simila.GetSimilarity(default(char), '4'));
        }

        [TestMethod]
        public void CharacterSimilarityResolver_WithAlgorithmAndMistake_ShouldWork()
        {
            var simila = new CharacterSimilarityResolver(
                mistakeAlgorithm: (l,r)=> (l=='.' || r=='.' ? 1f : (float?) null)
                );

            simila.RegisterMistake('c', 'k', 0.7f);

            Assert.AreEqual(0, simila.GetSimilarity('a', 'B'));

            Assert.AreEqual(1, simila.GetSimilarity('.', 'b'));

            Assert.AreEqual(0.7f, simila.GetSimilarity('c', 'k'));
        }
    }
}
