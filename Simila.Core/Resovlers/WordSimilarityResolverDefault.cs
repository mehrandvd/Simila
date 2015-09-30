using Simila.Core.Levenstein;
using Simila.Core.SimilarityResolvers;

namespace Simila.Core
{
    public class WordSimilarityResolverDefault : MultiSimilarityResolver
    {
        public WordSimilarityResolverDefault(ISimilarityResolver<char> charSimilarityResolver)
            : base(new MistakeBasedSimilarityResolver<Word>(),
                new WordSimilarityResolverLevenstein(charSimilarityResolver))
        {

        }

    }
}