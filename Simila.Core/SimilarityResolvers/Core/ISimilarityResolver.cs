namespace Simila.Core.SimilarityResolvers
{
    public interface ISimilarityResolver<T>
    {
        float GetSimilarityWithNull(T character);
        float GetSimilarity(T left, T right);
    }
}