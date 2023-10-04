using System.Collections.Generic;

namespace Simila.Core.Resolver.GeneralResolver
{
    public interface IMistakeRepository<T>
    {
        List<Mistake<T>> GetMistakes();
    }
}