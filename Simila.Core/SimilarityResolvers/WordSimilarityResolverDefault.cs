using System.Collections.Generic;
using Simila.Core.Levenstein;

namespace Simila.Core.SimilarityResolvers
{
    public class WordSimilarityResolverDefault : MultiSimilarityResolver
    {
        public WordSimilarityResolverDefault()
            : this(new WordSimilarityResolverMistake(), new WordSimilarityResolverLevenstein())
        {
            
        }

        public WordSimilarityResolverDefault(params ISimilarityResolver<Word>[] resolvers) 
            : base(resolvers)
        {
        }
    }
}