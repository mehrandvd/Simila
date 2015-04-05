using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simila.Core.Levenstein;

namespace LevenshtienAlgorithm
{
    public class PhraseLevenshteinAlgorithm : LevenshteinAlgorithm<Phrase, Word>
    {
        public PhraseLevenshteinAlgorithm(): base(new WordCostResolver())
        {
        }
    }
}
