using Simila.Core.SimilarityResolvers;

namespace Simila.Core.Levenstein
{
    public interface ILevensteinAlgorithm<TExpression, TElement>
    {
        /// <summary>
        /// Gets the similarity of given strings. The similarity is a number between 0 and 1.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>        
        float GetSimilarity(TExpression left, TExpression right);

        /// <summary>
        /// Gets or sets the similarityResolver to use in the instance of the algorithm.
        /// </summary>
        ISimilarityResolver<TElement> SimilarityResolver { get; }
    }
}