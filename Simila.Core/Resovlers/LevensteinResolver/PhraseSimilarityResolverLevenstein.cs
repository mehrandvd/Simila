using Simila.Core.SimilarityResolvers;

namespace Simila.Core.Levenstein
{
    public class PhraseSimilarityResolverLevenstein : LevensteinAlgorithm<Phrase, Word>,  IStringSimilarityAlgorithm
    {
        public PhraseSimilarityResolverLevenstein(ISimilarityResolver<Word> wordSimilarityResolver)
            : base(wordSimilarityResolver)
        {
        }

        public float GetSimilarity(string left, string right)
        {
            return GetSimilarity((Phrase) left, right);
        }

        
    }
}
