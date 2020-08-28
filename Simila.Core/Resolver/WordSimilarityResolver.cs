using System;
using Simila.Core.Resolver.GeneralResolver;
using Simila.Core.Resolver.LevenshteinResolver;

namespace Simila.Core.Resolver
{
    public class WordSimilarityResolver : GeneralSimilarityResolver<Word>, ISimilarityResolver<string>
    {
        private LevenshteinAlgorithm<Word, char> Algorithm { get; }
        
        public WordSimilarityResolver(
            IMistakeRepository<Word>? mistakesRepository = null,
            Func<Word, Word, float?>? mistakeAlgorithm = null,
            ISimilarityResolver<char>? characterSimilarityResolver = null
            )
            : base(mistakesRepository, mistakeAlgorithm)
        {
            Algorithm = new LevenshteinAlgorithm<Word, char>(characterSimilarityResolver?? new CharacterSimilarityResolver());
        }

        protected override float? GetSimilarityImpl(Word left, Word right)
        {
            return base.GetSimilarityImpl(left, right)
                   ?? Algorithm.GetSimilarity(left, right);
        }

        float ISimilarityResolver<string>.GetSimilarity(string left, string right)
        {
            return GetSimilarity((Word) left, (Word) right);
        }
    }
}