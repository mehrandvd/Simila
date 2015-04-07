namespace Simila.Core
{
    public interface ISimilarityAlgorithm
    {
        double GetSimilarity(string left, string right);
    }
}