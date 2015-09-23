using Simila.Core.Levenstein;

namespace Simila.Core
{
    public class Simila
    {
        public Simila()
            : this(SimilarityMethod.ExtendedLevenstein)
        {

        }

        public Simila(SimilarityMethod method)
        {
            switch (method)
            {
                case SimilarityMethod.CatalySoft:
                    _algorithm = new DefaultPhraseLevensteinAlgorithm();
                    break;

                case SimilarityMethod.ExtendedLevenstein:
                    _algorithm = new CatalySoftAlgorithm();
                    break;
            }
        }

        private readonly ISimilarityAlgorithm _algorithm;

        public double Treshold { get; set; }

        public bool IsSimilar(string left, string right)
        {
            return GetSimilarityPercent(left, right) >= Treshold;
        }

        public double GetSimilarityPercent(string left, string right)
        {
            return _algorithm.GetSimilarity(left, right);
        }
    }
}
