using System;

namespace Simila.Core.Levenstein
{
    public class Phrase : ILevenshteinExpression<Word>, IEquatable<Phrase>
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


        public static implicit operator Phrase(string text)
        {
            return new Phrase(text);
        }

        public bool Equals(Phrase other)
        {
            if (other == null)
                return false;

            return InnerText == other.InnerText;
        }

        public override int GetHashCode()
        {
            return InnerText.GetHashCode();
        }

        public override string ToString()
        {
            return InnerText;
        }
    }
}
