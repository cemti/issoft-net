namespace Task2
{
    internal class Program
    {
        static IEnumerable<string> FindSubsequences(string input) =>
            from i in Enumerable.Range(0, input.Length - 1)
            from j in Enumerable.Range(i + 1, input.Length - i - 1).TakeWhile(x => input[x] != input[x - 1])
            select input[i..(j + 1)];

        static void Main(string[] args)
        {
            foreach (var x in args)
            {
                foreach (var result in FindSubsequences(x))
                    Console.Write($"{result} ");

                Console.WriteLine();
            }
        }
    }
}
