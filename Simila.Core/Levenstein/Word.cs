using System;
using System.Collections.Generic;
using LevenshtienAlgorithm;

namespace Simila.Core.Levenstein
{
    public class Word : ILevenshteinExpression<char>, IEquatable<Word>
    {
        public Word(string innerText)
        {
            InnerText = innerText;
        }
        public string InnerText { get; set; }
        public char[] GetElements()
        {
            return InnerText.ToCharArray();
        }

        public char this[int index]
        {
            get { return InnerText[index]; }
        }

        public int Length { get { return InnerText.Length; } }

        public static implicit operator Word(string text)
        {
            return new Word(text);
        }

        public bool Equals(Word other)
        {
            if (other == null)
                return false;

            return InnerText == other.InnerText;
        }

        public override int GetHashCode()
        {
            return InnerText.GetHashCode();
        }

        //public float GetSimilarity(Word other)
        //{
        //    throw new NotImplementedException();
        //}

        public override string ToString()
        {
            return InnerText;
        }
    }
}
