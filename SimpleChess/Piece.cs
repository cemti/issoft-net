using System.Drawing;

namespace SimpleChess
{
    abstract class Piece(Color color)
    {
        public Color Color => color;
        public abstract string Name { get; }

        public abstract bool IsValidOffset(Point p);
        public override string ToString() => $"{Color.Name} {Name}";
    }
}
