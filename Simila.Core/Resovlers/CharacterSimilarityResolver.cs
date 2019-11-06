using System;

namespace Simila.Core
{
    public class CharacterSimilarityResolver : GeneralSimilarityResolver<char>
    {
        public bool IsCaseSensitive { get; private set; }

        //public CharacterSimilarityResolver()
        //    : this(false, new BuiltInCharacterMistakeRepository())
        //{

        //}

        public CharacterSimilarityResolver(
            bool isCaseSensitive = false,
            IMistakeRepository<char> mistakesRepository = null,
            float numericSimilarityRate = .5f,
            Func<char, char, float?> mistakeAlgorithm = null
        )
            : base(mistakesRepository, mistakeAlgorithm)
        {
            IsCaseSensitive = isCaseSensitive;
            NumericSimilarityRate = numericSimilarityRate;
        }

        public float NumericSimilarityRate { get; set; }

        protected override float? GetSimilarityImpl(char left, char right)
        {
            if ((left == default(char)) ^ (right == default(char)))
                return char.IsNumber((char)(left + right)) ? NumericSimilarityRate : 0f;

            if (!IsCaseSensitive)
            {
                left = char.ToLower(left);
                right = char.ToLower(right);
            }

            return base.GetSimilarityImpl(left, right);
        }

        public override void RegisterMistake(char left, char right, float similarity)
        {
            if (!IsCaseSensitive)
            {
                left = char.ToLower(left);
                right = char.ToLower(right);
            }

            base.RegisterMistake(left, right, similarity);
        }
    }
}
