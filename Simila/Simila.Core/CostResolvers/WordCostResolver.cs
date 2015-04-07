using System.Collections.Generic;
using LevenshtienAlgorithm;

namespace Simila.Core.Levenstein.CostResolvers
{
    public class WordCostResolver  : CostResolverMistakyBase<Word>
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
            var mistakeCost = GetMistakeCost(left, right);

            if (mistakeCost.HasValue)
            {
                return mistakeCost.Value;
            }
            
            var algorithm = new WordLevensteinAlgorithm();
            return 1 - algorithm.GetSimilarity(left, right);
        }
    }
}
