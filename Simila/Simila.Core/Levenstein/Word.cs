using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevenshtienAlgorithm
{
    public class Word : ILevenshteinExpression<char>
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
    }
}
