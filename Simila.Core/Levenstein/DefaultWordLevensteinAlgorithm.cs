using LevenshtienAlgorithm;
using Simila.Core.CostResolvers;
using Simila.Core.SimilarityResolvers;

namespace Simila.Core.Levenstein
{
    public class DefaultWordLevensteinAlgorithm : LevensteinAlgorithm<Word, char>
    {
        public DefaultWordLevensteinAlgorithm()
            : base(new DefaultCharacterSimilarityResolver())
        {
        }

        public DefaultWordLevensteinAlgorithm(ISimilarityResolver<char> similarityResolver)
            : base(similarityResolver)
        {
        }


        
    }
}
