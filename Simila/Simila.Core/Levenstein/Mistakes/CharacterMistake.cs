namespace Simila.Core.Levenstein.Mistakes
{
    public class CharacterMistake
    {
        public CharacterMistake(char left, char right, double cost)
        {
            Left = left;
            Right = right;
            Cost = cost;
        }

        public CharacterMistake(string left, string right, double cost)
        {
            Left = left[0];
            Right = right[0];
            Cost = cost;
        }

        public char Left { get; set; }
        public char Right { get; set; }
        public double Cost { get; set; }
    }
}
