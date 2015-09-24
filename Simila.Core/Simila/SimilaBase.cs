using Simila.Core.SimilarityResolvers;

namespace Simila.Core
{
    public class SimilaBase<T> : ISimila<T>
    {
        public ISimilarityResolver<T> Algorithm { get; set; }

        public SimilaBase(ISimilarityResolver<T> algorithm)
        {
            Algorithm = algorithm;
            Treshold = 0.6f;
        }

        public double Treshold { get; set; }

        public virtual bool IsSimilar(T left, T right)
        {
            return GetSimilarityPercent(left, right) >= Treshold;
        }

        public virtual float GetSimilarityPercent(T left, T right)
        {
            return Algorithm.GetSimilarity(left, right);
        }
    }
}