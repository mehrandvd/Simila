using System.Collections.Generic;
using LevenshtienAlgorithm;

namespace Simila.Core.Levenstein.CostResolvers
{
    public abstract class CostResolverMistakyBase<T> : ICostResolver<T>
    {
        public Dictionary<T, Dictionary<T, double>> MistakeCosts { get; set; }
        public abstract double GetInsertOrDeleteCost(T character);
        public abstract double GetUpdateCost(T left, T right);
        public bool IsCaseSensitive { get; set; }

        public double? GetMistakeCost(T left, T right)
        {
            if (MistakeCosts.ContainsKey(left))
            {
                var internaldict = MistakeCosts[left];
                if (internaldict.ContainsKey(right))
                {
                    return internaldict[right];
                }
            }

            else if (MistakeCosts.ContainsKey(right))
            {
                var internaldict = MistakeCosts[right];
                if (internaldict.ContainsKey(left))
                {

                    return internaldict[left];
                }
            }

            return null;
        }

        public void SetCost(T inputT, T replacementT, double cost)
        {
            var internaldict = new Dictionary<T, double> {{replacementT, cost}};
            MistakeCosts.Add(inputT, internaldict);
        }
    }
}