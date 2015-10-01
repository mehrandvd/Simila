namespace Simila.Core
{
    public abstract class SimilaBase<T> : ISimila<T>
    {
        public abstract ISimilarityResolver<T> Algorithm { get; }

        protected SimilaBase()
        {
            Treshold = (int)SimilarityRate.Similar * .1f;
        }

        public float Treshold { get; set; }

        public virtual bool AreSimilar(T left, T right)
        {
            return GetSimilarityPercent(left, right) >= Treshold;
        }

        public virtual float GetSimilarityPercent(T left, T right)
        {
            return Algorithm.GetSimilarity(left, right);
        }
    }
}