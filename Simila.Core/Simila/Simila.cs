using Simila.Core.Levenstein;

namespace Simila.Core
{
    public class Simila : SimilaBase<string>
    {
        public Simila() : this(new DefaultPhraseLevensteinAlgorithm())
        {

        }

        public Simila(ISimilarityAlgorithm<string> algorithm) : base(algorithm)
        {
           
        }

        public float GetSimilarityPercent(object left, object right)
        {
            return base.GetSimilarityPercent(left.ToString(), right.ToString());
        }

        public bool IsSimilar(object left, object right)
        {
            return base.IsSimilar(left.ToString(), right.ToString());
        }
    }
}
