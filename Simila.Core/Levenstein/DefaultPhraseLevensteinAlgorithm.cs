using Simila.Core.CostResolvers;

namespace Simila.Core.Levenstein
{
    public class DefaultPhraseLevensteinAlgorithm : LevensteinAlgorithm<Phrase, Word>,  ISimilarityAlgorithm
    {
        public DefaultPhraseLevensteinAlgorithm(): base(new LevensteinWordSimilarityResolver())
        {
        }

        public float GetSimilarity(string left, string right)
        {
            return GetSimilarity((Phrase) left, right);
        }
    }
}
