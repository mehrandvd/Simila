namespace Simila.Core
{
    public interface IMistakeBasedSimilarityResolver<T> : ISimilarityResolver<T>
    {
        void RegisterMistake(T left,T right, float similarity);
    }
}
