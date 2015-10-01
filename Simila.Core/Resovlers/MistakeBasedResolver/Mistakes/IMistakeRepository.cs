using System.Collections.Generic;

namespace Simila.Core
{
    public interface IMistakeRepository<T>
    {
        List<Mistake<T>> GetMistakes();
    }
}