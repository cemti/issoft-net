using System.Drawing;

namespace SimpleChess.Pieces
{
    class KingPiece(Color Color) : Piece(Color)
    {
        public override string Name => "King";

        public override bool IsValidOffset(Point p) => p is { X: >= -1 and <= 1, Y: >= -1 and <= 1 };
    }
}
