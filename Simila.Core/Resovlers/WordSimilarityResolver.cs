using System;
using Simila.Core.Levenstein;

namespace Simila.Core
{
    public class WordSimilarityResolver : GeneralSimilarityResolver<Word>
    {
        private LevensteinAlgorithm<Word, char> Algorithm { get; }
        
        public WordSimilarityResolver(
            IMistakeRepository<Word> mistakesRepository = null,
            Func<Word, Word, float?> mistakeAlgorithm = null,
            ISimilarityResolver<char> characterSimilarityResolver = null
            )
            : base(mistakesRepository, mistakeAlgorithm)
        {
            Algorithm = new LevensteinAlgorithm<Word, char>(characterSimilarityResolver?? new CharacterSimilarityResolver());
        }

        protected override float? GetSimilarityImpl(Word left, Word right)
        {
            return base.GetSimilarityImpl(left, right)
                   ?? Algorithm.GetSimilarity(left, right);
        }
    }
}