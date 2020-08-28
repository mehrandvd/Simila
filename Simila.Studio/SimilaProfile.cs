using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Simila.Studio
{
    public class SimilaProfile
    {
        public List<string> DirtyWords { get; set; } = new List<string>();
        public string? WordMistakeRepositoryFilename { get; set; }
        public string? CharMistakeRepositoryFilename { get; set; }

        public List<MistakeInstance>? WordMistakes { get; set; }
        public List<MistakeInstance>? CharMistakes { get; set; }

        public void LoadProfile(string filename)
        {
            var path = Path.GetDirectoryName(filename) ?? "";

            var profileRoot = XElement.Load(filename);
            var dirtyWordsFile = profileRoot.Element("DirtyWords")?.Attribute("File")?.Value ?? throw new InvalidDataException("DirtyWords File is null");
            DirtyWords = File.ReadAllLines(Path.Combine(path, dirtyWordsFile)).ToList();

            var wordMistakesFile = profileRoot.Element("WordMistakes")?.Attribute("File")?.Value ?? throw new InvalidDataException("WordMistakes File is null");
            WordMistakeRepositoryFilename = Path.Combine(path, wordMistakesFile);
            var charMistakesFile = profileRoot.Element("CharacterMistakes")?.Attribute("File")?.Value ?? throw new InvalidDataException("CharacterMistakes File is null");
            CharMistakeRepositoryFilename = Path.Combine(path, charMistakesFile);

            if (File.Exists(WordMistakeRepositoryFilename))
            {
                var wordMistakesRoot = XElement.Load(WordMistakeRepositoryFilename);
                WordMistakes = (
                    from element in wordMistakesRoot.Elements("CommonMistake")
                    select new MistakeInstance
                    (
                        element.Attribute("Left")?.Value ?? throw new InvalidDataException("Mistake Left is null"),
                        element.Attribute("Right")?.Value ?? throw new InvalidDataException("Mistake Right is null"),
                        float.Parse(element.Attribute("Similarity")?.Value ?? throw new InvalidDataException("Mistake Value is null"))
                    )
                ).ToList();
            }

            if (File.Exists(CharMistakeRepositoryFilename))
            {
                var charMistakesRoot = XElement.Load(CharMistakeRepositoryFilename);
                CharMistakes = (
                    from element in charMistakesRoot.Elements("CommonMistake")
                    select new MistakeInstance
                    (
                        element.Attribute("Left")?.Value ?? throw new InvalidDataException("Mistake Left is null"),
                        element.Attribute("Right")?.Value ?? throw new InvalidDataException("Mistake Right is null"),
                        float.Parse(element.Attribute("Similarity")?.Value??"0")
                    )
                ).ToList();
            }
        }
    }
}