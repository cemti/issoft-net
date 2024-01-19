using System.Drawing;
using System.Text.RegularExpressions;

namespace Task1
{
    struct Cell
    {
        public int X { get; }
        public int Y { get; }

        public Color Color => ((X ^ Y) & 1) == 0 ? Color.Black : Color.White;

        public Cell(string str)
        {
            var match = Regex.Match(str, "^([a-h])([1-8])$", RegexOptions.IgnoreCase);
            var x = match.Groups[1];
            var y = match.Groups[2];

            if (!x.Success || !y.Success)
                throw new ArgumentOutOfRangeException(str);

            X = char.ToLower(x.Value[0]) - 'a';
            Y = y.Value[0] - '1';
        }

        public override string ToString() => $"{(char)(X + 'a')}{Y + 1}";
    }

    static class Program
    {
        static void Main(string[] args)
        {
            var query = from arg in args select new Cell(arg);

            foreach (var cell in query)
                Console.WriteLine($"{cell} -> {cell.Color.Name}");
        }
    }
}