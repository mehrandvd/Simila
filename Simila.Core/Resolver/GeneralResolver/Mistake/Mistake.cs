﻿using System;
using Simila.Core.Resolver.LevenshteinResolver;

namespace Simila.Core.Resolver.GeneralResolver
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
                throw new Exception($"{typeof(T)} is not available for mistakes.");
            }

            Similarity = similarity;
        }

        public static implicit operator Mistake<T>((T Left, T Right, float Similarity) input)
        {
            return new Mistake<T>(input.Left, input.Right, input.Similarity);
        }

        public static implicit operator Mistake<T>((string Left, string Right, float Similarity) input)
        {
            return new Mistake<T>(input.Left, input.Right, input.Similarity);
        }

        public void Deconstruct(out T left, out T right, out float similarity)
        {
            left = Left;
            right = Right;
            similarity = Similarity;
        }

        public T Left { get; set; }
        public T Right { get; set; }
        public float Similarity { get; set; }
    }
}
