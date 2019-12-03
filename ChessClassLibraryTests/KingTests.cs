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
    public class KingTests
    {
        [TestMethod()]
        public void Castle_Move_correct()
        {
            ChessBoard board = new ChessBoard();
            board.SetPiece(null, new Point(1, 0));
            board.SetPiece(null, new Point(2, 0));
            board.SetPiece(null, new Point(3, 0));
            var rook = board.GetPiece(new Point(0, 0));
            Assert.IsTrue(board.WhiteKing.canMoveTo(new Point(2, 0)));
            board.WhiteKing.moveTo(new Point(2, 0));
            Assert.IsNull(board.GetPiece(new Point(0, 0)));
            Assert.IsNull(board.GetPiece(new Point(4, 0)));
            Assert.AreSame(board.GetPiece(new Point(3, 0)), rook);
            Assert.AreEqual(rook.Position, new Point(3, 0));
            Assert.AreSame(board.GetPiece(new Point(2, 0)), board.WhiteKing);
            Assert.AreEqual(board.WhiteKing.Position, new Point(2, 0));
        }
    }
}