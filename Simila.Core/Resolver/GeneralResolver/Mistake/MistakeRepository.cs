using System.Collections.Generic;
using Simila.Core.Resolver.GeneralResolver;

namespace Simila.Core.Resolver.GeneralResolver
{
    public class MistakeRepository<TElement> : IMistakeRepository<TElement>
    {
        private readonly List<Mistake<TElement>> _mistakes = new List<Mistake<TElement>>();

        public MistakeRepository()
        {
            
        }

        public MistakeRepository(Mistake<TElement>[] mistakes)
        {
            if (mistakes != null)
            {
                foreach (var mistake in mistakes)
                {
                    AddMistake(mistake.Left, mistake.Right, mistake.Similarity);
                }
            }
        }
        public void AddMistake(TElement left, TElement right, float similarity)
        {
            _mistakes.Add(new Mistake<TElement>(left, right, similarity));
        }

        public List<Mistake<TElement>> GetMistakes()
        {
            return _mistakes;
        }
    }
}