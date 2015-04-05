using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simila.Core.Levenstein.Mistakes
{
    class MistakesFactory
    {
        public static ICharacterMistakeRepository FromXml(string filename)
        {
            var mistakesRepo = new XmlFileCharacterMistakeRepository(filename);

            return mistakesRepo;
        }
    }
}
