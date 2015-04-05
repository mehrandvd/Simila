using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LevenshtienAlgorithm;

namespace LevenshtienAlgorithm
{
    public class PhraseCostResolver : ICostResolver<Phrase>
    {
        public Dictionary<Phrase, Dictionary<Phrase, double>> CostGroups { get; set; }

        public double GetInsertOrDeleteCost(Phrase character)
        {
            throw new NotImplementedException();
        }

        public double GetUpdateCost(Phrase left, Phrase right)
        {
            throw new NotImplementedException();
        }

        public void SetCost(Phrase inputT, Phrase replacementT, double cost)
        {
            throw new NotImplementedException();
        }

        public bool IsCaseSensitive { get; set; }
    }
}
