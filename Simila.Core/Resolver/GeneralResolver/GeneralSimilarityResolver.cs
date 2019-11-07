using System;
using System.Collections.Generic;

namespace Simila.Core.Resolver.GeneralResolver
{
    /// <summary>
    /// A mistake based similarity resolver uses a mistakeRepository to resolve similarities.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GeneralSimilarityResolver<T> : IGeneralSimilarityResolver<T>
    {
        public Func<T, T, float?> MistakeAlgorithm { get; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<T, Dictionary<T, float>> Mistakes { get; private set; }

        /// <summary>
        /// A mistake based similarity resolver uses a <param name="mistakeRepository"></param> to resolve similarities.
        /// </summary>
        public GeneralSimilarityResolver(IMistakeRepository<T> mistakeRepository = null, Func<T, T, float?> mistakeAlgorithm = null)
        {
            MistakeAlgorithm = mistakeAlgorithm;
            Mistakes = new Dictionary<T, Dictionary<T, float>>();

            if (mistakeRepository != null)
            {
                foreach (var mistake in mistakeRepository.GetMistakes())
                {
                    RegisterMistake(mistake.Left, mistake.Right, mistake.Similarity);
                }
            }
        }

        /// <summary>
        /// Returns the similarity rate of <param name="left"></param> and <param name="right"></param>
        /// </summary>
        /// <returns></returns>
        public float GetSimilarity(T left, T right)
        {
            return GetSimilarityImpl(left, right) ?? 0;
        }

        protected virtual float? GetSimilarityImpl(T left, T right)
        {
            var Null = default(T);

            if (
                (left == null || left.Equals(Null)) ^
                (right == null || right.Equals(Null))
            )
            {
                return 0f;
            }

            if (left != null && left.Equals(right))
                return 1;

            var similarity = MistakeAlgorithm?.Invoke(left, right);
            if (similarity != null)
                return similarity.Value;

            return CalculateSimilarityBasedOnMistakes(left, right);
        }

        /// <summary>
        /// Registers a new mistake in the resolver.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="similarity"></param>
        public virtual void RegisterMistake(T left, T right, float similarity)
        {
            var mistakesForLeft = GetOrAddRelatedMistakes(left);
            var mistakesForRight = GetOrAddRelatedMistakes(right);

            mistakesForLeft[right] = similarity;
            mistakesForRight[left] = similarity;
        }

        private float? CalculateSimilarityBasedOnMistakes(T left, T right)
        {
            if (Mistakes.ContainsKey(left))
            {
                var relevantMistakes = Mistakes[left];
                if (relevantMistakes.ContainsKey(right))
                {
                    return relevantMistakes[right];
                }
            }

            else if (Mistakes.ContainsKey(right))
            {
                var relevantMistakes = Mistakes[right];
                if (relevantMistakes.ContainsKey(left))
                {
                    return relevantMistakes[left];
                }
            }

            return null;
        }

        private Dictionary<T, float> GetOrAddRelatedMistakes(T left)
        {
            Dictionary<T, float> dictionary = null;
            if (Mistakes.ContainsKey(left))
            {
                dictionary = Mistakes[left];
            }
            else
            {
                dictionary = new Dictionary<T, float>();
                Mistakes.Add(left, dictionary);
            }
            return dictionary;
        }
    }
}