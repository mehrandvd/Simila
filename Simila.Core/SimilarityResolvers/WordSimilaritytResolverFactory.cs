using System.IO;
using LevenshtienAlgorithm;
using Simila.Core.CostResolvers;
using Simila.Core.Levenstein.Mistakes;

namespace Simila.Core.Levenstein.CostResolvers
{
    public class WordSimilaritytResolverFactory
    {
        private readonly LevensteinWordSimilarityResolver _resolver;

        public WordSimilaritytResolverFactory(LevensteinWordSimilarityResolver resolver)
        {
            _resolver = resolver;
        }

        public WordSimilaritytResolverFactory AddEnglishCommonMistakes()
        {
            if (File.Exists("CommonEnglishWordMistakes.xml"))
            {
                var repo = MistakesFactory.FromXml<Word>("CommonEnglishWordMistakes.xml");
                var mistakes = repo.GetMistakes();

                foreach (var mistake in mistakes)
                {
                    _resolver.SetMistakeSimilarity(mistake.Left, mistake.Right, mistake.Similarity);
                }
            }
                
            return this;
        }

        public WordSimilaritytResolverFactory AddPersianCommonMistakes()
        {
            if (File.Exists("CommonPersianWordMistakes.xml"))
            {
                var repo = MistakesFactory.FromXml<Word>("CommonPersianWordMistakes.xml");
                var mistakes = repo.GetMistakes();

                foreach (var mistake in mistakes)
                {
                    _resolver.SetMistakeSimilarity(mistake.Left, mistake.Right, mistake.Similarity);
                }
            }

            return this;
        }

        public LevensteinWordSimilarityResolver Build()
        {
            return _resolver;
        }

        public LevensteinWordSimilarityResolver Default()
        {
            return AddEnglishCommonMistakes()
                .AddPersianCommonMistakes()
                .Build();
        }
    }
}