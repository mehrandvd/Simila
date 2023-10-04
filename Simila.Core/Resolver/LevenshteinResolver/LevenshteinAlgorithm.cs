﻿using System;

namespace Simila.Core.Resolver.LevenshteinResolver
{
    public class LevenshteinAlgorithm<TExpression, TElement> : ILevenshteinAlgorithm<TExpression, TElement>
        where TExpression : notnull, ILevenshteinExpression<TElement>
        where TElement : notnull
    {
        public LevenshteinAlgorithm(ISimilarityResolver<TElement> elementSimilarityResolver)
        {
            ElementSimilarityResolver = elementSimilarityResolver;
        }

        /// <summary>
        /// Computes the Levenshtein distance between <param name="left">left</param> and <param name="right">right</param>
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public virtual float GetDistance(TExpression left, TExpression right)
        {
            int n = left.Length;
            int m = right.Length;
            var d = new float[2, m + 1];

            int newrow = 1;
            int oldrow = 0;
            int temp = 0;

            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            //filling the first row and columns of the matrix
            for (int i = 0; i < 2; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // comparing
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    float cost = 1 - ElementSimilarityResolver.GetSimilarity(right[j - 1], left[i - 1]);

                    d[newrow, j] =
                        Math.Min(
                            Math.Min(
                                d[oldrow, j] + 1,
                                d[newrow, j - 1] + 1
                            ),
                            d[oldrow, j - 1] + cost
                        );

                }

                temp = newrow;
                newrow = oldrow;
                oldrow = temp;

                d[newrow, 0] = i + 1;

            }

            return d[temp, m];
        }

        /// <summary>
        /// Gets the similarity of given strings. The similarity is a number between 0 and 1.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>        
        public virtual float GetSimilarity(TExpression left, TExpression right)
        {
            var levenshtienDistance = GetDistance(left, right);
            int maxlength = Math.Max(left.Length, right.Length);

            float ratio = levenshtienDistance / maxlength;
            var similarityRatio = (1 - (ratio));
            return similarityRatio;
            //return levenshtiendistance;
        }

        /// <summary>
        /// Gets or sets the elementSimilarityResolver to use in the instance of the algorithm.
        /// </summary>
        public ISimilarityResolver<TElement> ElementSimilarityResolver { get; private set; }
    }
}
