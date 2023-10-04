using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simila.Studio
{
    public static class TextUtil
    {
        public static string ReplaceYK(this string text)
        {
            return text
                .Replace('ي', 'ی')
                .Replace('ك', 'ک');
        }
    }
}
