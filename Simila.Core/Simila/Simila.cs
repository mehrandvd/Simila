using System;
using Simila.Core.Levenstein;

namespace Simila.Core
{
    public class Simila : SimilaBase<string>
    {
        public Simila(float treshold = .6f, StringComparisonOptions stringComparisonOptions = StringComparisonOptions.None)
        {
            StringComparisonOptions = stringComparisonOptions;
            Algorithm = new PhraseSimilarityResolverLevenstein(stringComparisonOptions);

            WordMistakeRepository = new BuiltInWordMistakeRepository();
            CharacterMistakeRepository = new BuiltInCharacterMistakeRepository();

            Treshold = treshold;
        }

        //private static UnityContainer GetDefalutResolver()
        //{
        //    var resolver = new UnityContainer();
        //    resolver.RegisterType<ISimilarityResolver<string>, PhraseSimilarityResolverLevenstein>();
        //    resolver.RegisterType<ISimilarityResolver<Word>, WordSimilarityResolverDefault>();
        //    resolver.RegisterType<ISimilarityResolver<char>, CharacterSimilarityResolverDefault>();
        //    resolver.RegisterType<IMistakeBasedSimilarityResolver<Word>, MistakeBasedSimilarityResolver<Word>>();
        //    resolver.RegisterType<IMistakeRepository<char>, BuiltInCharacterMistakeRepository>();
        //    resolver.RegisterType<IMistakeRepository<Word>, BuiltInWordMistakeRepository>();
        //    return resolver;
        //}

        public float GetSimilarityPercent(object left, object right)
        {
            return base.GetSimilarityPercent(left.ToString(), right.ToString());
        }

        public bool AreSimilar(object left, object right)
        {
            return base.AreSimilar(left.ToString(), right.ToString());
        }

        public override ISimilarityResolver<string> Algorithm { get; }

        public StringComparisonOptions StringComparisonOptions { get; private set; }

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
