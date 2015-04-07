using System.Collections.Generic;
using System.Globalization;
using LevenshtienAlgorithm;

namespace Simila.Core.Levenstein.CostResolvers
{

    public class CharacterCostResolver : CostResolverMistakyBase<char>
    {
        public CharacterCostResolver(double numericInsertionCost=0.5, bool isCaseSensitive = false, Dictionary<char, Dictionary<char, double>> costGroups = null)
        {
            MistakeCosts = costGroups ?? new Dictionary<char, Dictionary<char, double>>();
            NumericInsertionCost = numericInsertionCost;
            IsCaseSensitive = isCaseSensitive;
        }

        private double NumericInsertionCost { get; set; }

        public override double GetUpdateCost(char left, char right)
        {
            if (!IsCaseSensitive)
            {
                left = left.ToString(CultureInfo.InvariantCulture).ToUpper()[0];
                right = right.ToString(CultureInfo.InvariantCulture).ToUpper()[0];
            }

            if (left == right)
                return 0;

            var mistakeCost = GetMistakeCost(left, right);

            return mistakeCost ?? 1;
        }

        public override double GetInsertOrDeleteCost(char character)
        {
            double num;
            if(double.TryParse(character.ToString(CultureInfo.InvariantCulture),out num))
                return NumericInsertionCost;
            else
            {
                return 1;
            }
        }
    }
}
