using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simila.Core.Levenstein.Mistakes
{
    class MistakesFactory
    {
        public static IMistakeRepository<T> FromXml<T>(string filename)
        {
            var mistakesRepo = new XmlFileMistakeRepository<T>(filename);

            return mistakesRepo;
        }
    }
}
