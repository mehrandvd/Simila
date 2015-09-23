namespace Simila.Core.Levenstein
{
    public interface ISimilarable<T>
    {
        float GetSimilarity(T other);
    }
}