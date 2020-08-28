using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Simila.Studio
{
    public class RawFileTextInstanceSource : ITextInstanceSource
    {
        private readonly string _filepath;

        public RawFileTextInstanceSource(string filepath)
        {
            _filepath = filepath;
        }
        public List<TextInstance> GetTextInstances()
        {
            var query = from line in File.ReadLines(_filepath)
                select new TextInstance(line);

            return query.ToList();
        }
    }

    public interface ITextInstanceSource
    {
        List<TextInstance> GetTextInstances();
    }
}