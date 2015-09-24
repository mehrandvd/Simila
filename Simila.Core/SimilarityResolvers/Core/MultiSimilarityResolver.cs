using System.Collections.Generic;
using System.Linq;
using Simila.Core.Levenstein;

namespace Simila.Core.SimilarityResolvers
{
    public class MultiSimilarityResolver : ISimilarityResolver<Word>
    {
        private readonly List<ISimilarityResolver<Word>> _resolvers;

        public MultiSimilarityResolver(params ISimilarityResolver<Word>[] resolvers)
        {
            _resolvers = resolvers.ToList();
        }

        public float GetSimilarity(Word left, Word right)
        {
            foreach (var similarityResolver in _resolvers)
            {
                var similarity = similarityResolver.GetSimilarity(left, right);
                if (similarity > 0f)
                    return similarity;
            }
            return 0f;
        }
    }
}