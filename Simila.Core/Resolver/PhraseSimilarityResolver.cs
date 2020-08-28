using System;
using Simila.Core.Resolver.GeneralResolver;
using Simila.Core.Resolver.LevenshteinResolver;

namespace Simila.Core.Resolver
{
    public class PhraseSimilarityResolver : GeneralSimilarityResolver<Phrase>, ISimilarityResolver<string>
    {
        private LevenshteinAlgorithm<Phrase, Word> Algorithm { get; }

        public PhraseSimilarityResolver(
            IMistakeRepository<Phrase>? mistakesRepository = null,
            Func<Phrase, Phrase, float?>? mistakeAlgorithm = null,
            ISimilarityResolver<Word>? wordSimilarityResolver = null
        )
            : base(mistakesRepository, mistakeAlgorithm)
        {
            Algorithm = new LevenshteinAlgorithm<Phrase, Word>(wordSimilarityResolver ?? new WordSimilarityResolver());
        }

        protected  override float? GetSimilarityImpl(Phrase left, Phrase right)
        {
            return base.GetSimilarityImpl(left, right)
                   ?? Algorithm.GetSimilarity(left, right);
        }

        public float GetSimilarity(string left, string right)
        {
            return GetSimilarity((Phrase) left, right);
        }
    }
}
