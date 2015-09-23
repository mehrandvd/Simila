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

            Assert.IsTrue(simila.IsSimilar("AAAAA", "AABAA"));
            Assert.IsTrue(simila.IsSimilar("ABC DEFGH IJKLM", "ABD DFFGH LJKIM"));

            Assert.IsTrue(simila.IsSimilar("Cat", "Kat"));
            Assert.IsTrue(simila.IsSimilar("Afshin", "Afsoon"));
            Assert.IsTrue(simila.IsSimilar("Monitor", "Monitoring"));
            Assert.IsTrue(simila.IsSimilar("Monica", "Nonica"));
            Assert.IsTrue(simila.IsSimilar("Monica", "Noxica"));



            Assert.IsFalse(simila.IsSimilar("AAAAA", "AXYBAA"));
            Assert.IsFalse(simila.IsSimilar("ABC DEFGH IJKLM", "XTD DDDGF LAKIN"));
        }
    }
}
