using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simila.Studio
{
    public class MistakeInstance
    {
        public MistakeInstance(string left, string right, float similarity)
        {
            Left = left;
            Right = right;
            Similarity = similarity;
        }
        public string Left { get; set; }

        public string Right { get; set; }

        public float Similarity { get; set; }
    }
}
