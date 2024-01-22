using System.Drawing;

namespace SimpleChess.Pieces
{
    class QueenPiece(Color color) : Piece(color)
    {
        public override string Name => "Queen";

        public override bool IsValidOffset(Point p) => p is { X: 0 } or { Y: 0 } || p.X == p.Y;
    }
}
