using System.Collections.Generic;
using LevenshtienAlgorithm;

namespace Simila.Core.CostResolvers
{
    public abstract class MistakeBasedCostResolver<T> : ICostResolver<T>
    {
        protected MistakeBasedCostResolver()
        {
            MistakeCosts = new Dictionary<T, Dictionary<T, double>>();
        }
        protected Dictionary<T, Dictionary<T, double>> MistakeCosts { get; set; }
        public abstract double GetInsertOrDeleteCost(T character);

        public virtual double GetUpdateCost(T left, T right)
        {
            if (left.Equals(right))
                return 0;

            var mistakeCost = GetMistakeCost(left, right);

            return mistakeCost ?? 1;
        }

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

        public void SetCost(T left, T right, double cost)
        {
            var mistakesForLeft = GetMistakesOf(left);
            var mistakesForRight = GetMistakesOf(right);

            mistakesForLeft[right] = cost;
            mistakesForRight[left] = cost;
        }

        private Dictionary<T, double> GetMistakesOf(T left)
        {
            Dictionary<T, double> dictionary = null;
            if (MistakeCosts.ContainsKey(left))
            {
                dictionary = MistakeCosts[left];
            }
            else
            {
                dictionary = new Dictionary<T, double>();
                MistakeCosts.Add(left, dictionary);
            }
            return dictionary;
        }
    }
}