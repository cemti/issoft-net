using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SimpleChess
{
    class Game
    {
        readonly Player _player1, _player2;
        bool _parity;
        
        public Board Board { get; } = new();

        public Player CurrentPlayer => _parity ? _player2 : _player1;

        public delegate bool Movement(Point from, Point to, Player player);

        public Game()
        {
            _player1 = new(MovePiece, Color.White);
            _player2 = new(MovePiece, Color.Black);

            bool MovePiece(Point from, Point to, Player player)
            {
                if (CurrentPlayer.Equals(player) && Board.MovePiece(from, to))
                {
                    _parity ^= true;
                    return true;
                }

                return false;
            }
        }
    }
}
