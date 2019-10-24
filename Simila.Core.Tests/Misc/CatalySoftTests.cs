using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simila.Core.Tests
{
    [TestClass]
    public class CatalySoftTests
    {
        readonly CatalySoftAlgorithm _catal = new CatalySoftAlgorithm();

        [TestMethod]
        public void SimpleSimilarityMustWork()
        {
            //AreSimilar("Mehran Davoudi", "Nehran Dawoody");
            AreSimilar("Afshin Alizadeh", "Aphshin Alizade");

            NotSimilar("Lilian Alpha", "Lamborghini Beta");
            NotSimilar("Crash the world", "Clash of clawns");



            AreSimilar("Mehran", "Nehran");
            AreSimilar("MEHRAN", "mehran");
            //AreSimilar("Afshin", "Aphshin");

            AreSimilar("Mehran", "Nahran");
            AreSimilar("Monica", "Monika");
            //AreSimilar("Nonica", "Nomika");
            AreSimilar("Crespo", "Krespo");

            //NotSimilar("Mehran", "RanMeh");
            NotSimilar("Penalty", "People");
        }


        private void AreSimilar(string left, string right)
        {
            var similarity = _catal.GetSimilarity(left, right);
            Assert.IsTrue(similarity > 0.6, string.Format("{0}-{1} should be similar (Similarity: {2})", left, right, similarity));
        }

        private void NotSimilar(string left, string right)
        {
            var similarity = _catal.GetSimilarity(left, right);
            Assert.IsTrue(similarity < 0.5, string.Format("{0}-{1} should NOT be similar (Similarity: {2})", left, right, similarity));
        }
    }
}
