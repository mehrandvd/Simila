using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Simila.Core.Resolver.GeneralResolver
{
    public class XmlFileMistakeRepository<T> : IMistakeRepository<T>
    {
        public string Filename { get; set; }
        private XElement _root;
        private List<Mistake<T>> _mistakes;

        public XmlFileMistakeRepository(string filename)
        {
            Filename = filename;
            Populate();
        }

        private void Populate()
        {
            _root = XElement.Load(File.OpenText(Filename));

            var result = from el in _root.Elements()
                        select
                            new Mistake<T>(
                                el.Attribute("Left").Value,
                                el.Attribute("Right").Value,
                                float.Parse(el.Attribute("Similarity").Value));

            _mistakes = result.ToList();
        }

        public List<Mistake<T>> GetMistakes()
        {
            return _mistakes;
        }
    }
}