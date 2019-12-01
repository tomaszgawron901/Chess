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
    public class WhitePawnTests
    {

        [DataTestMethod()]
        [DataRow(4, 4)]
        [DataRow(0, 0)]
        [DataRow(7, 7)]
        public void constructor_correct(int x, int y)
        {
            ChessBoard board = new ChessBoard();
            Piece whitePawn = new WhitePawn(new Point(x, y), board);
            Assert.AreSame(board.GetPiece(new Point(x, y)), whitePawn);
            Assert.AreEqual(whitePawn.Position, new Point(x, y));
        }

        [DataTestMethod()]
        [DataRow(8, 8)]
        [DataRow(-1, 0)]
        [DataRow(0, -1)]
        [ExpectedException(typeof(ArgumentException))]
        public void constructor_throw_ArgumentException(int x, int y)
        {
            ChessBoard board = new ChessBoard();
            Piece whitePawn = new WhitePawn(new Point(x, y), board);
        }

        [DataTestMethod()]
        [DataRow(3, 4)]
        [DataRow(3, 5)]
        [DataRow(2, 4)]
        [DataRow(4, 4)]
        public void move_for_the_first_time(int x, int y)
        {
            ChessBoard board = new ChessBoard();
            new BlackPawn(new Point(2, 4), board);
            new BlackPawn(new Point(4, 4), board);
            Piece whitePawn = new WhitePawn(new Point(3, 3), board);
            Assert.AreEqual(whitePawn.MoveSet[0], new Point(0, 1));
            Assert.AreEqual(whitePawn.MoveSet[1], new Point(0, 2));
            Assert.IsFalse(whitePawn.WasMoved);
            whitePawn.moveTo(new Point(x, y));
            Assert.AreEqual(whitePawn.MoveSet[0], new Point(0, 1));
            Assert.IsTrue(whitePawn.WasMoved);
        }

        [TestMethod()]
        public void transformToQueen_correct()
        {
            ChessBoard board = new ChessBoard();
            board.SetPiece(null, new Point(7, 7));
            new WhitePawn(new Point(7, 6), board);
            board.GetPiece(new Point(7, 6)).moveTo(new Point(7, 7));
            Assert.IsNull(board.GetPiece(new Point(7, 6)));
            Assert.IsTrue(board.GetPiece(new Point(7, 7)) is Queen);
            Assert.IsTrue(board.GetPiece(new Point(7, 7)).Color == "White");
        }
    }

    [TestClass()]
    public class BlackPawnTests
    {

        [DataTestMethod()]
        [DataRow(4, 4)]
        [DataRow(0, 0)]
        [DataRow(7, 7)]
        public void constructor_correct(int x, int y)
        {
            ChessBoard board = new ChessBoard();
            Piece blackPawn = new BlackPawn(new Point(x, y), board);
            Assert.AreSame(board.GetPiece(new Point(x, y)), blackPawn);
            Assert.AreEqual(blackPawn.Position, new Point(x, y));
        }

        [DataTestMethod()]
        [DataRow(8, 8)]
        [DataRow(-1, 0)]
        [DataRow(0, -1)]
        [ExpectedException(typeof(ArgumentException))]
        public void constructor_throw_ArgumentException(int x, int y)
        {
            ChessBoard board = new ChessBoard();
            Piece blackPawn = new BlackPawn(new Point(x, y), board);
        }

        [DataTestMethod()]
        [DataRow(4, 4)]
        [DataRow(4, 3)]
        [DataRow(3, 4)]
        [DataRow(5, 4)]
        public void move_for_the_first_time(int x, int y)
        {
            ChessBoard board = new ChessBoard();
            new WhitePawn(new Point(3, 4), board);
            new WhitePawn(new Point(5, 4), board);
            Piece blackPawn = new BlackPawn(new Point(4, 5), board);
            Assert.AreEqual(blackPawn.MoveSet[0], new Point(0, -1));
            Assert.AreEqual(blackPawn.MoveSet[1], new Point(0, -2));
            Assert.IsFalse(blackPawn.WasMoved);
            blackPawn.moveTo(new Point(x, y));
            Assert.AreEqual(blackPawn.MoveSet[0], new Point(0, -1));
            Assert.IsTrue(blackPawn.WasMoved);
        }

        [TestMethod()]
        public void transformToQueen_correct()
        {
            ChessBoard board = new ChessBoard();
            board.SetPiece(null, new Point(7, 0));
            new BlackPawn(new Point(7, 1), board);
            board.GetPiece(new Point(7, 1)).moveTo(new Point(7, 0));
            Assert.IsNull(board.GetPiece(new Point(7, 1)));
            Assert.IsTrue(board.GetPiece(new Point(7, 0)) is Queen);
            Assert.IsTrue(board.GetPiece(new Point(7, 0)).Color == "Black");
        }
    }
}