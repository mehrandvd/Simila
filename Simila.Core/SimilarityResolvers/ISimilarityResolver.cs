namespace LevenshtienAlgorithm
{
    public interface ISimilarityResolver<T>
    {
        float GetSimilarityWithNull(T character);
        float GetSimilarity(T left, T right);
    }
}