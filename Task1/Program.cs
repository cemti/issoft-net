using System.Drawing;
namespace Task1;

static class Program
{
    static string GetColor(string arg) =>
        arg is [_, >= '1' and <= '8'] && char.ToLower(arg[0]) is >= 'a' and <= 'h' ?
            (((arg[0] ^ arg[1]) & 1) == 0 ? Color.Black : Color.White).Name :
            throw new ArgumentOutOfRangeException(arg);

    static void Main(string[] args)
    {
        foreach (var color in args.Select(GetColor))
            Console.WriteLine(color);
    }
}