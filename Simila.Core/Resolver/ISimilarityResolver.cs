﻿namespace Simila.Core.Resolver
{
    public interface ISimilarityResolver<in T>
        where T : notnull
    {
        /// <summary>
        /// Gets the similarity of given strings. The similarity is a number between 0 and 1.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns> 
        float GetSimilarity(T left, T right);
    }
}