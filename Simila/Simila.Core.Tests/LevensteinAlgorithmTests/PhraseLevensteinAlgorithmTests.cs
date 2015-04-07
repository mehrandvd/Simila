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
    class PhraseLevensteinAlgorithmTests
    {
        readonly PhraseLevensteinAlgorithm _leven = new PhraseLevensteinAlgorithm();

        [Test]
        public void SimpleSimilarityMustWork()
        {
            AreSimilar("Mehran Davoudi", "Nehran Dawoody");
            AreSimilar("Afshin Alizadeh", "Aphshin Alizade");

            NotSimilar("Lilian Alpha", "Lamborghini Beta");
            NotSimilar("Crash the world", "Clash of clawns");
        }


        private void AreSimilar(string left, string right)
        {
            Assert.IsTrue(_leven.GetSimilarity(left, right) > 0.7, string.Format("{0}-{1} should be similar,", left, right));
        }

        private void NotSimilar(string left, string right)
        {
            Assert.IsTrue(_leven.GetSimilarity(left, right) < 0.3, string.Format("{0}-{1} should NOT be similar,", left, right));
        }
    }
}
