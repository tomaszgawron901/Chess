using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    public abstract class FastPiece : Piece
    {
        protected FastPiece(string color, string name, Point position, ChessBoard board) :
            base(color, name, position, board)
        {
            this.isFast = true;
        }

        public override bool canMoveTo(Point position)
        {
            throw new NotImplementedException();
        }

        public override void moveTo(Point position)
        {
            throw new NotImplementedException();
        }
    }


    public class Bishop : FastPiece
    {
        public Bishop(string color, Point position, ChessBoard board):
            base(color, "Bishop", position, board)
        {
            this.moveSet = new Point[] {
                new Point(-1, 1),
                new Point(1, 1),
                new Point(1, -1),
                new Point(-1, -1)
            };
            this.killSet = this.moveSet;
        }
    }

    class Queen : FastPiece
    {
        public Queen(string color, Point position, ChessBoard board) :
            base(color, "Queen", position, board)
        {
            this.moveSet = new Point[] {
                new Point(-1, 1),
                new Point(1, 1),
                new Point(1, -1),
                new Point(-1, -1),

                new Point(0, 1),
                new Point(1, 0),
                new Point(0, -1),
                new Point(-1, 0)
            };
            this.killSet = this.moveSet;
        }
    }

    public class Rook : FastPiece
    {
        public Rook(string color, Point position, ChessBoard board) :
            base(color, "Rook", position, board)
        {
            this.moveSet = new Point[] {
                new Point(0, 1),
                new Point(1, 0),
                new Point(0, -1),
                new Point(-1, 0)
            };
            this.killSet = this.moveSet;
        }
    }
}
