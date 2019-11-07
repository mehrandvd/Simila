using System.Collections.Generic;
using System.Text.RegularExpressions;
using Simila.Core.Resolver.LevenshteinResolver;
using Simila.Core.Resolver.GeneralResolver;

namespace Simila.Core.Resolver
{
    public class SharedPairResolver : ISimilarityResolver<string>
    {
        /// <summary>
        /// Compares the two strings based on letter pair matches
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>The percentage match from 0.0 to 1.0 where 1.0 is 100%</returns>
        public float GetSimilarity(string left, string right)
        {
            List<string> pairsLeft = GetPhrasePairs(left.ToUpper());
            List<string> pairsRight = GetPhrasePairs(right.ToUpper());

            var costResolver = new WordSimilarityResolver(mistakesRepository: new BuiltInWordMistakeRepository());

            int intersection = 0;
            int union = pairsLeft.Count + pairsRight.Count;

            foreach (string pairLeft in pairsLeft)
            {
                for (int j = 0; j < pairsRight.Count; j++)
                {
                    //if (pairLeft == pairsRight[j])
                    if (costResolver.GetSimilarity((Word) pairLeft, (Word) pairsRight[j]) > 0.5)
                    {
                        intersection++;
                        pairsRight.RemoveAt(j);//Must remove the match to prevent "GGGG" from appearing to match "GG" with 100% success

                        break;
                    }
                }
            }

            return (2.0f * intersection) / union;
        }

        /// <summary>
        /// Gets all letter pairs for each
        /// individual word in the string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private List<string> GetPhrasePairs(string str)
        {
            var allPairs = new List<string>();

            string[] words = Regex.Split(str, @"\s");

            foreach (string word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    IEnumerable<string> pairsInWord = GetWordPairs(word);
                    allPairs.AddRange(pairsInWord);
                }
            }

            return allPairs;
        }

        /// <summary>
        /// Generates an array containing every 
        /// two consecutive letters in the input string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private IEnumerable<string> GetWordPairs(string str)
        {
            int numPairs = str.Length - 1;

            var pairs = new string[numPairs];

            for (int i = 0; i < numPairs; i++)
            {
                pairs[i] = str.Substring(i, 2);
            }

            return pairs;
        }
    }
}
