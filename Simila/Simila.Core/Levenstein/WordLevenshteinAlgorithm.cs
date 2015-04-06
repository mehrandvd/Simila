using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simila.Core.Levenstein;
using Simila.Core.Levenstein.CostResolvers;

namespace LevenshtienAlgorithm
{
    public class WordLevenshteinAlgorithm : LevenshteinAlgorithm<Word, char>
    {
        public WordLevenshteinAlgorithm()
            : base(new CharacterCostResolver())
        {
        }

        public WordLevenshteinAlgorithm(CharacterCostResolver costResolver)
            : base(costResolver)
        {
        }


        
    }
}
