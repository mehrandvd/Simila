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
    }
}
