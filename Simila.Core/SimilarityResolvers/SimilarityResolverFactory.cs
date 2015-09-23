using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevenshtienAlgorithm;
using Simila.Core.CostResolvers;

namespace Simila.Core.Levenstein.CostResolvers
{
    public class SimilarityResolverFactory
    {
        public static CharacterSimilarityResolverFactory CreateForCharacter()
        {
            return new CharacterSimilarityResolverFactory(new CharacterMistakeBasedSimilarityResolver());
        }

        public static WordSimilaritytResolverFactory CreateForWord()
        {
            return new WordSimilaritytResolverFactory(new LevensteinWordSimilarityResolver());
        }
    }
}
