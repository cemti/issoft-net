using System.Drawing;

namespace SimpleChess.Pieces
{
    class BishopPiece(Color color) : Piece(color)
    {
        public override string Name => "Bishop";
        
        public override bool IsValidOffset(Point p) => p.X == p.Y;
    }
}
