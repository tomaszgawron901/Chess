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
        [TestMethod()]
        public void constructor_corect()
        {
            Piece wp = new WhitePawn();
            Assert.AreEqual(wp.Color, "White");
            Assert.AreEqual(wp.Name, "Pawn");
            Assert.IsFalse(wp.WasMoved);
            Point[] correctMoveArray = new Point[] { new Point(0, 1), new Point(0, 2) };
            Assert.AreEqual(wp.MoveSet.Length, correctMoveArray.Length);
            for (int i = 0; i < correctMoveArray.Length; i++)
            {
                Assert.AreEqual(wp.MoveSet[i], correctMoveArray[i]);
            }

            Point[] correctKillArray = new Point[] { new Point(-1, 1), new Point(1, 1) };
            Assert.AreEqual(wp.KillSet.Length, correctKillArray.Length);
            for (int i = 0; i < correctKillArray.Length; i++)
            {
                Assert.AreEqual(wp.KillSet[i], correctKillArray[i]);
            }
        }

        [TestMethod()]
        public void firstMove_corect()
        {
            Piece wp = new WhitePawn();
            Assert.IsTrue(wp.MoveSet.Length == 2);
            wp.firstMove();
            Assert.IsTrue(wp.MoveSet.Length == 1);
            Assert.AreEqual(wp.MoveSet[0], new Point(0, 1));
        }
    }
}