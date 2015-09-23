namespace Simila.Core.SimilarityResolvers
{
    public interface IMistakeBasedSimilarityResolver<T> : ISimilarityResolver<T>
    {
        void SetMistakeSimilarity(T left,T right, float similarity);
    }
}
