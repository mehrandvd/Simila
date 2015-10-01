using Microsoft.Practices.Unity;

namespace Simila.Core
{
    public class CharacterSimilarityResolverDefault : MistakeBasedSimilarityResolver<char>
    {
        public CharacterSimilarityResolverDefault()
            : this(new BuiltInCharacterMistakeRepository())
        {
            
        }

        [InjectionConstructor]
        public CharacterSimilarityResolverDefault(IMistakeRepository<char> mistakesRepository)
            : base(mistakesRepository)
        {
            CostOfNumeric = 0.5f;
            IsCaseSensitive = true;
        }

        public float CostOfNumeric { get; set; }
        public bool IsCaseSensitive { get; set; }

        public override float GetSimilarity(char left, char right)
        {
            if ((left == default(char)) ^ (right == default(char)))
                return char.IsNumber((char)(left + right)) ? CostOfNumeric : 0f;

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
