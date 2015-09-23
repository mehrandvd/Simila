namespace Simila.Core.Levenstein
{
    public interface ILevenshteinExpression<TElement>//<TExpression, TElement>// : ISimilarable<TExpression>
    {
        TElement[] GetElements();
        TElement this[int index] { get;}
        int Length { get; }
    }
}
