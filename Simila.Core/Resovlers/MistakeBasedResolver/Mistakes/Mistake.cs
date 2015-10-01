using System;
using Simila.Core.Levenstein;

namespace Simila.Core
{
    public class Mistake<T>
    {
        public Mistake(T left, T right, float similarity)
        {
            Left = left;
            Right = right;
            Similarity = similarity;
        }

        public Mistake(string left, string right, float similarity)
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

            Similarity = similarity;
        }

        public T Left { get; set; }
        public T Right { get; set; }
        public float Similarity { get; set; }
    }
}
