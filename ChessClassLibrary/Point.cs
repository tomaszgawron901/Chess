using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    public struct Point: IEquatable<Point>
    {
        private int x;
        private int y;

        /// <summary>
        /// Returns x coordinate.
        /// </summary>
        public int X
        {
            get { return x; }
        }

        /// <summary>
        /// Returns y coordinate.
        /// </summary>
        public int Y
        {
            get { return y; }
        }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool Equals(Point other)
        {
            if (X == other.X && Y == other.Y)
                return true;
            return false;
        }

        public override bool Equals(object other)
        {
            if (other is Point)
            {
                return Equals((Point)other);
            }
            return false;
        }

        public override int GetHashCode()
        {
            var hashCode = 1502939027;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            return hashCode;
        }

        public Point Plue(Point other)
        {
            return new Point(X + other.X, Y + other.Y);
        }

        public Point Minus(Point other)
        {
            return new Point(X - other.X, Y - other.Y);
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return !p1.Equals(p2);
        }

        public static Point operator +(Point left, Point right)
        {
            return left.Plue(right);
        }

        public static Point operator -(Point left, Point right)
        {
            return left.Minus(right);
        }
    }
}
