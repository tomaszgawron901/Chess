using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    public interface IKing
    {
        bool IsChecked();
    }

    public abstract class King: SlowPiece, IKing
    {
        public King(string color,Point position, ChessBoard board) :
            base(color, "King", position, board)
        {
            this.moveSet = new Point[] {
                new Point(-1, 1), new Point(0, 1), new Point(1, 1),
                new Point(-1, 0), new Point(1, 0),
                new Point(-1, -1), new Point(0, -1), new Point(1, -1),
            };
            this.killSet = this.moveSet;
        }

        public override bool canMoveTo(Point position)
        {
            return base.canMoveTo(position);
        }

        public bool IsChecked()
        {
            foreach (var row in board.Board)
            {
                foreach (var piece in row)
                {
                    if (piece != null)
                        if (piece.Color != Color && piece.CanAchieve(Position, piece.KillSet))
                            return true;
                }
            }
            return false;
        }
        //protected abstract bool canCastle(Point position);
        //protected abstract void Castle(Point position);
    }


    public class WhiteKing:King
    {
        public WhiteKing(Point position, ChessBoard board):
            base("White", position, board)
        {
            this.board.WhiteKing = this;
        }
    }

    public class BlackKing : King
    {
        public BlackKing(Point position, ChessBoard board) :
            base("Black", position, board)
        {
            this.board.BlackKing = this;
        }
    }

}
