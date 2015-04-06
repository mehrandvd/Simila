using System.IO;
using Simila.Core.Levenstein.Mistakes;

namespace Simila.Core.Levenstein.CostResolvers
{
    public class CharacterCostResolverFactory
    {
        private readonly CharacterCostResolver _resolver;

        public CharacterCostResolverFactory(CharacterCostResolver resolver)
        {
            _resolver = resolver;
        }

        public CharacterCostResolverFactory AddEnglishCommonMistakes()
        {
            if (File.Exists("CommonEnglishCharacterMistakes.xml"))
            {
                var repo = MistakesFactory.FromXml<char>("CommonEnglishCharacterMistakes.xml");
                var mistakes = repo.GetMistakes();

                foreach (var mistake in mistakes)
                {
                    _resolver.SetCost(mistake.Left, mistake.Right, mistake.Cost);
                }
            }

            return this;
        }

        public CharacterCostResolverFactory AddPersianCommonMistakes()
        {
            if (File.Exists("CommonPersianCharacterMistakes.xml"))
            {
                var repo = MistakesFactory.FromXml<char>("CommonPersianCharacterMistakes.xml");
                var mistakes = repo.GetMistakes();

                foreach (var mistake in mistakes)
                {
                    _resolver.SetCost(mistake.Left, mistake.Right, mistake.Cost);
                }
            }

            return this;
        }

        public CharacterCostResolver Build()
        {
            return _resolver;
        }

        public CharacterCostResolver Default()
        {

            return AddEnglishCommonMistakes()
            .AddPersianCommonMistakes()
            .Build();
        }
    }
}