using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    interface IPiece
    {
        bool canMoveTo(Point positon);
        void moveTo(Point position);
    }

    public abstract class Piece : IPiece
    {
        protected string color;
        protected bool wasMoved;
        protected string name;

        /// <summary>
        /// Checks whether piece was moved.
        /// </summary>
        public bool WasMoved
        {
            get { return this.wasMoved; }
        }

        /// <summary>
        /// Returns piece color.
        /// </summary>
        public string Color
        {
            get { return color; }
        }

        /// <summary>
        /// Returns piece Name.
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        protected ChessBoard board;
        protected Point position;

        /// <summary>
        /// The Position of Piece.
        /// </summary>
        public Point Position
        {
            get { return position; }
            protected set {
                if (!board.CoordinateIsInRange(value))
                    throw new ArgumentException("Cannot set given position.");
                position = value;
            }
        }

        protected Point[] moveSet;
        protected Point[] killSet;


        /// <summary>
        /// Returns piece move set.
        /// </summary>
        public Point[] MoveSet
        {
            get { return moveSet; }
        }

        /// <summary>
        /// Returns piece kill set.
        /// </summary>
        public Point[] KillSet
        {
            get { return killSet; }
        }

        protected Piece(string color, string name, Point position, ChessBoard board)
        {
            this.color = color;
            this.name = name;
            this.wasMoved = false;
            this.board = board;
            this.Position = position;
            this.board.SetPiece(this, this.Position);
        }

        /// <summary>
        /// Performs the appropriate actions when the piece is moving for the first time.
        /// </summary>
        protected virtual void firstMove()
        {
            wasMoved = true;
        }
        /// <summary>
        /// Checks whether Piece can be moved to given position.
        /// </summary>
        /// <param name="position">Movement destination.</param>
        /// <returns></returns>
        public virtual bool canMoveTo(Point position)
        {
            if (Color == "White" && board.WhiteKing.IsChecked())
                return false;
            if (color == "Black" && board.BlackKing.IsChecked())
                return false;
            if (!this.board.CoordinateIsInRange(position))
                return false;
            if (pretendMoveAndCheckIfKingIsChecked(position))
                return false;
            if (canMove(position))
                return true;
            if(canKill(position) && board.GetPiece(position) != null)
            {
                if(board.GetPiece(position).Color != this.Color)
                    return true;
            }
            return false;
        }

        private bool pretendMoveAndCheckIfKingIsChecked(Point position)
        {
            Piece pieceAtDestinationPosition = board.GetPiece(position);
            board.SetPiece(null, Position);
            board.SetPiece(new Dummy(Color, position, board), position);
            bool KingIsChecked;
            if (color == "White")
                KingIsChecked = board.WhiteKing.IsChecked();
            else
                KingIsChecked = board.BlackKing.IsChecked();
            board.SetPiece(pieceAtDestinationPosition, position);
            board.SetPiece(this, this.Position);
            return KingIsChecked;
        }

        /// <summary>
        /// Moves Piece to given position.
        /// </summary>
        /// <param name="position">Movement destination.</param>
        public virtual void moveTo(Point position)
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
            if (!wasMoved)
            {
                firstMove();
            }
        }

        protected void kill(Point position)
        {
            if (!canKill(position))
                throw new ArgumentException("Cannot kill Piece at given position.");
            Point currentPosition = Position;
            Position = position;
            board.SetPiece(this, position);
            board.SetPiece(null, currentPosition);
        }
        protected void move(Point position)
        {
            if (!canMove(position))
                throw new ArgumentException("Cannot move to given position.");
            Point currentPosition = Position;
            Position = position;
            board.SetPiece(this, position);
            board.SetPiece(null, currentPosition);
        }

        public abstract bool canKill(Point position);
        protected abstract bool canMove(Point position);
    }

    public class Dummy : Piece
    {
        public Dummy(string color, Point position, ChessBoard board) : base(color, "", position, board)
        {
            moveSet = new Point[] { };
            killSet = new Point[] { };
        }

        protected override bool canMove(Point position)
        {
            return false;
        }

        public override bool canKill(Point position)
        {
            return false;
        }
    }
}
