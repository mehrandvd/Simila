using System;
using NUnit.Framework;
using Simila.Core.SimilarityResolvers;

namespace Simila.Core.Tests
{
    [TestFixture]
    public class CharacterMistakeBasedSimilarityResolverTests
    {
        [Test]
        public void CharacterMistakeBased_ShouldWork_Raw()
        {
            var simila = new CharacterSimilarityResolverDefault();

            Assert.AreEqual(1, simila.GetSimilarity('a', 'a'), "'a', 'a'");
            Assert.AreEqual(0, simila.GetSimilarity('A', 'a'), "'A', 'a'");
            Assert.AreEqual(0, simila.GetSimilarity('a', 'A'), "'a', 'A'");

            Assert.AreEqual(0, simila.GetSimilarity('a', 'b'), "'a', 'b'");
            Assert.AreEqual(0, simila.GetSimilarity('a', 'B'), "'a', 'B'");
            Assert.AreEqual(0, simila.GetSimilarity('c', 'k'), "'c', 'k'");
        }

        [Test]
        public void CharacterMistakeBased_ShouldWork_NotCaseSensitive()
        {
            var simila = new CharacterSimilarityResolverDefault() { IsCaseSensitive = false };

            Assert.AreEqual(simila.GetSimilarity('a', 'a'), 1);
            Assert.AreEqual(simila.GetSimilarity('A', 'a'), 1);
            Assert.AreEqual(simila.GetSimilarity('a', 'A'), 1);

            Assert.AreEqual(simila.GetSimilarity('a', 'b'), 0);
            Assert.AreEqual(simila.GetSimilarity('a', 'B'), 0);
        }

        [Test]
        public void CharacterMistakeBased_ShouldWork_DefinedMistakes()
        {
            var simila = new CharacterSimilarityResolverDefault();

            simila.SetMistakeSimilarity('c', 'k', 0.7f);


            Assert.AreEqual(simila.GetSimilarity('a', 'b'), 0);
            Assert.AreEqual(simila.GetSimilarity('a', 'B'), 0);

            Assert.AreEqual(simila.GetSimilarity('c', 'k'), 0.7f);
            Assert.AreEqual(simila.GetSimilarity('k', 'c'), 0.7f);

            Assert.AreEqual(simila.GetSimilarity('c', 'K'), 0);
            Assert.AreEqual(simila.GetSimilarity('K', 'c'), 0);

            Assert.AreEqual(simila.GetSimilarity('C', 'k'), 0);
            Assert.AreEqual(simila.GetSimilarity('k', 'C'), 0);
        }

        [Test]
        public void CharacterMistakeBased_ShouldWork_DefinedMistakes_NotCaseSensitive()
        {
            var simila = new CharacterSimilarityResolverDefault() { IsCaseSensitive = false };

            simila.SetMistakeSimilarity('c', 'k', 0.7f);


            Assert.AreEqual( 0   , simila.GetSimilarity('a', 'b'));
            Assert.AreEqual( 0   , simila.GetSimilarity('a', 'B'));
                                 
            Assert.AreEqual( 0.7f, simila.GetSimilarity('c', 'k'));
            Assert.AreEqual( 0.7f, simila.GetSimilarity('k', 'c'));
                                  
            Assert.AreEqual( 0.7f, simila.GetSimilarity('c', 'K'));
            Assert.AreEqual( 0.7f, simila.GetSimilarity('K', 'c'));
                                  
            Assert.AreEqual( 0.7f, simila.GetSimilarity('C', 'k'));
            Assert.AreEqual( 0.7f, simila.GetSimilarity('k', 'C'));
        }

        [Test]
        public void CharacterMistakeBased_ShouldWork_WithEmptyAndNumericInputs()
        {
            var simila = new CharacterSimilarityResolverDefault() { CostOfNumeric = 0.3f };

            Assert.AreEqual(0f, simila.GetSimilarity('c', 'k'));
            Assert.AreEqual(0f, simila.GetSimilarity(default(char), 'k'));
            Assert.AreEqual(0f, simila.GetSimilarity('k', default(char)));
            Assert.AreEqual(0.3f, simila.GetSimilarity('3', default(char)));
            Assert.AreEqual(0.3f, simila.GetSimilarity(default(char), '4'));
        }
    }
}
