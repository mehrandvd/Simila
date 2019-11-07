using System;
using System.Text;
using Simila.Core.Levenstein;

namespace Simila.Core.Resolvers
{
    public class SoundexSimilarityResolver : ISimilarityResolver<string>, ISimilarityResolver<Word>
    {
        public string ToSoundexString(string text)
        {
            StringBuilder result = new StringBuilder();
            
            if (!string.IsNullOrEmpty(text))
            {
                result.Append(char.ToUpper(text[0]));
                var previousCode = string.Empty;
                for (int i = 1; i < text.Length; i++)
                {
                    var currentCode = ToSoundexChar(text[i]);
                    if (currentCode != previousCode)
                        result.Append(currentCode);

                    if (result.Length == 4) break;
                    if (!currentCode.Equals(string.Empty))
                        previousCode = currentCode;
                }
            }
            if (result.Length < 4)
                result.Append(new string('0', 4 - result.Length));
            return result.ToString();
        }
        private string ToSoundexChar(char c)
        {
            return char.ToLower(c) switch
            {
                'b' => "1",
                'f' => "1",
                'p' => "1",
                'v' => "1",
                'c' => "2",
                'g' => "2",
                'j' => "2",
                'k' => "2",
                'q' => "2",
                's' => "2",
                'x' => "2",
                'z' => "2",
                'd' => "3",
                't' => "3",
                'l' => "4",
                'm' => "5",
                'n' => "5",
                'r' => "6",
                _ => string.Empty
            };
        }
        /// <summary>
        /// Returns a number ranged from 0 to 4.
        /// 0: Not matched, 4: Matched
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>

        public int CalculateSoundexDifference(string left, string right)
        {
            int result = 0;
            if (left.Equals(string.Empty) || right.Equals(string.Empty))
                return 0;

            string soundexLeft = ToSoundexString(left);
            string soundexRight = ToSoundexString(right);

            if (soundexLeft.Equals(soundexRight))
                result = 4;
            else
            {
                if (soundexLeft[0] == soundexRight[0])
                    result = 1;

                string sub1 = soundexLeft.Substring(1, 3); //characters 2, 3, 4
                if (soundexRight.Contains(sub1))
                {
                    result += 3;
                    return result;
                }
                string sub2 = soundexLeft.Substring(2, 2); //characters 3, 4
                if (soundexRight.Contains(sub2))
                {
                    result += 2;
                    return result;
                }
                string sub3 = soundexLeft.Substring(1, 2); //characters 2, 3
                if (soundexRight.Contains(sub3))
                {
                    result += 2;
                    return result;
                }
                
                string sub4 = soundexLeft[1].ToString();
                if (soundexRight.Contains(sub4))
                    result++;
                string sub5 = soundexLeft[2].ToString();
                if (soundexRight.Contains(sub5))
                    result++;
                string sub6 = soundexLeft[3].ToString();
                if (soundexRight.Contains(sub6))
                    result++;
            }
            return result;
        }

        public float GetSimilarity(string left, string right)
        {
            var diff = CalculateSoundexDifference(left, right);
            return (float) diff / 4;
        }

        public float GetSimilarity(Word left, Word right)
        {
            return GetSimilarity((string) left, (string) right);
        }
    }
}
