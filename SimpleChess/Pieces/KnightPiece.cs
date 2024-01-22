using System.Drawing;

namespace SimpleChess.Pieces
{
    class KnightPiece(Color color) : Piece(color)
    {
        public override string Name => "Knight";

        public override bool IsValidOffset(Point p) => p is { X: 1 or -1, Y: 2 or -2 } or { X: 2 or -2, Y: 1 or -1 };
    }
}
