using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LevenshtienAlgorithm;
using Simila.Core.Levenstein;

namespace LevenshtienAlgorithm
{
    public class PhraseCostResolver : IMistakeBasedSimilarityResolver<Phrase>
    {
        public Dictionary<Phrase, Dictionary<Phrase, double>> MistakeCosts { get; set; }

        public bool IsCaseSensitive { get; set; }
        public float GetSimilarityWithNull(Phrase character)
        {
            throw new NotImplementedException();
        }

        public float GetSimilarity(Phrase left, Phrase right)
        {
            throw new NotImplementedException();
        }

        public void SetMistakeSimilarity(Phrase left, Phrase right, float similarity)
        {
            throw new NotImplementedException();
        }
    }
}
