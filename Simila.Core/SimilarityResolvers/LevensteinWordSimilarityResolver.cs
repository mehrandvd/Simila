using System.Collections.Generic;
using Simila.Core.Levenstein;

namespace Simila.Core.SimilarityResolvers
{
    public class LevensteinWordSimilarityResolver  : MistakeBasedSimilarityResolver<Word>
    {
        public ILevensteinAlgorithm<Word, char> LevensteinAlgorithm { get; set; }

        public LevensteinWordSimilarityResolver() : this(new DefaultWordLevensteinAlgorithm())
        {
            
        }

        public LevensteinWordSimilarityResolver(ILevensteinAlgorithm<Word, char> levensteinAlgorithm)
        {
            LevensteinAlgorithm = levensteinAlgorithm;
            MistakesRepository = new Dictionary<Word, Dictionary<Word, float>>();
        }

        public override float GetSimilarityWithNull(Word character)
        {
            return 0;
        }

        public override float GetSimilarity(Word left, Word right)
        {
            var similarityByReposiroty = base.GetSimilarity(left, right);

            if (similarityByReposiroty > 0)
            {
                return similarityByReposiroty;
            }
            else
            {
                return LevensteinAlgorithm.GetSimilarity(left, right);
            }
        }
    }
}
