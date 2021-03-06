﻿using System.IO;

namespace Simila.Core
{
    public class CharacterSimilarityResolverFactory
    {
        private readonly IMistakeBasedSimilarityResolver<char> _resolver;

        public CharacterSimilarityResolverFactory(IMistakeBasedSimilarityResolver<char> resolver)
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

        public ISimilarityResolver<char> Build()
        {
            return _resolver;
        }

        public ISimilarityResolver<char> Default()
        {

            return AddEnglishCommonMistakes()
            .AddPersianCommonMistakes()
            .Build();
        }
    }
}