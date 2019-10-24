using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simila.Core.Tests
{
    [TestClass]
    public class XmlFileCharacterMistakeRepositoryTests
    {
        [TestMethod]
        public void CommonEnglishMistakesShouldLoadFromXml()
        {
            Directory.SetCurrentDirectory(AppContext.BaseDirectory);

            var mistakesRepo = new XmlFileMistakeRepository<char>("CommonEnglishCharacterMistakes.xml");
            
            Assert.IsTrue(mistakesRepo.GetMistakes().Any());
        }

        [TestMethod]
        public void CommonPersianMistakesShouldLoadFromXml()
        {
            Directory.SetCurrentDirectory(AppContext.BaseDirectory);

            var mistakesRepo = new XmlFileMistakeRepository<char>("CommonPersianCharacterMistakes.xml");

            Assert.IsTrue(mistakesRepo.GetMistakes().Any());
        }
    }
}
