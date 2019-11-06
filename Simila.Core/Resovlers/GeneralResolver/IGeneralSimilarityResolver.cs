namespace Simila.Core
{
    public interface IGeneralSimilarityResolver<T> : ISimilarityResolver<T>
    {
        void RegisterMistake(T left,T right, float similarity);
    }
}
