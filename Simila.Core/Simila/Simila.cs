using System;
using Simila.Core.Levenstein;

namespace Simila.Core
{
    public class Simila //: SimilaBase<string>
    {
        public float Threshold { get; set; }
        public ISimilarityResolver<string> Algorithm { get; }

        public Simila(float threshold = .6f, ISimilarityResolver<string> resolver = null)
        {
            if (resolver == null)
            {
                var wordSimilarityResolver = new WordSimilarityResolver(
                    characterSimilarityResolver: new CharacterSimilarityResolver(
                        mistakesRepository: new BuiltInCharacterMistakeRepository()
                    )
                );

                Algorithm = new PhraseSimilarityResolver(wordSimilarityResolver: wordSimilarityResolver);
            }
            else
            {
                Algorithm = resolver;
            }
           
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

    }
}
