using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevenshtienAlgorithm
{
    public interface ILevenshteinExpression<T>
    {
        T[] GetElements();
        T this[int index] { get;}
        int Length { get; }
    }
}
