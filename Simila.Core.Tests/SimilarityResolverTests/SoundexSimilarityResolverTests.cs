using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simila.Core.Resolver;

namespace Simila.Core.Test.SimilarityResolverTests
{
    [TestClass]
    public class SoundexSimilarityResolverTests
    {
        [TestMethod]
        public void Soundex_Calculation_MustWork()
        {
            var soundex = new SoundexSimilarityResolver();

            Assert.AreEqual("M650", soundex.ToSoundexString("Mehran"));
            Assert.AreEqual("M650", soundex.ToSoundexString("Maryam"));
            Assert.AreEqual("M500", soundex.ToSoundexString("Mina"));
            Assert.AreEqual("S150", soundex.ToSoundexString("Sobhan"));
            Assert.AreEqual("A125", soundex.ToSoundexString("Afshin"));
        }

        [TestMethod]
        public void Soundex_Difference_MustWork()
        {
            var soundex = new SoundexSimilarityResolver();

            Assert.AreEqual(4, soundex.CalculateSoundexDifference("Mehran", "Maryam"));
            Assert.AreEqual(3, soundex.CalculateSoundexDifference("Mehran", "Mina"));
            Assert.AreEqual(2, soundex.CalculateSoundexDifference("Mehran", "Sobhan"));
            Assert.AreEqual(1, soundex.CalculateSoundexDifference("Mehran", "Afshin"));
            Assert.AreEqual(2, soundex.CalculateSoundexDifference("Sobhan", "Afshin"));

        }

        [TestMethod]
        public void Soundex_GetSimilarity_MustWork()
        {
            var soundex = new SoundexSimilarityResolver();

            Assert.AreEqual(1, soundex.GetSimilarity("Mehran", "Maryam"));
            Assert.AreEqual(.75, soundex.GetSimilarity("Mehran", "Mina"));
            Assert.AreEqual(.5, soundex.GetSimilarity("Mehran", "Sobhan"));
            Assert.AreEqual(.25, soundex.GetSimilarity("Mehran", "Afshin"));
            Assert.AreEqual(.5, soundex.GetSimilarity("Sobhan", "Afshin"));

        }
    }
}
