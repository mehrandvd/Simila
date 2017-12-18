using Microsoft.Practices.Unity;
using Simila.Core.Levenstein;
using Unity.Attributes;

namespace Simila.Core
{
    public class WordSimilarityResolverDefault : MultiSimilarityResolver
    {
        public WordSimilarityResolverDefault()
            : this(new CharacterSimilarityResolverDefault(),
            new MistakeBasedSimilarityResolver<Word>(new BuiltInWordMistakeRepository()))
        {

        }

        [InjectionConstructor]
        public WordSimilarityResolverDefault(
            ISimilarityResolver<char> characterSimilarityResolverForLevenstein,
            IMistakeBasedSimilarityResolver<Word> mistakeBasedResolver)
            : base(mistakeBasedResolver,
                new WordSimilarityResolverLevenstein(characterSimilarityResolverForLevenstein))
        {

        }

    }
}