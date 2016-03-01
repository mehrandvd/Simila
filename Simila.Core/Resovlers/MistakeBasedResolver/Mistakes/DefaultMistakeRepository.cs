using System.Collections.Generic;

namespace Simila.Core
{
    public class DefaultMistakeRepository<TElement> : IMistakeRepository<TElement>
    {
        private List<Mistake<TElement>> _mistakes = new List<Mistake<TElement>>();

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