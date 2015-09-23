using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simila.Core.CostResolvers;
using Simila.Core.Levenstein;
using Simila.Core.Levenstein.CostResolvers;

namespace LevenshtienAlgorithm
{
    public class DefaultWordLevensteinAlgorithm : LevensteinAlgorithm<Word, char>
    {
        public DefaultWordLevensteinAlgorithm()
            : base(new CharacterMistakeBasedSimilarityResolver())
        {
        }

        public DefaultWordLevensteinAlgorithm(ISimilarityResolver<char> similarityResolver)
            : base(similarityResolver)
        {
        }


        
    }
}
