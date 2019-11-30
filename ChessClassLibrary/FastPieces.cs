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

        /// <summary>
        /// Checks whether Piece can be moved to given position.
        /// </summary>
        /// <param name="position">Movement destination.</param>
        /// <returns></returns>
        public override bool canMoveTo(Point position)
        {
            if (!this.board.CoordinateIsInRange(position))
                return false;
            if (canKill(position) || canMove(position))
                return true;
            return false;
        }

        /// <summary>
        /// Moves Piece to given position.
        /// </summary>
        /// <param name="position">Movement destination.</param>
        public override void moveTo(Point position)
        {
            if (!canMoveTo(position))
                throw new ArgumentException("Cannot move to given position.");
            if (canKill(position))
            {
                kill(position);
            }
            else
            {
                move(position);
            }
        }

        protected override bool canKill(Point position)
        {
            //foreach (Point move in killSet)
            //{
            //    Point fieldToCheck = this.position + move;
            //    if (board.CoordinateIsInRange(fieldToCheck))
            //        continue;
            //    if (position != fieldToCheck)
            //        continue;
            //    if (board.GetPiece(fieldToCheck) == null)
            //        continue;
            //    if (board.GetPiece(fieldToCheck).Color == color)
            //        continue;
            //    return true;
            //}
            //return false;
            throw new NotImplementedException();
        }
        protected override bool canMove(Point position)
        {
            //foreach (Point move in moveSet)
            //{
            //    Point fieldToCheck = this.position + move;
            //    if (board.CoordinateIsInRange(fieldToCheck))
            //        continue;
            //    if (position != fieldToCheck)
            //        continue;
            //    if (board.GetPiece(fieldToCheck) != null)
            //        continue;
            //    return true;
            //}
            //return false;
            throw new NotImplementedException();
        }

        private bool isInLine(Point destination, Point move)
        {
            //Point destinationMove = destination - this.position;
            //if (Math.Sign(destinationMove.X) != Math.Sign(move.X))
            //    return false;
            //if (Math.Sign(destinationMove.Y) != Math.Sign(move.Y))
            //    return false;
            //int capacityX;
            //int capatityY;
            //if(move.X == 0)
            //{
            //    if (destinationMove.X == 0)
            //    {
            //        capacityX = -1;
            //    }
            //    else return false;
            //}
            //else
            //{
            //    capacityX = destinationMove.X / move.X;
            //}

            //if (move.Y == 0)
            //{
            //    if (destinationMove.Y == 0)
            //    {
            //        capatityY = -1;
            //    }
            //    else return false;
            //}
            //else
            //{
            //    capatityY = destinationMove.Y / move.Y;
            //}

            //return true;
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
