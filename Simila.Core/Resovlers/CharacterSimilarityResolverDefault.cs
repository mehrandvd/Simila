namespace Simila.Core
{
    public class CharacterSimilarityResolverDefault : MistakeBasedSimilarityResolver<char>
    {
        public CharacterSimilarityResolverDefault()
            : this(StringComparisonOptions.None, new BuiltInCharacterMistakeRepository())
        {

        }

        public CharacterSimilarityResolverDefault(StringComparisonOptions? stringComparisonOptions, IMistakeRepository<char> mistakesRepository = null)
            : base(mistakesRepository)
        {
            CostOfNumeric = 0.5f;
            StringComparisonOptions = stringComparisonOptions ?? StringComparisonOptions.None;
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
