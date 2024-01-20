using System.Drawing;

namespace Task1
{
    static class Program
    {
        static IEnumerable<string> GetColors(string[] args) =>
            from color in
                from arg in args
                select arg is [(>= 'a' and <= 'h') or (>= 'A' and <= 'H'), >= '1' and <= '8'] ?
                    ((arg[0] ^ arg[1]) & 1) == 0 ? Color.Black : Color.White :
                    throw new ArgumentOutOfRangeException(arg)
            select color.Name;

        static void Main(string[] args)
        {
            foreach (var color in GetColors(args))
                Console.WriteLine(color);
        }
    }
}