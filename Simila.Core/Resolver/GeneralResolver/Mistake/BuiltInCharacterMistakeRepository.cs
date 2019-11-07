using System.Collections.Generic;

namespace Simila.Core.Resolver.GeneralResolver
{
    public class BuiltInCharacterMistakeRepository : IMistakeRepository<char>
    {
        public List<Mistake<char>> GetMistakes()
        {
            return new List<Mistake<char>>()
            {
                new Mistake<char>('c', 'k', .50f),
                new Mistake<char>('o', 'u', .50f),
                new Mistake<char>('l', 'i', .50f),
                new Mistake<char>('i', 'y', .70f),
                new Mistake<char>('v', 'w', .50f),
                new Mistake<char>('z', 's', .40f),
                new Mistake<char>('s', 'c', .50f),
                new Mistake<char>('c', 'k', .50f),
                new Mistake<char>('n', 'm', .50f),

                
                new Mistake<char>('a', 'e', .30f),

            };
        }
    }
}