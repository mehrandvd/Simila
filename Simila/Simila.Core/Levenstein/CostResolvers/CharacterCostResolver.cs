using System.Collections.Generic;
using System.Globalization;
using LevenshtienAlgorithm;

namespace Simila.Core.Levenstein
{

    public class CharacterCostResolver : ICostResolver<char>
    {
        public CharacterCostResolver(double numericInsertionCost=0.5, bool isCaseSensitive = false, Dictionary<char, Dictionary<char, double>> costGroups = null)
        {
            CostGroups = costGroups ?? new Dictionary<char, Dictionary<char, double>>();
            NumericInsertionCost = numericInsertionCost;
            IsCaseSensitive = isCaseSensitive;
        }

        public Dictionary<char, Dictionary<char, double>> CostGroups { get; private set; }
        private double NumericInsertionCost { get; set; }

        public double GetUpdateCost(char char1, char char2)
        {
            if (!IsCaseSensitive)
            {
                char1 = char1.ToString(CultureInfo.InvariantCulture).ToUpper()[0];
                char2 = char2.ToString(CultureInfo.InvariantCulture).ToUpper()[0];
            }

            if (char1 == char2)
                return 0;

            if (CostGroups.ContainsKey(char1))
            {
                var internaldict = CostGroups[char1];
                if (internaldict.ContainsKey(char2))
                {

                    return internaldict[char2];
                }
            }

            if (CostGroups.ContainsKey(char2))
            {
                var internaldict = CostGroups[char2];
                if (internaldict.ContainsKey(char1))
                {
                    return internaldict[char1];
                }
            }

            return 1;
        }

        public double GetInsertOrDeleteCost(char character)
        {
            double num;
            if(double.TryParse(character.ToString(CultureInfo.InvariantCulture),out num))
                return NumericInsertionCost;
            else
            {
                return 1;
            }
        }

        public void SetCost(char inputT, char replacementT, double cost)
        {
            var internaldict = new Dictionary<char, double>();
            if (CostGroups.ContainsKey(inputT))
                internaldict = CostGroups[inputT];
            else
                CostGroups.Add(inputT, internaldict);
            var replacementChar = replacementT;

            if (!internaldict.ContainsKey(replacementChar))
                internaldict.Add(replacementChar, cost);
            else
                internaldict[replacementChar] = cost;
        }

        public bool IsCaseSensitive { get; set; }

        
    }
   
}
