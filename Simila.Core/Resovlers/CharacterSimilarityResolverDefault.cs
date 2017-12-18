using Microsoft.Practices.Unity;
using Unity.Attributes;

namespace Simila.Core
{
    public class CharacterSimilarityResolverDefault : MistakeBasedSimilarityResolver<char>
    {
        public CharacterSimilarityResolverDefault()
            : this(new BuiltInCharacterMistakeRepository(), StringComparisonOptions.None)
        {

        }

        [InjectionConstructor]
        public CharacterSimilarityResolverDefault(IMistakeRepository<char> mistakesRepository, StringComparisonOptions stringComparisonOptions)
            : base(mistakesRepository)
        {
            CostOfNumeric = 0.5f;
            StringComparisonOptions = stringComparisonOptions;
        }

        public float CostOfNumeric { get; set; }

        public StringComparisonOptions StringComparisonOptions { get; set; }

        public bool IsCaseSensitive
        {
            get { return StringComparisonOptions.HasFlag(StringComparisonOptions.CaseSensitive); }
        }

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
