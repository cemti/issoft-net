using System.Drawing;

namespace SimpleChess.Pieces
{
    class PawnPiece(Color color) : Piece(color)
    {
        public override string Name => "Pawn";

        public override bool IsValidOffset(Point p) => p is { X: 1 or -1, Y: 1 };
    }
}
