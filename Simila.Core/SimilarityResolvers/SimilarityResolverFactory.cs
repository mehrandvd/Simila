namespace Simila.Core.SimilarityResolvers
{
    public class SimilarityResolverFactory
    {
        public static CharacterSimilarityResolverFactory CreateForCharacter()
        {
            return new CharacterSimilarityResolverFactory(new CharacterSimilarityResolverDefault());
        }

        public static WordSimilaritytResolverFactory CreateForWordMistakeBased()
        {
            return new WordSimilaritytResolverFactory(new WordSimilarityResolverMistake());
        }
    }
}
