using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using Simila.Core.Levenstein;

namespace Simila.Core.Tests.SimilaStringTests
{
    [TestFixture]
    public class PluggableSimilaTests
    {
        [Test]
        [ExpectedException(typeof(ResolutionFailedException))]
        public void Simila_ShouldThrowException_WithNoConfig()
        {
            var simila = new Simila(SimilaType.Manual, null);

            Assert.IsTrue(simila.AreSimilar("Cat", "Kat"));
        }

        [Test]
        public void Simila_ShouldWork_WithOverridingConfigs()
        {
            var simila = new Simila();

            Assert.IsTrue(simila.AreSimilar("Cat", "Kat"));

            // Overriding Word similarity resolver method.
            simila.Resolver.RegisterType<ISimilarityResolver<Word>, MistakeBasedSimilarityResolver<Word>>();

            Assert.IsFalse(simila.AreSimilar("Cat", "Kat"));
            Assert.IsTrue(simila.AreSimilar("color", "colour"));
        }
    }
}
