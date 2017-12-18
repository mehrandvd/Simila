using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using Microsoft.Practices.Unity;
using Simila.Core.Levenstein;
using Unity;

namespace Simila.Core
{
    public class Simila : SimilaBase<string>
    {
        public Simila(SimilaType constructionType, float? treshold)
        {
            WordMistakeRepository = new BuiltInWordMistakeRepository();
            CharacterMistakeRepository = new BuiltInCharacterMistakeRepository();

            if (treshold.HasValue)
            {
                Treshold = treshold.Value;
            }


            switch (constructionType)
            {
                case SimilaType.Automatic:
                    Resolver = GetDefalutResolver();
                    break;
                case SimilaType.Manual:
                    Resolver = new UnityContainer();
                    break;
                default:
                    throw new Exception(string.Format("Unknown SimilaType: {0}", constructionType.ToString()));
            }

            SetStringComparisonOptions(StringComparisonOptions.None);
        }

        public Simila()
            : this(SimilaType.Automatic, null)
        {
        }

        public Simila(float treshold)
            : this(SimilaType.Automatic, treshold)
        {
        }

        public Simila(SimilaType constructionType)
            : this(constructionType, null)
        {
        }

        public Simila(SimilarityRate similarityRate)
            : this((int)similarityRate * .1f)
        {
        }

        public IUnityContainer Resolver { get; set; }

        private static UnityContainer GetDefalutResolver()
        {
            var resolver = new UnityContainer();
            resolver.RegisterType<ISimilarityResolver<string>, PhraseSimilarityResolverLevenstein>();
            resolver.RegisterType<ISimilarityResolver<Word>, WordSimilarityResolverDefault>();
            resolver.RegisterType<ISimilarityResolver<char>, CharacterSimilarityResolverDefault>();
            resolver.RegisterType<IMistakeBasedSimilarityResolver<Word>, MistakeBasedSimilarityResolver<Word>>();
            resolver.RegisterType<IMistakeRepository<char>, BuiltInCharacterMistakeRepository>();
            resolver.RegisterType<IMistakeRepository<Word>, BuiltInWordMistakeRepository>();
            return resolver;
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
            get { return Resolver.Resolve<ISimilarityResolver<string>>(); }
        }

        public StringComparisonOptions StringComparisonOptions { get; private set; }

        public void SetStringComparisonOptions(StringComparisonOptions options)
        {
            StringComparisonOptions = options;
            Resolver.RegisterInstance(typeof(StringComparisonOptions), StringComparisonOptions);
        }

        public IMistakeRepository<Word> WordMistakeRepository { get; set; }
        public IMistakeRepository<char> CharacterMistakeRepository { get; set; }
    }

    [Flags]
    public enum StringComparisonOptions
    {
        None = 0,
        CaseSensitive,    
    }
}
