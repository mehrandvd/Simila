namespace Simila.Core.Levenstein
{
    public interface ILevenshteinExpression<T>
    {
        T[] GetElements();
        T this[int index] { get;}
        int Length { get; }
    }
}
