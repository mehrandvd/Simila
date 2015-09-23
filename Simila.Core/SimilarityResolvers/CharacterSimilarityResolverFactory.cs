using System.IO;
using Simila.Core.CostResolvers;
using Simila.Core.Levenstein.Mistakes;

namespace Simila.Core.Levenstein.CostResolvers
{
    public class CharacterSimilarityResolverFactory
    {
        private readonly CharacterMistakeBasedSimilarityResolver _resolver;

        public CharacterSimilarityResolverFactory(CharacterMistakeBasedSimilarityResolver resolver)
        {
            _resolver = resolver;
        }

        public CharacterSimilarityResolverFactory AddEnglishCommonMistakes()
        {
            if (File.Exists("CommonEnglishCharacterMistakes.xml"))
            {
                var repo = MistakesFactory.FromXml<char>("CommonEnglishCharacterMistakes.xml");
                var mistakes = repo.GetMistakes();

                foreach (var mistake in mistakes)
                {
                    _resolver.SetMistakeSimilarity(mistake.Left, mistake.Right, mistake.Similarity);
                }
            }

            return this;
        }

        public CharacterSimilarityResolverFactory AddPersianCommonMistakes()
        {
            if (File.Exists("CommonPersianCharacterMistakes.xml"))
            {
                var repo = MistakesFactory.FromXml<char>("CommonPersianCharacterMistakes.xml");
                var mistakes = repo.GetMistakes();

                foreach (var mistake in mistakes)
                {
                    _resolver.SetMistakeSimilarity(mistake.Left, mistake.Right, mistake.Similarity);
                }
            }

            return this;
        }

        public CharacterMistakeBasedSimilarityResolver Build()
        {
            return _resolver;
        }

        public CharacterMistakeBasedSimilarityResolver Default()
        {

            return AddEnglishCommonMistakes()
            .AddPersianCommonMistakes()
            .Build();
        }
    }
}