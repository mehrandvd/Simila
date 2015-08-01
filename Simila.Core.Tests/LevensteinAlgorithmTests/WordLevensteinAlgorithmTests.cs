using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevenshtienAlgorithm;
using NUnit.Framework;

namespace Simila.Core.Tests
{
    [TestFixture]
    class WordLevensteinAlgorithmTests
    {
        readonly WordLevensteinAlgorithm _leven = new WordLevensteinAlgorithm();

        [Test]
        public void SimpleSimilarityMustWork()
        {
            AreSimilar("Mehran", "Nehran");
            AreSimilar("MEHRAN", "mehran");
            AreSimilar("Afshin", "Aphshin");

            AreSimilar("Mehran", "Nahran");
            AreSimilar("Monica", "Monika");
            AreSimilar("Nonica", "Nomika");
            AreSimilar("Crespo", "Krespo");
            
            NotSimilar("Mehran", "RanMeh");
            NotSimilar("Penalty", "People");
        }


        private void AreSimilar(string left, string right)
        {
            var similarity = _leven.GetSimilarity(left, right);
            Assert.IsTrue(similarity > 0.6, string.Format("{0}-{1} should be similar (Similarity: {2})", left, right, similarity));
        }

        private void NotSimilar(string left, string right)
        {
            var similarity = _leven.GetSimilarity(left, right);
            Assert.IsTrue(similarity < 0.5, string.Format("{0}-{1} should NOT be similar (Similarity: {2})", left, right, similarity));
        }
    }
}
