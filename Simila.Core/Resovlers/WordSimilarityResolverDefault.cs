using Simila.Core.Levenstein;

namespace Simila.Core
{
    public class WordSimilarityResolverDefault : MultiSimilarityResolver
    {
        public WordSimilarityResolverDefault(StringComparisonOptions stringComparisonOptions = StringComparisonOptions.None)
            : this(new CharacterSimilarityResolver(),
            new MistakeBasedSimilarityResolver<Word>(new BuiltInWordMistakeRepository()))
        {

        }

        public WordSimilarityResolverDefault(
            ISimilarityResolver<char> characterSimilarityResolverForLevenstein,
            IMistakeBasedSimilarityResolver<Word> mistakeBasedResolver)
            : base(mistakeBasedResolver,
                new WordSimilarityResolverLevenstein(characterSimilarityResolverForLevenstein))
        {

        }

    }
}