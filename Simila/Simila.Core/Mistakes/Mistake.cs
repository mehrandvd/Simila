using System;
using LevenshtienAlgorithm;

namespace Simila.Core.Levenstein.Mistakes
{
    public class Mistake<T>
    {
        public Mistake(T left, T right, double cost)
        {
            Left = left;
            Right = right;
            Cost = cost;
        }

        public Mistake(string left, string right, double cost)
        {
            if (typeof (T) == typeof (char))
            {
                Left = (T) (object) (left[0]);
                Right = (T) (object) (right[0]);
            }
            else if (typeof(T) == typeof(Word))
            {
                Left = (T)(object)(new Word(left));
                Right = (T)(object)(new Word(right));
            }
            else if (typeof(T) == typeof(Phrase))
            {
                Left = (T)(object)(new Phrase(left));
                Right = (T)(object)(new Phrase(right));
            }
            else
            {
                throw new Exception(string.Format("{0} is not available for mistakes.", typeof(T)));
            }

            Cost = cost;
        }

        public T Left { get; set; }
        public T Right { get; set; }
        public double Cost { get; set; }
    }
}
