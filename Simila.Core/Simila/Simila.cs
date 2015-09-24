using Simila.Core.Levenstein;
using Simila.Core.SimilarityResolvers;

namespace Simila.Core
{
    public class Simila : SimilaBase<string>
    {
        public Simila() : this(new PhraseSimilarityResolverLevenstein())
        {

        }

        public Simila(ISimilarityResolver<string> algorithm)
            : base(algorithm)
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
