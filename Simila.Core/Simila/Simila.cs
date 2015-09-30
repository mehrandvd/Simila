using System.Runtime.CompilerServices;
using Microsoft.Practices.Unity;
using Simila.Core.Levenstein;
using Simila.Core.SimilarityResolvers;

namespace Simila.Core
{
    public class Simila : SimilaBase<string>
    {
        public Simila()
        {
            Init();
        }

        public Simila(float treshold)
            : this()
        {
            Treshold = treshold;
        }

        public Simila(SimilarityRate similarityRate)
            : this()
        {
            Treshold = (int)similarityRate * .1f;
        }

        public Simila(IUnityContainer container)
            : this()
        {
            Container = container;
        }

        public IUnityContainer Container { get; set; }

        private void Init()
        {
            if (Container == null)
            {
                Container = new UnityContainer();
                Container.RegisterType<ISimilarityResolver<string>, PhraseSimilarityResolverLevenstein>();
                Container.RegisterType<ISimilarityResolver<Word>, WordSimilarityResolverDefault>();
                Container.RegisterType<ISimilarityResolver<char>, CharacterSimilarityResolverDefault>();
            }
        }

        public float GetSimilarityPercent(object left, object right)
        {
            return base.GetSimilarityPercent(left.ToString(), right.ToString());
        }

        public bool AreSimilar(object left, object right)
        {
            return base.AreSimilar(left.ToString(), right.ToString());
        }

        public override ISimilarityResolver<string> Algorithm
        {
            get { return Container.Resolve<ISimilarityResolver<string>>(); }
        }
    }
}
