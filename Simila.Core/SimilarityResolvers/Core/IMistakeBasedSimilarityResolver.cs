using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevenshtienAlgorithm
{
    public interface IMistakeBasedSimilarityResolver<T> : ISimilarityResolver<T>
    {
        void SetMistakeSimilarity(T left,T right, float similarity);
    }
}
