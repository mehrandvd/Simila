using System.Collections.Generic;

namespace Simila.Core.CostResolvers
{

    public class CharacterCostResolver : MistakeBasedCostResolver<char>
    {
        public CharacterCostResolver()
        {
            CostOfInsertingNumbericCharacter = 0.5;
        }

        public double CostOfInsertingNumbericCharacter { get; set; }

        public override double GetInsertOrDeleteCost(char character)
        {
            if(char.IsNumber(character))
                return CostOfInsertingNumbericCharacter;
            
            return 1;
        }
    }
}
