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
    }

    public abstract class Piece : IPiece
    {
        protected string color;
        protected bool isMoved;
        protected bool isFast;
        protected Point[] moveSet;
        protected Point[] killSet;
        public bool IsMoved
        {
            get { return this.isMoved; }
        }
        public virtual void firstMove() { }
    }
}
