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
        protected bool isFast;
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
            this.Position = position;
            this.board = board;
        }

        /// <summary>
        /// Performs the appropriate actions when the piece is moving for the first time.
        /// </summary>
        protected virtual void firstMove()
        {
            wasMoved = true;
        }
        public abstract bool canMoveTo(Point position);
        public abstract void moveTo(Point position);

        protected void kill(Point position)
        {
            if (!canKill(position))
                throw new ArgumentException("Cannot kill Piece at given position.");
            board.SetPiece(this, position);
            board.SetPiece(null, this.Position);
            this.Position = position;

        }
        protected void move(Point position)
        {
            if (!canMove(position))
                throw new ArgumentException("Cannot move to given position.");
            board.SetPiece(this, position);
            board.SetPiece(null, this.Position);
            this.Position = position;
        }

        protected abstract bool canKill(Point position);
        protected abstract bool canMove(Point position);
    }
}
