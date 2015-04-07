using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simila.Core.Levenstein;
using Simila.Core.Levenstein.CostResolvers;

namespace LevenshtienAlgorithm
{
    public class WordLevensteinAlgorithm : LevenshteinAlgorithm<Word, char>
    {
        public WordLevensteinAlgorithm()
            : base(new CharacterCostResolver())
        {
        }

        public WordLevensteinAlgorithm(CharacterCostResolver costResolver)
            : base(costResolver)
        {
        }


        
    }
}
