using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevenshtienAlgorithm
{
    class WordCostResolver  : ICostResolver<Word>
    {
        public Dictionary<Word, Dictionary<Word, double>> CostGroups { get; set; }

        public WordCostResolver()
        {
            CostGroups = new Dictionary<Word, Dictionary<Word, double>>();
        }
        public double GetInsertOrDeleteCost(Word character)
        {

            return 1;

        }

        public double GetUpdateCost(Word left, Word right)
        {
            var algorithm = new WordLevenshteinAlgorithm();
            double? costValue = algorithm.GetDistance(left, right);
            if (costValue == 0.0)
                return 0;
            if (CostGroups.ContainsKey(left))
            {
                var internaldict = CostGroups[left];
                if (internaldict.ContainsKey(right))
                {
                    costValue = internaldict[right];
                }
            }

            else if (CostGroups.ContainsKey(right))
            {
                var internaldict = CostGroups[right];
                if (internaldict.ContainsKey(left))
                {

                    costValue = internaldict[left];
                }
            }
            else
            {
                costValue = 1 - algorithm.GetSimilarity(left, right);
            }

            return costValue.Value;
        }

        public void SetCost(Word inputT, Word replacementT, double cost)
        {
            var internaldict = new Dictionary<Word, double>();

            internaldict.Add(replacementT, cost);


            CostGroups.Add(inputT, internaldict);
        }

        public bool IsCaseSensitive { get; set; }
    }
}
