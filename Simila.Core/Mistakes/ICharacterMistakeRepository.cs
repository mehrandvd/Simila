using System.Collections.Generic;

namespace Simila.Core.Levenstein.Mistakes
{
    public interface IMistakeRepository<T>
    {
        List<Mistake<T>> GetMistakes();
    }
}