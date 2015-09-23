using System.Collections.Generic;
using LevenshtienAlgorithm;

namespace Simila.Core.CostResolvers
{
    public class MistakeBasedSimilarityResolver<T> : IMistakeBasedSimilarityResolver<T>
    {
        protected MistakeBasedSimilarityResolver()
        {
            MistakesRepository = new Dictionary<T, Dictionary<T, float>>();
        }
        
        protected Dictionary<T, Dictionary<T, float>> MistakesRepository { get; set; }

        public virtual float GetSimilarityWithNull(T character)
        {
            return 0f;
        }
        
        public virtual float GetSimilarity(T left, T right)
        {
            if (left.Equals(right))
                return 1;

            var similarityByReposiroty = GetMistakeSimlarityFromRepository(left, right);

            return similarityByReposiroty ?? 0;
        }

        public virtual void SetMistakeSimilarity(T left, T right, float similarity)
        {
            var mistakesForLeft = GetRegisteredMistakes(left);
            var mistakesForRight = GetRegisteredMistakes(right);

            mistakesForLeft[right] = similarity;
            mistakesForRight[left] = similarity;
        }

        private float? GetMistakeSimlarityFromRepository(T left, T right)
        {
            if (MistakesRepository.ContainsKey(left))
            {
                var relevantMistakes = MistakesRepository[left];
                if (relevantMistakes.ContainsKey(right))
                {
                    return relevantMistakes[right];
                }
            }

            else if (MistakesRepository.ContainsKey(right))
            {
                var relevantMistakes = MistakesRepository[right];
                if (relevantMistakes.ContainsKey(left))
                {
                    return relevantMistakes[left];
                }
            }

            return null;
        }
        
        private Dictionary<T, float> GetRegisteredMistakes(T left)
        {
            Dictionary<T, float> dictionary = null;
            if (MistakesRepository.ContainsKey(left))
            {
                dictionary = MistakesRepository[left];
            }
            else
            {
                dictionary = new Dictionary<T, float>();
                MistakesRepository.Add(left, dictionary);
            }
            return dictionary;
        }
    }
}