using System.Collections.Generic;

namespace Simila.Core.SimilarityResolvers
{
    public interface IMistakeRepository<T>
    {
        List<Mistake<T>> GetMistakes();
    }
}