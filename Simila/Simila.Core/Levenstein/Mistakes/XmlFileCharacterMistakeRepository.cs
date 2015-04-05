using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Simila.Core.Levenstein.Mistakes
{
    public class XmlFileCharacterMistakeRepository : ICharacterMistakeRepository
    {
        public string Filename { get; set; }
        private XElement _root;
        private List<CharacterMistake> _mistakes;

        public XmlFileCharacterMistakeRepository(string filename)
        {
            Filename = filename;
            Populate();
        }

        private void Populate()
        {
            _root = XElement.Load(File.OpenText(Filename));

            var result = from el in _root.Elements()
                        select
                            new CharacterMistake(
                                el.Attribute("Left").Value,
                                el.Attribute("Right").Value,
                                double.Parse(el.Attribute("Cost").Value));

            _mistakes = result.ToList();
        }

        public List<CharacterMistake> GetMistakes()
        {
            return _mistakes;
        }
    }
}