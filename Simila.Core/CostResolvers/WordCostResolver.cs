using System.Collections.Generic;
using LevenshtienAlgorithm;
using Simila.Core.Levenstein;

namespace Simila.Core.CostResolvers
{
    public class WordCostResolver  : MistakeBasedCostResolver<Word>
    {
        public WordCostResolver()
        {
            MistakeCosts = new Dictionary<Word, Dictionary<Word, double>>();
        }
        public override double GetInsertOrDeleteCost(Word character)
        {
            return 1;
        }

        public override double GetUpdateCost(Word left, Word right)
        {
            var mistakeBasedCost = base.GetUpdateCost(left, right);

            if (mistakeBasedCost < 1)
            {
                return mistakeBasedCost;
            }
            else
            {
                var algorithm = new WordLevensteinAlgorithm();
                return 1 - algorithm.GetSimilarity(left, right);
            }
        }
    }
}
