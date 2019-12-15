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
    public class GameTests
    {
        [TestMethod()]
        public void constructor_correct()
        {
            Game game = new Game();
            Assert.IsNotNull(game.Board);
            Assert.AreEqual(game.GameState, GameStates.inProgress);
            Assert.AreEqual(game.playerTurn, Players.WhitePlayer);
        }

    }

    [TestClass()]
    public class BoardManagerTests
    {
        [TestMethod()]
        public void constructor()
        {
            BoardManager bm = new Game().Board;
            Assert.AreEqual(bm.BoardHeight, 8);
            Assert.AreEqual(bm.BoardWidth, 8);
        }

        [TestMethod()]
        public void getPiece()
        {
            BoardManager bm = new Game().Board;
            ChessBoard cb = new ChessBoard();
            for(int x = 0; x < 8; x++)
            {
                for(int y= 0; y<8; y++)
                {
                    if (cb.GetPiece(new Point(x, y)) is null)
                        Assert.IsNull(bm.GetPiece(x, y));
                    else
                        Assert.IsTrue(bm.GetPiece(x, y) is PieceManager);
                }
            }
        }
    }

    [TestClass()]
    public class PieceManagerTests
    {
        [TestMethod()]
        public void constructor_whitePawn()
        {
            Piece piece = new WhitePawn(new Point(0, 0), new ChessBoard());
            PieceManager pm = new PieceManager(piece, new Game());
            Assert.AreEqual(pm.Owner, Players.WhitePlayer);
            Assert.AreEqual(pm.Type, PieceTypes.Pawn);
        }

        [TestMethod()]
        public void constructor_whiteRook()
        {
            Piece piece = new Rook("White", new Point(0, 0), new ChessBoard());
            PieceManager pm = new PieceManager(piece, new Game());
            Assert.AreEqual(pm.Owner, Players.WhitePlayer);
            Assert.AreEqual(pm.Type, PieceTypes.Rook);
        }

        [TestMethod()]
        public void constructor_whiteKnight()
        {
            Piece piece = new Knight("White", new Point(0, 0), new ChessBoard());
            PieceManager pm = new PieceManager(piece, new Game());
            Assert.AreEqual(pm.Owner, Players.WhitePlayer);
            Assert.AreEqual(pm.Type, PieceTypes.Knight);
        }

        [TestMethod()]
        public void constructor_whiteBishop()
        {
            Piece piece = new Bishop("White", new Point(0, 0), new ChessBoard());
            PieceManager pm = new PieceManager(piece, new Game());
            Assert.AreEqual(pm.Owner, Players.WhitePlayer);
            Assert.AreEqual(pm.Type, PieceTypes.Bishop);
        }

        [TestMethod()]
        public void constructor_whiteQueen()
        {
            Piece piece = new Queen("White", new Point(0, 0), new ChessBoard());
            PieceManager pm = new PieceManager(piece, new Game());
            Assert.AreEqual(pm.Owner, Players.WhitePlayer);
            Assert.AreEqual(pm.Type, PieceTypes.Queen);
        }

        [TestMethod()]
        public void constructor_whiteKing()
        {
            Piece piece = new ChessBoard().GetPiece(new Point(4, 0));
            PieceManager pm = new PieceManager(piece, new Game());
            Assert.AreEqual(pm.Owner, Players.WhitePlayer);
            Assert.AreEqual(pm.Type, PieceTypes.King);
        }

        [TestMethod()]
        public void constructor_blackPawn()
        {
            Piece piece = new BlackPawn(new Point(7, 7), new ChessBoard());
            PieceManager pm = new PieceManager(piece, new Game());
            Assert.AreEqual(pm.Owner, Players.BlackPlayer);
            Assert.AreEqual(pm.Type, PieceTypes.Pawn);
        }

        [TestMethod()]
        public void constructor_blackRook()
        {
            Piece piece = new Rook("Black", new Point(0, 0), new ChessBoard());
            PieceManager pm = new PieceManager(piece, new Game());
            Assert.AreEqual(pm.Owner, Players.BlackPlayer);
            Assert.AreEqual(pm.Type, PieceTypes.Rook);
        }

        [TestMethod()]
        public void constructor_blackKnight()
        {
            Piece piece = new Knight("Black", new Point(0, 0), new ChessBoard());
            PieceManager pm = new PieceManager(piece, new Game());
            Assert.AreEqual(pm.Owner, Players.BlackPlayer);
            Assert.AreEqual(pm.Type, PieceTypes.Knight);
        }

        [TestMethod()]
        public void constructor_blackBishop()
        {
            Piece piece = new Bishop("Black", new Point(0, 0), new ChessBoard());
            PieceManager pm = new PieceManager(piece, new Game());
            Assert.AreEqual(pm.Owner, Players.BlackPlayer);
            Assert.AreEqual(pm.Type, PieceTypes.Bishop);
        }

        [TestMethod()]
        public void constructor_blackQueen()
        {
            Piece piece = new Queen("Black", new Point(0, 0), new ChessBoard());
            PieceManager pm = new PieceManager(piece, new Game());
            Assert.AreEqual(pm.Owner, Players.BlackPlayer);
            Assert.AreEqual(pm.Type, PieceTypes.Queen);
        }

        [TestMethod()]
        public void constructor_blackKing()
        {
            Piece piece = new ChessBoard().GetPiece(new Point(4, 7));
            PieceManager pm = new PieceManager(piece, new Game());
            Assert.AreEqual(pm.Owner, Players.BlackPlayer);
            Assert.AreEqual(pm.Type, PieceTypes.King);
        }

        [TestMethod()]
        public void canMoveTo_true()
        {
            Game game = new Game();
            Assert.IsTrue(game.Board.GetPiece(5, 1).canMoveTo(5, 2));
            Assert.IsTrue(game.Board.GetPiece(5, 1).canMoveTo(5, 3));
            game.Board.GetPiece(5, 1).moveTo(5, 3);
            Assert.IsTrue(game.Board.GetPiece(6, 7).canMoveTo(5, 5));
            Assert.IsTrue(game.Board.GetPiece(6, 7).canMoveTo(7, 5));
        }

        [TestMethod()]
        public void canMoveTo_false()
        {
            Game game = new Game();
            Assert.IsFalse(game.Board.GetPiece(5, 1).canMoveTo(6, 2));
            Assert.IsFalse(game.Board.GetPiece(5, 1).canMoveTo(6, 1));
            Assert.IsFalse(game.Board.GetPiece(5, 6).canMoveTo(6, 6));
            game.Board.GetPiece(5, 1).moveTo(5, 2);
            Assert.IsFalse(game.Board.GetPiece(5, 2).canMoveTo(5, 3));
        }

        [TestMethod()]
        public void moveTo_corrcet()
        {
            Game game = new Game();
            PieceManager piece = game.Board.GetPiece(5, 1);
            piece.moveTo(5, 2);
            Assert.IsNull(game.Board.GetPiece(5, 1));
            Assert.AreEqual(piece.Owner, game.Board.GetPiece(5, 2).Owner);
            Assert.AreEqual(piece.Type, game.Board.GetPiece(5, 2).Type);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void moveTo_exception_enotherPlayerTurn()
        {
            Game game = new Game();
            game.Board.GetPiece(6, 6).moveTo(6, 5);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void moveTo_exception_wrong_position()
        {
            Game game = new Game();
            game.Board.GetPiece(6, 1).moveTo(5, 2);
        }
    }
}