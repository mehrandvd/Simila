using Simila.Core.Levenstein;

namespace Simila.Core
{
    public class WordSimilarityResolverDefault : MultiSimilarityResolver
    {
        public WordSimilarityResolverDefault(
            ISimilarityResolver<char> characterSimilarityResolverForLevenstein,
            IMistakeBasedSimilarityResolver<Word> mistakeBasedResolver)
            : base(mistakeBasedResolver,
                new WordSimilarityResolverLevenstein(characterSimilarityResolverForLevenstein))
        {

        }

    }
}