namespace Simila.Core
{
    public interface ISimila<T>
    {
        float Treshold { get; set; }

        bool AreSimilar(T left, T right);

        float GetSimilarityPercent(T left, T right);
    }
}