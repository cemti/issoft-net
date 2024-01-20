using System.Drawing;

namespace Task1
{
    static class Program
    {
        static void Main(string[] args)
        {
            var query =
                from color in
                    from arg in args
                    select arg is [(>= 'a' and <= 'h') or (>= 'A' and <= 'H'), >= '1' and <= '8'] ?
                        ((arg[0] ^ arg[1]) & 1) == 0 ? Color.Black : Color.White :
                        throw new ArgumentOutOfRangeException(arg)
                select color.Name;

            foreach (var color in query)
                Console.WriteLine(color);
        }
    }
}