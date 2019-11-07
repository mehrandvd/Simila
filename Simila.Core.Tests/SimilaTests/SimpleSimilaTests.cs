using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simila.Core.Tests.SimilaStringTests
{
    [TestClass]
    public class SimpleSimilaTests
    {
        [TestMethod]
        public void Simila_ShouldWork_WithNoConfig()
        {
            var simila = new Simila();

            Assert.IsTrue(simila.AreSimilar("AAAAA", "AABAA"));
            Assert.IsTrue(simila.AreSimilar("ABC DEFGH IJKLM", "ABD DFFGH LJKIM"));

            Assert.IsTrue(simila.AreSimilar("Cat", "Kat"));
            Assert.IsTrue(simila.AreSimilar("Afshin", "Afsoon"));
            Assert.IsTrue(simila.AreSimilar("Monitor", "Monitoring"));
            Assert.IsTrue(simila.AreSimilar("Monica", "Nonica"));
            Assert.IsTrue(simila.AreSimilar("Monica", "Noxica"));



            Assert.IsFalse(simila.AreSimilar("AAAAA", "AXYBAA"));
            Assert.IsFalse(simila.AreSimilar("ABC DEFGH IJKLM", "XTD DDDGF LAKIN"));
        }

        [TestMethod]
        public void Simila_ShouldWork_WithNoConfig_NotCaseSensitive()
        {
            //var simila = new Simila(stringComparisonOptions: StringComparisonOptions.None);

            var simila =
                new Simila(resolver:
                    new PhraseSimilarityResolver(wordSimilarityResolver:
                        new WordSimilarityResolver(
                            characterSimilarityResolver: new CharacterSimilarityResolver(isCaseSensitive: false)
                        ))
                );


            Assert.IsTrue(simila.AreSimilar("AAAAA", "AABAA"));
            Assert.IsTrue(simila.AreSimilar("AAAAA", "aabaa"));
            Assert.IsTrue(simila.AreSimilar("ABC DEFGH IJKLM", "ABD DFFGH LJKIM"));

            Assert.IsTrue(simila.AreSimilar("CAt", "Kat"));
            Assert.IsTrue(simila.AreSimilar("AfsHIN", "Afsoon"));
            Assert.IsTrue(simila.AreSimilar("Monitor", "Monitoring"));
            Assert.IsTrue(simila.AreSimilar("MonICa", "Nonica"));
            Assert.IsTrue(simila.AreSimilar("Monica", "NOXiCa"));



            Assert.IsFalse(simila.AreSimilar("AAAAA", "AXYBAA"));
            Assert.IsFalse(simila.AreSimilar("ABC DEFGH IJKLM", "XTD DDDGF LAKIN"));
        }

        [TestMethod]
        public void Simila_ShouldWork_WithNoConfig_CaseSensitive()
        {
            //var simila = new Simila(stringComparisonOptions: StringComparisonOptions.CaseSensitive);

            var simila =
                new Simila(resolver:
                    new PhraseSimilarityResolver(wordSimilarityResolver:
                        new WordSimilarityResolver(
                            characterSimilarityResolver: new CharacterSimilarityResolver(isCaseSensitive: true)
                        ))
                );


            Assert.IsTrue(simila.AreSimilar("AAAAA", "AABAA"));
            Assert.IsFalse(simila.AreSimilar("AAAAA", "aabaa"));
            Assert.IsTrue(simila.AreSimilar("ABC DEFGH IJKLM", "ABD DFFGH LJKIM"));

            Assert.IsFalse(simila.AreSimilar("CAt", "Kat"));
            Assert.IsFalse(simila.AreSimilar("AfsHIN", "Afsoon"));
            Assert.IsTrue(simila.AreSimilar("Monitor", "Monitoring"));
            Assert.IsFalse(simila.AreSimilar("MonICa", "Nonica"));
            Assert.IsFalse(simila.AreSimilar("Monica", "NOXiCa"));



            Assert.IsFalse(simila.AreSimilar("AAAAA", "AXYBAA"));
            Assert.IsFalse(simila.AreSimilar("ABC DEFGH IJKLM", "XTD DDDGF LAKIN"));
        }
    }
}
