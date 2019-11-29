using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    public abstract class SlowPiece : Piece
    {
        protected SlowPiece(string color, string name, Point position, ChessBoard board) :
            base(color, name, position, board)
        {
            this.isFast = false;
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
    public class WhitePawn : SlowPiece
    {
        public WhitePawn(Point position, ChessBoard board) :
            base("White", "Pawn", position, board)
        {
            this.moveSet = new Point[] { new Point(0, 1), new Point(0, 2) };
            this.killSet = new Point[] { new Point(-1, 1), new Point(1, 1) };
        }


        /// <summary>
        /// Performs the appropriate actions when the piece is moving for the first time.
        /// </summary>
        public override void firstMove()
        {
            this.wasMoved = true;
            this.moveSet = new Point[] { new Point(0, 1)};
        }
    }

    public class BlackPawn: SlowPiece
    {
        public BlackPawn(Point position, ChessBoard board) :
            base("Black", "Pawn", position, board)
        {
            this.moveSet = new Point[] { new Point(0, -1), new Point(0, -2) };
            this.killSet = new Point[] { new Point(-1, -1), new Point(1, -1) };
        }


        /// <summary>
        /// Performs the appropriate actions when the piece is moving for the first time.
        /// </summary>
        public override void firstMove()
        {
            this.wasMoved = true;
            this.moveSet = new Point[] { new Point(0, -1) };
        }
    }

    public class Knight : SlowPiece
    {
        public Knight(string color, Point position, ChessBoard board) :
            base(color, "Knight", position, board)
        {
            this.moveSet = new Point[] {
                    new Point(-1, 2), new Point(1, 2),
                    new Point(-1, -2), new Point(1, -2),
                    new Point(-2, -1), new Point(-2, 1),
                    new Point(2, -1), new Point(2, 1),
                };
            this.killSet = this.moveSet;
        }

    }

}

