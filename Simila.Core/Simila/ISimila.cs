namespace Simila.Core
{
    public interface ISimila<T>
    {
        double Treshold { get; set; }

        bool IsSimilar(T left, T right);

        float GetSimilarityPercent(T left, T right);
    }
}