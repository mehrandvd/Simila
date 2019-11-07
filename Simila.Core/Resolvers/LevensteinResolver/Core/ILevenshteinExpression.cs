namespace Simila.Core.Levenstein
{
    public interface ILevenshteinExpression<out TElement>
    {
        TElement[] GetElements();
        TElement this[int index] { get;}
        int Length { get; }
    }
}
