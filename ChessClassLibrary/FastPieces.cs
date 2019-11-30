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
        {}

        protected override bool canKill(Point position)
        {
            if (this.Position == position)
                return false;
            if (board.GetPiece(position).Color == this.Color)
                return false;
            foreach (Point move in KillSet)
            {
                if (move == new Point(0, 0))
                {
                    continue;
                }
                if (isInLine(position, move))
                {
                    for (Point pointToCheck = this.Position + move; board.CoordinateIsInRange(pointToCheck); pointToCheck += move)
                    {
                        if (board.GetPiece(pointToCheck) != null)
                            if (pointToCheck == position)
                                return true;
                            else
                                return false;
                    }
                    break;
                }
            }
            return false;
        }
        protected override bool canMove(Point position)
        {
            foreach (Point move in moveSet)
            {
                if (move == new Point(0, 0))
                {
                    if (this.Position == position)
                        return true;
                    return false;
                }
                if (isInLine(position, move))
                {
                    for (Point pointToCheck = this.Position + move; board.CoordinateIsInRange(pointToCheck); pointToCheck += move)
                    {
                        if (board.GetPiece(pointToCheck) != null)
                            return false;
                        if (pointToCheck == position)
                            return true;
                    }
                    break;
                }
            }
            return false;
        }
        private bool isInLine(Point destination, Point move)
        {
            Point destinationMove = destination - this.position;
            if (Math.Sign(destinationMove.X) != Math.Sign(move.X))
                return false;
            if (Math.Sign(destinationMove.Y) != Math.Sign(move.Y))
                return false;
            if(move == new Point(0,0))
            {
                if (move == destinationMove)
                    return true;
                else return false;
            }

            if(move.X == 0)
            {
                if (destinationMove.X != 0)
                    return false;
                if (destinationMove.Y % move.Y != 0)
                    return false;
            }
            else if(move.Y == 0)
            {
                if (destinationMove.Y != 0)
                    return false;
                if (destinationMove.X % move.X != 0)
                    return false;
            }
            else
            {
                if (destinationMove.X == 0 || destinationMove.Y == 0)
                    return false;
                if (destinationMove.X % move.X != 0 || destinationMove.Y % move.Y != 0)
                    return false;
                if (destinationMove.X / move.X != destinationMove.Y / move.Y)
                    return false;

            }
            return true;
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

    public class Queen : FastPiece
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
