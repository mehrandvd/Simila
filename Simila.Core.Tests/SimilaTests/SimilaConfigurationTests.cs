using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simila.Core.Resolver;
using Simila.Core.Resolver.GeneralResolver;
using Simila.Core.Resolver.LevenshteinResolver;

namespace Simila.Core.Test.SimilaTests
{
    [TestClass]
    public class SimilaConfigurationTests
    {
        [TestMethod]
        public void Simila_ShouldWork_WithOverridingConfigs()
        {
            var simila = new Simila(threshold: 1);

            Assert.IsFalse(simila.AreSimilar("Cat", "Kat"));
            Assert.IsFalse(simila.AreSimilar("color", "colour"));
            
            var customSimila = new Simila(
                threshold: 1,
                resolver: new PhraseSimilarityResolver(
                    wordSimilarityResolver: new WordSimilarityResolver(
                        mistakesRepository: new MistakeRepository<Word>(new Mistake<Word>[]
                        {
                            ("color", "colour", 1)
                        }),
                        characterSimilarityResolver: new CharacterSimilarityResolver(
                            mistakesRepository: new MistakeRepository<char>(
                                new Mistake<char>[]
                                {
                                    ('c', 'k', 1)
                                })
                        )
                    )
                )
            );

            Assert.IsTrue(customSimila.AreSimilar("Cat", "Kat"));
            Assert.IsTrue(customSimila.AreSimilar("color", "colour"));
        }

        [TestMethod]
        public void Simila_ShouldWork_WithSoundex()
        {
            var simila = new Simila(threshold: .7f);

            Assert.IsFalse(simila.AreSimilar("Mehran", "Maryam"));
            Assert.IsFalse(simila.AreSimilar("Mehran", "Mina"));

            var soundex = new Simila(
                threshold: .7f,
                resolver: new SoundexSimilarityResolver()
            );

            Assert.IsTrue(soundex.AreSimilar("Mehran", "Maryam"));
            Assert.IsTrue(soundex.AreSimilar("Mehran", "Mina"));
            
            Assert.IsFalse(soundex.AreSimilar("Mehran", "Sobhan"));
            Assert.IsFalse(soundex.AreSimilar("Mehran", "Afshin"));
            Assert.IsFalse(soundex.AreSimilar("Sobhan", "Afshin"));
        }


        [TestMethod]
        public void Simila_ShouldWork_WithOverridingIntroducingMistakes()
        {
            var simila = new Simila();

            Assert.IsFalse(simila.AreSimilar("War", "Fight"));

            var customSimila = new Simila(
                resolver: new PhraseSimilarityResolver(
                    wordSimilarityResolver: new WordSimilarityResolver(
                        mistakesRepository: new MistakeRepository<Word>(new Mistake<Word>[]
                        {
                            ("War", "Fight", .9f),
                            ("color", "colour", 1)
                        })
                    )
                )
            );


            Assert.IsTrue(customSimila.AreSimilar("War", "Fight"));

            Assert.IsTrue(customSimila.AreSimilar("color", "colour"));
        }
    }
}
