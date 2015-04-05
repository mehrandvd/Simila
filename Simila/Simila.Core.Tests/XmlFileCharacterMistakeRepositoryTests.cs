using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Simila.Core.Levenstein.Mistakes;

namespace Simila.Core.Tests
{
    [TestFixture]
    public class XmlFileCharacterMistakeRepositoryTests
    {
        [Test]
        public void CommonEnglighMistakesShouldLoadFromXml()
        {
            var mistakesRepo = new XmlFileCharacterMistakeRepository("CommonEnglishCharacterMistakes.xml");
            
            CollectionAssert.IsNotEmpty(mistakesRepo.GetMistakes());
        }
    }
}
