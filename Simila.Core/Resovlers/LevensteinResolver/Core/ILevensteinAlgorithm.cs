namespace Simila.Core.Levenstein
{
    public interface ILevensteinAlgorithm<TExpression, TElement> : ISimilarityResolver<TExpression>
    {
        /// <summary>
        /// Gets or sets the similarityResolver to use in the instance of the algorithm.
        /// </summary>
        ISimilarityResolver<TElement> ElementSimilarityResolver { get; }
    }
}