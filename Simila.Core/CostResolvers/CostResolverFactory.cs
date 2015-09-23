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
    public class CostResolverFactory
    {
        public static CharacterCostResolverFactory CreateForCharacter()
        {
            return new CharacterCostResolverFactory(new CharacterCostResolver());
        }

        public static WordCostResolverFactory CreateForWord()
        {
            return new WordCostResolverFactory(new WordCostResolver());
        }
    }
}
