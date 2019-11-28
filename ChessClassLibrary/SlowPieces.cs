using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{

    public class WhitePawn : Piece
    {
        public WhitePawn()
        {
            this.color = "White";
            this.wasMoved = false;
            this.isFast = false;
            this.name = "Pawn";
            this.moveSet = new Point[] { new Point(0,1), new Point(0, 2)};
            this.killSet = new Point[] { new Point(-1, 1), new Point(1, 1)};
        }

        /// <summary>
        /// Performs the appropriate actions when the piece is moving for the first time.
        /// </summary>
        public override void firstMove()
        {
            this.wasMoved = true;
            this.moveSet = new Point[] { new Point(0, 1)};
        }
    }

    public class BlackPawn: Piece
    {
        public BlackPawn()
        {
            this.color = "Black";
            this.wasMoved = false;
            this.isFast = false;
            this.name = "Pawn";
            this.moveSet = new Point[] { new Point(0, -1), new Point(0, -2) };
            this.killSet = new Point[] { new Point(-1, -1), new Point(1, -1) };
        }

        /// <summary>
        /// Performs the appropriate actions when the piece is moving for the first time.
        /// </summary>
        public override void firstMove()
        {
            this.wasMoved = true;
            this.moveSet = new Point[] { new Point(0, -1) };
        }
    }


    public class Knight : Piece
    {
        public Knight(string color)
        {
            this.color = color;
            this.wasMoved = false;
            this.isFast = false;
            this.name = "Knight";
            this.moveSet = new Point[] { 
                new Point(-1, 2), new Point(1, 2),
                new Point(-1, -2), new Point(1, -2),
                new Point(-2, -1), new Point(-2, 1),
                new Point(2, -1), new Point(2, 1),
            };
            this.killSet = this.moveSet;

        }
    }

    public class King : Piece
    {
        public King(string color)
        {
            this.color = color;
            this.wasMoved = false;
            this.isFast = false;
            this.name = "King";
            this.moveSet = new Point[] {
                new Point(-1, 1), new Point(0, 1), new Point(1, 1),
                new Point(-1, 0), new Point(1, 0),
                new Point(-1, -1), new Point(0, -1), new Point(1, -1),
            };
            this.killSet = this.moveSet;
        }
    }

}

