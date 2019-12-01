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
        {}

        public override bool canKill(Point position)
        {
            foreach(Point move in killSet)
            {
                Point fieldToCheck = this.position + move;
                if (!board.CoordinateIsInRange(fieldToCheck))
                    continue;
                if (position != fieldToCheck)
                    continue;
                return true;
            }
            return false;
        }
        protected override bool canMove(Point position)
        {
            foreach (Point move in moveSet)
            {
                Point fieldToCheck = this.position + move;
                if (!board.CoordinateIsInRange(fieldToCheck))
                    continue;
                if (position != fieldToCheck)
                    continue;
                if (board.GetPiece(fieldToCheck) != null)
                    continue;
                return true;
            }
            return false;
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
        /// Moves Piece to given position.
        /// </summary>
        /// <param name="position">Movement destination.</param>
        public override void moveTo(Point position)
        {
            base.moveTo(position);
            if(this.Position.Y == board.Height-1)
            {
                transformToQueen();
            }
        }

        private void transformToQueen()
        {
            new Queen("White", Position, board);
        }

        /// <summary>
        /// Performs the appropriate actions when the piece is moving for the first time.
        /// </summary>
        protected override void firstMove()
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
        /// Moves Piece to given position.
        /// </summary>
        /// <param name="position">Movement destination.</param>
        public override void moveTo(Point position)
        {
            base.moveTo(position);
            if (this.Position.Y == 0)
            {
                transformToQueen();
            }
        }

        private void transformToQueen()
        {
            new Queen("Black", Position, board);
        }

        /// <summary>
        /// Performs the appropriate actions when the piece is moving for the first time.
        /// </summary>
        protected override void firstMove()
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

