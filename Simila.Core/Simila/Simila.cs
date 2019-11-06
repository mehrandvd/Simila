using System;
using Simila.Core.Levenstein;

namespace Simila.Core
{
    public class Simila //: SimilaBase<string>
    {
        public float Treshold { get; set; };

        public Simila(float treshold = .6f, StringComparisonOptions stringComparisonOptions = StringComparisonOptions.None)
        {
            var wordSimilarityResolver = new WordSimilarityResolver(
                characterSimilarityResolver: new CharacterSimilarityResolver(
                    isCaseSensitive: stringComparisonOptions == StringComparisonOptions.CaseSensitive,
                    mistakesRepository: new BuiltInCharacterMistakeRepository()
                )
            );

            Algorithm = new PhraseSimilarityResolver(wordSimilarityResolver: wordSimilarityResolver);

            Treshold = treshold;
        }

        public virtual bool AreSimilar(string left, string right)
        {
            return GetSimilarityPercent(left, right) >= Treshold;
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
