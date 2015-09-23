using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevenshtienAlgorithm
{
    public interface ICostResolver<T>
    {
        double GetInsertOrDeleteCost(T character);
        double GetUpdateCost(T left, T right);
        void SetCost(T left,T right,double cost);
    }
}
