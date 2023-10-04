namespace Simila.Core.Resolver.LevenshteinResolver
{
    public interface ILevenshteinExpression<out TElement>
        where TElement : notnull
    {
        TElement[] GetElements();
        TElement this[int index] { get;}
        int Length { get; }
    }
}
