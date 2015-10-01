using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Simila.Core.Tests.SimilaStringTests
{
    [TestFixture]
    public class SimpleSimilaTests
    {
        [Test]
        public void Simila_ShouldWork_WithNoConfig()
        {
            var simila = new Simila();

            Assert.IsTrue(simila.AreSimilar("AAAAA", "AABAA"));
            Assert.IsTrue(simila.AreSimilar("ABC DEFGH IJKLM", "ABD DFFGH LJKIM"));

            Assert.IsTrue(simila.AreSimilar("Cat", "Kat"));
            Assert.IsTrue(simila.AreSimilar("Afshin", "Afsoon"));
            Assert.IsTrue(simila.AreSimilar("Monitor", "Monitoring"));
            Assert.IsTrue(simila.AreSimilar("Monica", "Nonica"));
            Assert.IsTrue(simila.AreSimilar("Monica", "Noxica"));



            Assert.IsFalse(simila.AreSimilar("AAAAA", "AXYBAA"));
            Assert.IsFalse(simila.AreSimilar("ABC DEFGH IJKLM", "XTD DDDGF LAKIN"));
        }

        [Test]
        public void Simila_ShouldWork_WithNoConfig_NotCaseSensitive()
        {
            var simila = new Simila();
            simila.SetStringComparisonOptions(StringComparisonOptions.None);

            Assert.IsTrue(simila.AreSimilar("AAAAA", "AABAA"));
            Assert.IsTrue(simila.AreSimilar("AAAAA", "aabaa"));
            Assert.IsTrue(simila.AreSimilar("ABC DEFGH IJKLM", "ABD DFFGH LJKIM"));

            Assert.IsTrue(simila.AreSimilar("CAt", "Kat"));
            Assert.IsTrue(simila.AreSimilar("AfsHIN", "Afsoon"));
            Assert.IsTrue(simila.AreSimilar("Monitor", "Monitoring"));
            Assert.IsTrue(simila.AreSimilar("MonICa", "Nonica"));
            Assert.IsTrue(simila.AreSimilar("Monica", "NOXiCa"));



            Assert.IsFalse(simila.AreSimilar("AAAAA", "AXYBAA"));
            Assert.IsFalse(simila.AreSimilar("ABC DEFGH IJKLM", "XTD DDDGF LAKIN"));
        }

        [Test]
        public void Simila_ShouldWork_WithNoConfig_CaseSensitive()
        {
            var simila = new Simila();
            simila.SetStringComparisonOptions(StringComparisonOptions.CaseSensitive);


            Assert.IsTrue(simila.AreSimilar("AAAAA", "AABAA"));
            Assert.IsFalse(simila.AreSimilar("AAAAA", "aabaa"));
            Assert.IsTrue(simila.AreSimilar("ABC DEFGH IJKLM", "ABD DFFGH LJKIM"));

            Assert.IsFalse(simila.AreSimilar("CAt", "Kat"));
            Assert.IsFalse(simila.AreSimilar("AfsHIN", "Afsoon"));
            Assert.IsTrue(simila.AreSimilar("Monitor", "Monitoring"));
            Assert.IsFalse(simila.AreSimilar("MonICa", "Nonica"));
            Assert.IsFalse(simila.AreSimilar("Monica", "NOXiCa"));



            Assert.IsFalse(simila.AreSimilar("AAAAA", "AXYBAA"));
            Assert.IsFalse(simila.AreSimilar("ABC DEFGH IJKLM", "XTD DDDGF LAKIN"));
        }
    }
}
