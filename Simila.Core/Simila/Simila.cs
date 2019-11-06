using System;
using Simila.Core.Levenstein;

namespace Simila.Core
{
    public class Simila //: SimilaBase<string>
    {
        public float Threshold { get; set; };

        public Simila(float threshold = .6f, StringComparisonOptions stringComparisonOptions = StringComparisonOptions.None)
        {
            var wordSimilarityResolver = new WordSimilarityResolver(
                characterSimilarityResolver: new CharacterSimilarityResolver(
                    isCaseSensitive: stringComparisonOptions == StringComparisonOptions.CaseSensitive,
                    mistakesRepository: new BuiltInCharacterMistakeRepository()
                )
            );

            Algorithm = new PhraseSimilarityResolver(wordSimilarityResolver: wordSimilarityResolver);

            Threshold = threshold;
        }

        public virtual bool AreSimilar(string left, string right)
        {
            return GetSimilarityPercent(left, right) >= Threshold;
        }

        public virtual float GetSimilarityPercent(string left, string right)
        {
            return Algorithm.GetSimilarity(left, right);
        }

        public ISimilarityResolver<Phrase> Algorithm { get; }
    }

    [Flags]
    public enum StringComparisonOptions
    {
        None = 0,
        CaseSensitive,    
    }
}
