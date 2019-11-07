using Simila.Core.Resolver;

namespace Simila.Core
{
    public interface IGeneralSimilarityResolver<in T> : ISimilarityResolver<T>
    {
        void RegisterMistake(T left,T right, float similarity);
    }
}
