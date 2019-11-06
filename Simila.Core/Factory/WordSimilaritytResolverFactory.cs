using System.IO;
using Simila.Core.Levenstein;

namespace Simila.Core
{
    public class WordSimilaritytResolverFactory
    {
        private readonly IMistakeBasedSimilarityResolver<Word> _resolver;

        public WordSimilaritytResolverFactory(IMistakeBasedSimilarityResolver<Word> resolver)
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
                    _resolver.RegisterMistake(mistake.Left, mistake.Right, mistake.Similarity);
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
                    _resolver.RegisterMistake(mistake.Left, mistake.Right, mistake.Similarity);
                }
            }

            return this;
        }

        public IMistakeBasedSimilarityResolver<Word> Build()
        {
            return _resolver;
        }

        public IMistakeBasedSimilarityResolver<Word> Default()
        {
            return AddEnglishCommonMistakes()
                .AddPersianCommonMistakes()
                .Build();
        }
    }
}