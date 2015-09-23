using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Simila.Core.SimilarityResolvers;

namespace Simila.Core.Tests
{
    [TestFixture]
    public class XmlFileCharacterMistakeRepositoryTests
    {
        [Test]
        public void CommonEnglishMistakesShouldLoadFromXml()
        {
            var mistakesRepo = new XmlFileMistakeRepository<char>("CommonEnglishCharacterMistakes.xml");
            
            CollectionAssert.IsNotEmpty(mistakesRepo.GetMistakes());
        }

        [Test]
        public void CommonPersianMistakesShouldLoadFromXml()
        {
            var mistakesRepo = new XmlFileMistakeRepository<char>("CommonPersianCharacterMistakes.xml");

            CollectionAssert.IsNotEmpty(mistakesRepo.GetMistakes());
        }
    }
}
