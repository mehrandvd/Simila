using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Simila.Core;
using Simila.Core.Resolver.GeneralResolver;
using Simila.Core.Resolver.LevenshteinResolver;

namespace Simila.Studio
{
    public class SimilaStudioWordMistakeRepository : IMistakeRepository<Word>

    {
        private readonly SimilaProfile _profile;

        public SimilaStudioWordMistakeRepository(SimilaProfile profile)
        {
            _profile = profile;
        }

        private List<Mistake<Word>> _mistakes;


        public List<Mistake<Word>> GetMistakes()
        {
            LazyInitializer.EnsureInitialized(ref _mistakes, () =>
            {
                return (
                    from mistakeInstance in _profile.CharMistakes
                    select new Mistake<Word>
                    (
                        left: mistakeInstance.Left,
                        right: mistakeInstance.Right,
                        similarity: mistakeInstance.Similarity
                    )
                ).ToList();
            });
            return _mistakes;

        }
    }

    public class SimilaStudioCharacterMistakeRepository : IMistakeRepository<char>

    {
        private readonly SimilaProfile _profile;

        public SimilaStudioCharacterMistakeRepository(SimilaProfile profile)
        {
            _profile = profile;
        }

        private List<Mistake<char>> _mistakes;

        public List<Mistake<char>> GetMistakes()
        {
            LazyInitializer.EnsureInitialized(ref _mistakes, () =>
            {
                return (
                    from mistakeInstance in _profile.WordMistakes
                    select new Mistake<char>
                    (
                        left: mistakeInstance.Left[0],
                        right: mistakeInstance.Right[0],
                        similarity: mistakeInstance.Similarity
                    )
                ).ToList();
            });
            return _mistakes;

        }
    }
}
