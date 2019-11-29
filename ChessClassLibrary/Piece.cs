using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    interface IPiece
    {
        void firstMove();
        bool canMoveTo(Point positon);
        void moveTo(Point position);
    }

    public abstract class Piece : IPiece
    {
        protected string color;
        protected bool wasMoved;
        protected bool isFast;
        protected string name;

        protected ChessBoard board;
        protected Point position;

        protected Point[] moveSet;
        protected Point[] killSet;
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
            this.position = position;
            this.board = board;
        }

        /// <summary>
        /// Performs the appropriate actions when the piece is moving for the first time.
        /// </summary>
        public virtual void firstMove()
        {
            wasMoved = true;
        }
        public abstract bool canMoveTo(Point position);
        public abstract void moveTo(Point position);
    }
}
