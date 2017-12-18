using Microsoft.Practices.Unity;
using Unity.Attributes;

namespace Simila.Core.Levenstein
{
    public class PhraseSimilarityResolverLevenstein : LevensteinAlgorithm<Phrase, Word>,  IStringSimilarityAlgorithm
    {
        public PhraseSimilarityResolverLevenstein()
            : this(new WordSimilarityResolverDefault())
        {
            
        }

        [InjectionConstructor]
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
