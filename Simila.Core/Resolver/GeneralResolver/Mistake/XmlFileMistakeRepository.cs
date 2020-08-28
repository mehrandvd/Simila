using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Simila.Core.Resolver.GeneralResolver
{
    public class XmlFileMistakeRepository<T> : IMistakeRepository<T>
    {
        public string Filename { get; set; }
        private List<Mistake<T>>? _mistakes;

        public XmlFileMistakeRepository(string filename)
        {
            Filename = filename;
            Populate();
        }

        private void Populate()
        {
            var root = XElement.Load(File.OpenText(Filename));

            var result = from el in root.Elements()
                select
                    new Mistake<T>(
                        el.Attribute("Left")?.Value ?? throw new InvalidDataException("Mistake Left is null"),
                        el.Attribute("Right")?.Value ?? throw new InvalidDataException("Mistake Right is null"),
                        float.Parse(el.Attribute("Similarity")?.Value ?? "0"));

            _mistakes = result.ToList();
        }

        public List<Mistake<T>> GetMistakes()
        {
            if (_mistakes is null)
                throw new InvalidOperationException("Mistakes are not populated correctly.");

            return _mistakes;
        }
    }
}