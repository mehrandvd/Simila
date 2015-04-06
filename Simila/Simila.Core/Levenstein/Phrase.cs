using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simila.Core.Levenstein;

namespace LevenshtienAlgorithm
{
    public class Phrase : ILevenshteinExpression<Word>
    {
        private Word[] _elements;

        public Phrase(string innerText)
        {
            InnerText = innerText;
            Splitters = new string[] {" "};
        }

        public string InnerText { get; set; }
        public Word[] Elements
        {
            get
            {
                if (_elements == null)
                {
                    _elements = GetElements();
                }
                return _elements;
            }
        }

        public Word[] GetElements()
        {
            var elements = InnerText.Split(Splitters, StringSplitOptions.RemoveEmptyEntries);
            Word[] wordElements  = new Word[elements.Length];
            for (int index = 0; index < elements.Length; index++)
            {
                var element = elements[index];
                wordElements[index] = new Word(element);
            }
            return wordElements;
        }

        public string[] Splitters { get; set; }

        public Word this[int index]
        {
            get { return Elements[index]; }
        }

        public int Length { get { return Elements.Length; } }
    }
}
