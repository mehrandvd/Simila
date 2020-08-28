using Simila.Core.Resolver;

namespace Simila.Core
{
    public interface IGeneralSimilarityResolver<in T> : ISimilarityResolver<T>
        where T : notnull
    {
        void RegisterMistake(T left,T right, float similarity);
    }
}
