using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Simila.Studio
{
    public class SimilaProfile
    {
        public List<string> DirtyWords { get; set; } = new List<string>();
        public string WordMistakeRepositoryFilename { get; set; }
        public string CharMistakeRepositoryFilename { get; set; }

        public List<MistakeInstance> WordMistakes { get; set; }
        public List<MistakeInstance> CharMistakes { get; set; }

        public void LoadProfile(string filename)
        {
            var path = Path.GetDirectoryName(filename);

            var profileRoot = XElement.Load(filename);
            var dirtyWordsFile = profileRoot.Element("DirtyWords")?.Attribute("File")?.Value;
            DirtyWords = File.ReadAllLines(Path.Combine(path, dirtyWordsFile)).ToList();

            WordMistakeRepositoryFilename = Path.Combine(path, profileRoot.Element("WordMistakes")?.Attribute("File")?.Value);
            CharMistakeRepositoryFilename = Path.Combine(path, profileRoot.Element("CharacterMistakes")?.Attribute("File")?.Value);

            if (File.Exists(WordMistakeRepositoryFilename))
            {
                var wordMistakesRoot = XElement.Load(WordMistakeRepositoryFilename);
                WordMistakes = (
                    from element in wordMistakesRoot.Elements("CommonMistake")
                    select new MistakeInstance()
                    {
                        Left = element.Attribute("Left")?.Value,
                        Right = element.Attribute("Right")?.Value,
                        Similarity = float.Parse(element.Attribute("Similarity")?.Value)
                    }
                ).ToList();
            }

            if (File.Exists(CharMistakeRepositoryFilename))
            {
                var charMistakesRoot = XElement.Load(CharMistakeRepositoryFilename);
                CharMistakes = (
                    from element in charMistakesRoot.Elements("CommonMistake")
                    select new MistakeInstance()
                    {
                        Left = element.Attribute("Left")?.Value,
                        Right = element.Attribute("Right")?.Value,
                        Similarity = float.Parse(element.Attribute("Similarity")?.Value)
                    }
                ).ToList();
            }
        }
    }
}