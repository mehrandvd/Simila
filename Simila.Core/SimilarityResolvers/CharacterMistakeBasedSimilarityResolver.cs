using System.Collections.Generic;

namespace Simila.Core.CostResolvers
{

    public class CharacterMistakeBasedSimilarityResolver : MistakeBasedSimilarityResolver<char>
    {
        public CharacterMistakeBasedSimilarityResolver()
        {
            CostOfNumeric = 0.5f;
            IsCaseSensitive = true;
        }

        public float CostOfNumeric { get; set; }
        public bool IsCaseSensitive { get; set; }

        public override float GetSimilarityWithNull(char character)
        {
            if(char.IsNumber(character))
                return CostOfNumeric;
            
            return 1;
        }

        public override float GetSimilarity(char left, char right)
        {
            if (!IsCaseSensitive)
            {
                left = char.ToUpper(left);
                right = char.ToUpper(right);
            }

            return base.GetSimilarity(left, right);
        }

        public override void SetMistakeSimilarity(char left, char right, float similarity)
        {
            if (!IsCaseSensitive)
            {
                left = char.ToUpper(left);
                right = char.ToUpper(right);
            }

            base.SetMistakeSimilarity(left, right, similarity);
        }
    }
}
