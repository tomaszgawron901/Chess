using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary.Tests
{
    [TestClass()]
    public class ChessBoardTests
    {
        private static ChessBoard board = new ChessBoard();

        private void RowIsRich(Piece[] row)
        {
            Assert.IsTrue(row[0] is Rook);
            Assert.IsTrue(row[1] is Knight);
            Assert.IsTrue(row[2] is Bishop);
            Assert.IsTrue(row[3] is Queen);
            Assert.IsTrue(row[4] is King);
            Assert.IsTrue(row[5] is Bishop);
            Assert.IsTrue(row[6] is Knight);
            Assert.IsTrue(row[7] is Rook);
        }

        private void RowHasColor(Piece[] row, string color)
        {
            foreach(Piece p in row)
            {
                Assert.IsNotNull(p);
                Assert.AreEqual(p.Color, color);
            }
        }

        private void RowIsEmpty(Piece[] row)
        {
            foreach(Piece p in row)
            {
                Assert.IsNull(p);
            }
        }

        [TestMethod()]
        public void constructor_corect()
        {
            Assert.AreEqual(board.Width, 8);
            Assert.AreEqual(board.Height, 8);

            Assert.IsTrue(board.WhiteKing is King);
            Assert.IsTrue(board.BlackKing is King);
            Assert.AreSame(board.WhiteKing, board.GetPiece(new Point(4, 0)));
            Assert.AreSame(board.BlackKing, board.GetPiece(new Point(4, 7)));

            for (int y = 2; y < 6; y++ )
            {
                RowIsEmpty(board.Board[y]);
            }
            for(int x = 0; x<8; x++)
            {
                Piece p = board.Board[1][x];
                Assert.IsTrue(p is WhitePawn);
                Assert.AreEqual(p.Position, new Point(x, 1));
            }
            for (int x = 0; x < 8; x++)
            {
                Piece p = board.Board[6][x];
                Assert.IsTrue(p is BlackPawn);
                Assert.AreEqual(p.Position, new Point(x, 6));
            }

            RowIsRich(board.Board[0]);
            RowHasColor(board.Board[0], "White");

            RowIsRich(board.Board[7]);
            RowHasColor(board.Board[7], "Black");

        }

        [DataTestMethod()]
        [DataRow(0, 0)]
        [DataRow(7, 7)]
        [DataRow(5, 5)]
        [DataRow(0, 7)]
        [DataRow(7, 0)]
        public void Coordinate_Is_In_Range_True(int x, int y)
        {
            Assert.IsTrue(board.CoordinateIsInRange(new Point(x, y)));
        }

        [DataTestMethod()]
        [DataRow(-1, -1)]
        [DataRow(8, 8)]
        [DataRow(8, 5)]
        [DataRow(5, 8)]
        [DataRow(8, 0)]
        public void Coordinate_Is_In_Range_False(int x, int y)
        {
            Assert.IsFalse(board.CoordinateIsInRange(new Point(x, y)));
        }

        [TestMethod()]
        public void GetPiece_Correct()
        {
            for(int x =0; x < 8; x++)
            {
                for(int y =0; y < 8; y++)
                {
                    Assert.AreSame(board.GetPiece(new Point(x, y)), board.Board[y][x]);
                }
            }
        }

        [DataTestMethod()]
        [DataRow(-1, -1)]
        [DataRow(8, 8)]
        [DataRow(8, 5)]
        [DataRow(5, 8)]
        [DataRow(8, 0)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetPiece_throw_exception(int x, int y)
        {
            board.GetPiece(new Point(x, y));
        }

        [DataTestMethod()]
        [DataRow(0, 0)]
        [DataRow(7, 7)]
        [DataRow(5, 5)]
        [DataRow(0, 7)]
        [DataRow(7, 0)]
        public void SetPiece_correct(int x, int y)
        {
            ChessBoard board2 = new ChessBoard();
            Piece piece = new Rook("white", new Point(x, y), board2);
            board2.SetPiece(piece, new Point(x, y));
            Assert.AreSame(board2.Board[y][x], piece);
            board2.SetPiece(null, new Point(x, y));
            Assert.AreSame(board2.Board[y][x], null);
        }

        [DataTestMethod()]
        [DataRow(3, 4)]
        [DataRow(5, 5)]
        [DataRow(0, 0)]
        [ExpectedException(typeof(ArgumentException))]
        public void SetPiece_throw_ArgumentException(int x, int y)
        {
            ChessBoard board2 = new ChessBoard();
            Piece piece = new Rook("white", new Point(x+1, y), board2);
            board2.SetPiece(piece, new Point(x, y));
        }

        [DataTestMethod()]
        [DataRow(4, 8)]
        [DataRow(8, 4)]
        [DataRow(8, 8)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetPiece_throw_ArgumentOutOfRangeException(int x, int y)
        {
            ChessBoard board2 = new ChessBoard();
            Piece piece = new Rook("white", new Point(x-1, y-1), board2);
            board2.SetPiece(piece, new Point(x, y));
        }
    }
}