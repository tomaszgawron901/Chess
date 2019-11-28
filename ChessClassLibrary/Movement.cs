using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    public abstract class Movement
    {
        protected Point from;
        protected Point to;
        protected ChessBoard board;
        protected Piece piece;
        protected Point? movableBy;
        protected Point? killableBy;

        /// <summary>
        /// Checks whether destination field can be achieved by any of 'kill' moves.
        /// </summary>
        public bool Killable
        {
            get { return killableBy != null; }
        }

        /// <summary>
        /// Checks whether destination field can be achieved by any of 'move' moves.
        /// </summary>
        public bool Movable
        {
            get { return movableBy != null; }
        }
        public Movement(Point from, Point to, ChessBoard board)
        {
            if (!board.CoordinateIsInRange(from) || !board.CoordinateIsInRange(to))
                throw new ArgumentOutOfRangeException();
            if (board.GetPiece(from) == null)
                throw new ArgumentException("'From' field is empty.");
            this.from = from;
            this.to = to;
            this.board = board;
            this.piece = board.GetPiece(from);
        }

        /// <summary>
        /// Checks whether Movement can by executed by a 'move' move.
        /// </summary>
        /// <returns>True when whether Movement can by executed by a 'move' move, otherwise false.</returns>
        public abstract bool CanMove();
        /// <summary>
        /// Checks whether Movement can by executed by a 'kill' move.
        /// </summary>
        /// <returns>True when whether Movement can by executed by a 'kill' move, otherwise false.</returns>
        public abstract bool CanKill();
        /// <summary>
        /// Makes this move comes true.
        /// </summary>
        public abstract void Execute();
    }

    public class SlowMovement: Movement
    {
        public SlowMovement(Point from, Point to, ChessBoard board) : base(from,to,board)
        {
            this.movableBy = isMovableBy();
            this.killableBy = isKillableBy();
        }

        private Point? isMovableBy()
        {
            foreach(Point move in this.piece.MoveSet)
            {
                if (this.from + move == this.to)
                    return move;
            }
            return null;
        }

        private Point? isKillableBy()
        {
            foreach (Point move in this.piece.KillSet)
            {
                if (this.from + move == this.to)
                    return move;
            }
            return null;
        }

        /// <summary>
        /// Checks whether Movement can by executed by a 'move' move.
        /// </summary>
        /// <returns>True when whether Movement can by executed by a 'move' move, otherwise false.</returns>
        public override bool CanMove()
        {
            if (!Movable)
                return false;
            if (this.board.GetPiece(to) != null)
                return false;
            return true;
        }

        /// <summary>
        /// Checks whether Movement can by executed by a 'kill' move.
        /// </summary>
        /// <returns>True when whether Movement can by executed by a 'kill' move, otherwise false.</returns>
        public override bool CanKill()
        {
            if (!Killable)
                return false;
            if (this.board.GetPiece(to) == null)
                return false;
            if (this.piece.Color == this.board.GetPiece(to).Color)
                return false;
            return true;
        }

        /// <summary>
        /// Makes this move comes true.
        /// </summary>
        public override void Execute()
        {
            if(CanKill() || CanMove())
            {
                this.board.SetPiece(this.piece, to);
                this.board.SetPiece(null, this.from);
            }
        }
    }
}
