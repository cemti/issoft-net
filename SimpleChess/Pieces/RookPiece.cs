using System.Drawing;

namespace SimpleChess.Pieces
{
    class RookPiece(Color color) : Piece(color)
    {
        public override string Name => "Rook";

        public override bool IsValidOffset(Point p) => p is { X: 0 } or { Y: 0 };
    }
}
