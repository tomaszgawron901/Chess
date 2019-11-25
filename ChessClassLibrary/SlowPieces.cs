using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{

    public class WhitePawn : Piece
    {
        public WhitePawn(Point position)
        {
            this.color = "White";
            this.isMoved = false;
            this.isFast = false;
            this.position = position;
            this.moveSet = new Point[] { new Point(0,1), new Point(0, 2)};
            this.killSet = new Point[] { new Point(-1, 1), new Point(1, 1)};
        }

        public override void moveTo(Point position)
        {
            this.position = position;
        }
        public override void firstMoveTo(Point position)
        {
            this.isMoved = true;
            this.moveSet = new Point[] { new Point(0, 1)};
            this.moveTo(position);
        }
    }

    public class BlackPawn: Piece
    {
        public BlackPawn(Point position)
        {
            this.color = "Black";
            this.isMoved = false;
            this.isFast = false;
            this.position = position;
            this.moveSet = new Point[] { new Point(0, -1), new Point(0, -2) };
            this.killSet = new Point[] { new Point(-1, -1), new Point(1, -1) };
        }

        public override void moveTo(Point position)
        {
            this.position = position;
        }
        public override void firstMoveTo(Point position)
        {
            this.isMoved = true;
            this.moveSet = new Point[] { new Point(0, -1) };
            this.moveTo(position);
        }
    }


    public class Knight : Piece
    {
        public Knight(string color, Point position)
        {
            this.color = color;
            this.isMoved = false;
            this.isFast = false;
            this.position = position;
            this.moveSet = new Point[] { 
                new Point(-1, 2), new Point(1, 2),
                new Point(-1, -2), new Point(1, -2),
                new Point(-2, -1), new Point(-2, 1),
                new Point(2, -1), new Point(2, 1),
            };
            this.killSet = this.moveSet;

        }

        public override void moveTo(Point position)
        {
            this.position = position;
        }
        public override void firstMoveTo(Point position)
        {
            this.isMoved = true;
            this.moveTo(position);
        }
    }

    public class King : Piece
    {
        public King(string color, Point position)
        {
            this.color = color;
            this.isMoved = false;
            this.isFast = false;
            this.position = position;
            this.moveSet = new Point[] {
                new Point(-1, 1), new Point(0, 1), new Point(1, 1),
                new Point(-1, 0), new Point(1, 0),
                new Point(-1, -1), new Point(0, -1), new Point(1, -1),
            };
            this.killSet = this.moveSet;

        }

        public override void moveTo(Point position)
        {
            this.position = position;
        }
        public override void firstMoveTo(Point position)
        {
            this.isMoved = true;
            this.moveTo(position);
        }
    }

}

