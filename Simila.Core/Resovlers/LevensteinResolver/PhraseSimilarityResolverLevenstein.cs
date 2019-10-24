
namespace Simila.Core.Levenstein
{
    public class PhraseSimilarityResolverLevenstein : LevensteinAlgorithm<Phrase, Word>,  IStringSimilarityAlgorithm
    {
        public PhraseSimilarityResolverLevenstein(StringComparisonOptions stringComparisonOptions)
            : this(new WordSimilarityResolverDefault(stringComparisonOptions))
        {
            
        }

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
