namespace Simila.Core.Resolver.LevenshteinResolver
{
    public interface ILevenshteinAlgorithm<in TExpression, in TElement> : ISimilarityResolver<TExpression>
    {
        /// <summary>
        /// Gets or sets the similarityResolver to use in the instance of the algorithm.
        /// </summary>
        ISimilarityResolver<TElement> ElementSimilarityResolver { get; }
    }
}