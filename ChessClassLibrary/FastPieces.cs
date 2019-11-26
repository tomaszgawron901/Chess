using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    public class Bishop : Piece
    {
        public Bishop(string color)
        {
            this.color = color;
            this.isMoved = false;
            this.isFast = true;
            this.moveSet = new Point[] {
                new Point(-1, 1),
                new Point(1, 1),
                new Point(1, -1),
                new Point(-1, -1)
            };
            this.killSet = this.moveSet;
        }

        public override void firstMove()
        {
            this.isMoved = true;
        }
    }

    class Queen : Piece
    {
        public Queen(string color)
        {
            this.color = color;
            this.isMoved = false;
            this.isFast = true;
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

        public override void firstMove()
        {
            this.isMoved = true;
        }
    }

    public class Rook : Piece
    {
        public Rook(string color)
        {
            this.color = color;
            this.isMoved = false;
            this.isFast = true;
            this.moveSet = new Point[] {
                new Point(0, 1),
                new Point(1, 0),
                new Point(0, -1),
                new Point(-1, 0)
            };
            this.killSet = this.moveSet;
        }

        public override void firstMove()
        {
            this.isMoved = true;
        }
    }
}
