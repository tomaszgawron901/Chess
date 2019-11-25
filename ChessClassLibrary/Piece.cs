using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    interface IPiece
    {
        void moveTo(Point position);
        void firstMoveTo(Point position);
    }

    public abstract class Piece : IPiece
    {
        protected string color;
        protected bool isMoved;
        protected bool isFast;
        protected Point position;
        protected Point[] moveSet;
        protected Point[] killSet;
        public bool IsMoved
        {
            get { return this.isMoved; }
        }
        public virtual void moveTo(Point position) { }
        public virtual void firstMoveTo(Point position) { }
    }
}
