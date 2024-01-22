using System.Drawing;

namespace SimpleChess
{
    class Player(Game.Movement mov, Color color)
    {
        public Color Color => color;

        public bool MovePiece(Point from, Point to) => mov(from, to, this);
    }
}
