using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    public enum GameStates { inProgress, whiteWin, blackWin, whiteCheck, blackCheck};
    public enum Players { WhitePlayer, BlackPlayer };
    public enum PieceTypes {Pawn, Rook, Knight, Bishop, Queen, King };

    public class BoardManager
    {
        private ChessBoard board;
        private Game game;
        public BoardManager(ChessBoard board ,Game game)
        {
            if(game is null)
                throw new Exception("Game is null.");
            if (board is null)
                throw new Exception("ChessBoard is null.");
            this.game = game;
            this.board = board;
        }

        /// <summary>
        /// Returns a Piece Piece from given position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <returns>PieceManager from given position.</returns>
        public PieceManager GetPiece(int x, int y)
        {
            return new PieceManager(board.GetPiece(new Point(x, y)), game);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public PieceManager[][] GetCurrentBoard()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return current state of the board.
        /// </summary>
        /// <returns></returns>
        public GameStates GetState()
        {
            if (board.WhiteKing is null)
                return GameStates.blackWin;
            if (board.BlackKing is null)
                return GameStates.whiteWin;
            if (board.WhiteKing.IsChecked())
                return GameStates.whiteCheck;
            if (board.BlackKing.IsChecked())
                return GameStates.blackCheck;
            return GameStates.inProgress;
        }
    }

    public class PieceManager
    {
        private Piece piece;
        private Game game;
        public PieceManager(Piece piece, Game game)
        {
            if (game is null)
                throw new Exception("Game is null.");
            this.piece = piece;
            this.game = game;
        }

        public string Color
        {
            get {
                if (piece is null)
                    return null;
                return piece.Color; }
        }
        public string Name
        {
            get {
                if (piece is null)
                    return null;
                return piece.Name; }
        }

        /// <summary>
        /// Checks whether Piece can be moved to given position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate</param>
        /// <returns></returns>
        public bool canMoveTo(int x, int y)
        {
            if (game.PlayerTurn == Players.WhitePlayer && piece.Color == "Black")
                return false;
            if (game.PlayerTurn == Players.BlackPlayer && piece.Color == "White")
                return false;
            if (game.GameState == GameStates.blackWin || game.GameState == GameStates.whiteWin)
                return false;
            if (piece is null)
                return false;
            return piece.canMoveTo(new Point(x, y));
        }

        /// <summary>
        /// Moves Piece to given position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate</param>
        public void moveTo(int x, int y)
        {
            if (game.GameState == GameStates.blackWin || game.GameState == GameStates.whiteWin)
                throw new Exception("Cannot move, the game is over.");
            if (piece is null)
                throw new Exception("Cannot move not existed Piece.");
            if (!canMoveTo(x, y))
                throw new Exception("Cannot move Piece to given position.");
            piece.moveTo(new Point(x, y));
            game.AnotherPlayerTurn();
            game.UpdateState();
        }
    }


    public interface UserGame
    {
        BoardManager Board { get; }
        GameStates GameState { get; }
        Players PlayerTurn { get; }
    }

    public class Game: UserGame
    {
        private BoardManager board;
        private GameStates gameState;
        public Players playerTurn;

        public BoardManager Board
        {
            get { return board; }
        }
        public GameStates GameState
        {
            get { return gameState; }
        }
        public Players PlayerTurn
        {
            get { return playerTurn; }
        }

        public Game()
        {
            board = new BoardManager(new ChessBoard(), this);
            gameState = GameStates.inProgress;
            playerTurn = Players.WhitePlayer;
        }

        public void AnotherPlayerTurn()
        {
            if (PlayerTurn == Players.WhitePlayer)
                playerTurn = Players.BlackPlayer;
            else if(PlayerTurn == Players.BlackPlayer)
                playerTurn = Players.WhitePlayer;
        }

        public void UpdateState()
        {
            gameState = board.GetState();
        }
    }
}
