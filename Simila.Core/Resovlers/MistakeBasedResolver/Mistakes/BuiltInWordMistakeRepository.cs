using System;
using System.Collections.Generic;
using Simila.Core.Levenstein;

namespace Simila.Core
{
    public class BuiltInWordMistakeRepository : IMistakeRepository<Word>
    {
        public List<Mistake<Word>> GetMistakes()
        {
            return new List<Mistake<Word>>()
            {
                new Mistake<Word>("color", "colour", 0.90f),
            };
        }
    }
}
