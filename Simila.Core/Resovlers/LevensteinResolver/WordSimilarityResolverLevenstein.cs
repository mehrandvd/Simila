using Simila.Core.SimilarityResolvers;

namespace Simila.Core.Levenstein
{
    public class WordSimilarityResolverLevenstein : LevensteinAlgorithm<Word, char>
    {
        public WordSimilarityResolverLevenstein()
            : base(new CharacterSimilarityResolverDefault())
        {
        }

        public WordSimilarityResolverLevenstein(ISimilarityResolver<char> elementSimilarityResolver)
            : base(elementSimilarityResolver)
        {
        }


        
    }
}
