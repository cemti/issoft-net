namespace Task2
{
    internal class Program
    {
        static IEnumerable<string> FindSubsequences(string input)
        {
            for (int i = 0; i < input.Length; ++i)
                for (int j = i + 1; j < input.Length && input[j] != input[j - 1]; ++j)
                    yield return input[i..(j + 1)];
        }

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
