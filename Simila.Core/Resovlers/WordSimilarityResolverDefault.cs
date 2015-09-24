using Simila.Core.Levenstein;
using Simila.Core.SimilarityResolvers;

namespace Simila.Core
{
    public class WordSimilarityResolverDefault : MultiSimilarityResolver
    {
        public WordSimilarityResolverDefault()
            : this(new MistakeBasedSimilarityResolver<Word>(), new WordSimilarityResolverLevenstein())
        {
            
        }

        public WordSimilarityResolverDefault(params ISimilarityResolver<Word>[] resolvers) 
            : base(resolvers)
        {
        }
    }
}