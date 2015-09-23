namespace Simila.Core.SimilarityResolvers
{
    public class SimilarityResolverFactory
    {
        public static CharacterSimilarityResolverFactory CreateForCharacter()
        {
            return new CharacterSimilarityResolverFactory(new DefaultCharacterSimilarityResolver());
        }

        public static WordSimilaritytResolverFactory CreateForWord()
        {
            return new WordSimilaritytResolverFactory(new LevensteinWordSimilarityResolver());
        }
    }
}
