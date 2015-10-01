namespace Simila.Core.Levenstein
{
    public class WordSimilarityResolverLevenstein : LevensteinAlgorithm<Word, char>
    {
        public WordSimilarityResolverLevenstein(ISimilarityResolver<char> elementSimilarityResolver)
            : base(elementSimilarityResolver)
        {
        }


        
    }
}
