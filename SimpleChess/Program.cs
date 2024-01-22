using System.Drawing;

namespace SimpleChess
{
    static class Program
    {
        static void Print(this Board board)
        {
            var m = new string[Board.BOARD_SIZE, Board.BOARD_SIZE];
            var backgroundColor = Console.BackgroundColor;
            var foregroundColor = Console.ForegroundColor;
            
            foreach (var (key, value) in board.Pieces)
                m[Board.BOARD_SIZE - key.Y - 1, key.X] = value.ToString();

            for (var i = 0; i < Board.BOARD_SIZE; ++i)
            {
                for (var j = 0; j < Board.BOARD_SIZE; ++j)
                {
                    Console.Write('|');

                    Console.BackgroundColor = ((i ^ j) & 1) == 0 ? ConsoleColor.White : ConsoleColor.Black;
                    Console.ForegroundColor = ((i ^ j) & 1) == 0 ? ConsoleColor.Black : ConsoleColor.White;

                    Console.Write($"{m[i, j],-12}");

                    Console.BackgroundColor = backgroundColor;
                    Console.ForegroundColor = foregroundColor;

                    Console.Write('|');
                }

                Console.WriteLine();
            }

            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
        }

        static Point NotationToPoint(string? input) => input is [(>= 'a' and <= 'h') or (>= 'A' and <= 'H'), >= '1' and <= '8'] ?
            new(char.ToLower(input[0]) - 'a', input[1] - '1') :
            throw new ArgumentOutOfRangeException(input);
        
        static void Main()
        {
            Game game = new();

            for (; ; )
            {
                game.Board.Print();

                Console.WriteLine($"{game.CurrentPlayer.Color}'s turn");

                Console.Write("From: ");
                var from = NotationToPoint(Console.ReadLine());

                Console.Write("To: ");
                var to = NotationToPoint(Console.ReadLine());

                game.CurrentPlayer.MovePiece(from, to);
            }
        }
    }
}
