using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simila.Studio
{
    public class TextInstance
    {
        public TextInstance(string text)
        {
            Text = text;
        }
        public string Text { get; set; }
        public string ClearedText { get; set; } = "";
        public long RowNo { get; set; }

        public override string? ToString()
        {
            return ClearedText;
        }
    }

    public class SimilarInstance
    {
        public TextInstance? Similar { get; set; }

        public string? SimilarText => Similar?.Text;
        public string? SimilarCleared => Similar?.ClearedText;

        public float? SimilarityRate { get; set; }
    }

    public class SimilarityResult : SimilarInstance
    {
        public SimilarityResult(TextInstance original)
        {
            Original = original;
        }
        public TextInstance Original { get; set; }

        public string OriginalText => Original.Text;
        public string OriginalCleared => Original.ClearedText;


        public List<SimilarInstance> OtherSimilars { get; set; } = new List<SimilarInstance>();
    }
}
