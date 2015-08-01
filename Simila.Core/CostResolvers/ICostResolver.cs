using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevenshtienAlgorithm
{
    public interface ICostResolver<T>
    {
        Dictionary<T, Dictionary<T, double>> MistakeCosts { get;  }
        double GetInsertOrDeleteCost(T character);
        double GetUpdateCost(T left, T right);
        void SetCost(T inputT,T replacementT,double cost);
        bool IsCaseSensitive { get; set; }
    }
}
