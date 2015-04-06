using System.IO;
using LevenshtienAlgorithm;
using Simila.Core.Levenstein.Mistakes;

namespace Simila.Core.Levenstein.CostResolvers
{
    public class WordCostResolverFactory
    {
        private readonly WordCostResolver _resolver;

        public WordCostResolverFactory(WordCostResolver resolver)
        {
            _resolver = resolver;
        }

        public WordCostResolverFactory AddEnglishCommonMistakes()
        {
            if (File.Exists("CommonEnglishWordMistakes.xml"))
            {
                var repo = MistakesFactory.FromXml<Word>("CommonEnglishWordMistakes.xml");
                var mistakes = repo.GetMistakes();

                foreach (var mistake in mistakes)
                {
                    _resolver.SetCost(mistake.Left, mistake.Right, mistake.Cost);
                }
            }
                
            return this;
        }

        public WordCostResolverFactory AddPersianCommonMistakes()
        {
            if (File.Exists("CommonPersianWordMistakes.xml"))
            {
                var repo = MistakesFactory.FromXml<Word>("CommonPersianWordMistakes.xml");
                var mistakes = repo.GetMistakes();

                foreach (var mistake in mistakes)
                {
                    _resolver.SetCost(mistake.Left, mistake.Right, mistake.Cost);
                }
            }

            return this;
        }

        public WordCostResolver Build()
        {
            return _resolver;
        }

        public WordCostResolver Default()
        {
            return AddEnglishCommonMistakes()
                .AddPersianCommonMistakes()
                .Build();
        }
    }
}