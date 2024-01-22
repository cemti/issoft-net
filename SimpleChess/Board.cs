using System.Drawing;

namespace SimpleChess
{
    using Pieces;
    
    class Board
    {
        public const int BOARD_SIZE = 8;
        readonly Dictionary<Point, Piece> _pieces = [];

        public IReadOnlyDictionary<Point, Piece> Pieces => _pieces.AsReadOnly();

        public Board()
        {
            Populate(BOARD_SIZE - 1, BOARD_SIZE - 2, Color.Black);
            Populate(0, 1, Color.White);

            void Populate(int row1, int row2, Color color)
            {
                RookPiece rook = new(color);
                KnightPiece knight = new(color);
                BishopPiece bishop = new(color);
                KingPiece king = new(color);
                QueenPiece queen = new(color);
                PawnPiece pawn = new(color);
                
                _pieces.Add(new(0, row1), rook);
                _pieces.Add(new(1, row1), knight);
                _pieces.Add(new(2, row1), bishop);
                _pieces.Add(new(3, row1), king);
                _pieces.Add(new(4, row1), queen);
                _pieces.Add(new(5, row1), bishop);
                _pieces.Add(new(6, row1), knight);
                _pieces.Add(new(7, row1), rook);

                for (int i = 0; i < BOARD_SIZE; ++i)
                    _pieces.Add(new(i, row2), pawn);
            }
        }

        public static bool InBounds(Point p) => p is { X: >= 0 and < BOARD_SIZE, Y: >= 0 and < BOARD_SIZE };

        public static Color CellColor(Point p) => ((p.X ^ p.Y) & 1) == 0 ? Color.Black : Color.White;

        public Piece? GetPiece(Point p) => _pieces.TryGetValue(p, out var piece) ? piece : null;

        public bool MovePiece(Point from, Point to)
        {
            if (InBounds(from) && InBounds(to)
                && GetPiece(from) is Piece piece
                && piece.IsValidOffset(to - new Size(from))
                && !_pieces.ContainsKey(to))
            {
                _pieces.Remove(from);
                _pieces.Add(to, piece);
                return true;
            }

            return false;
        }
    }
}
