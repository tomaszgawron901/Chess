using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    public abstract class King: SlowPiece
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
    }

}
