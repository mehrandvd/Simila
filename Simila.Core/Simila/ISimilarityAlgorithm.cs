namespace Simila.Core
{
    public interface ISimilarityAlgorithm
    {
        float GetSimilarity(string left, string right);
    }
}