using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    public enum GameStates { inProgress, whiteWin, blackWin, whiteCheck, blackCheck, stalemate };
    public enum Players { WhitePlayer, BlackPlayer };
    public enum PieceTypes {Pawn, Rook, Knight, Bishop, Queen, King};

    public class BoardManager
    {
        private ChessBoard board;
        private Game game;
        public BoardManager(ChessBoard board ,Game game)
        {
            if(game is null)
                throw new Exception("Game does not exist.");
            if (board is null)
                throw new Exception("ChessBoard does not exist.");
            this.game = game;
            this.board = board;
        }

        /// <summary>
        /// Gets the width of the board.
        /// </summary>
        public int BoardWidth
        {
            get { return board.Width; }
        }

        /// <summary>
        /// Gest the height of the board.
        /// </summary>
        public int BoardHeight
        {
            get { return board.Height; }
        }

        /// <summary>
        /// Returns a Piece from given position.
        /// If there is no Piece at given Position returns null.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <returns>PieceManager from given position.</returns>
        public PieceManager GetPiece(int x, int y)
        {
            Piece p = board.GetPiece(new Point(x, y));
            if (p is null)
                return null;
            return new PieceManager(p, game);
        }

        /// <summary>
        /// Returns current state of the board.
        /// </summary>
        /// <returns></returns>
        public GameStates GetState()
        {
            return board.GetState();
        }
    }

    public class PieceManager
    {
        private Piece piece;
        private Game game;
        public PieceManager(Piece piece, Game game)
        {
            if (game is null)
                throw new Exception("Game does not exist.");
            if (piece is null)
                throw new Exception("Piece does not exist.");
            this.piece = piece;
            this.game = game;
        }

        /// <summary>
        /// Gets Piece owner.
        /// </summary>
        public Players Owner
        {
            get {
                if (piece is null)
                    throw new Exception("Piece does not exist.");
                switch (piece.Color)
                {
                    case "White":
                        return Players.WhitePlayer;
                    case "Black":
                        return Players.BlackPlayer;
                    default:
                        throw new Exception("Unexpected ovner.");
                }
            }
        }

        /// <summary>
        /// Gets Piece type.
        /// </summary>
        public PieceTypes Type
        {
            get {
                if (piece is null)
                    throw new Exception("Piece does not exist.");
                switch(piece.Name)
                {
                    case "Pawn":
                        return PieceTypes.Pawn;
                    case "Rook":
                        return PieceTypes.Rook;
                    case "Knight":
                        return PieceTypes.Knight;
                    case "Bishop":
                        return PieceTypes.Bishop;
                    case "Queen":
                        return PieceTypes.Queen;
                    case "King":
                        return PieceTypes.King;
                    default:
                        throw new Exception("Unexpected Piece type.");
                }
            }
        }

        /// <summary>
        /// Checks whether Piece can be moved to given position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate</param>
        /// <returns></returns>
        public bool canMoveTo(int x, int y)
        {
            if (game.PlayerTurn == Players.WhitePlayer && Owner == Players.BlackPlayer)
                return false;
            if (game.PlayerTurn == Players.BlackPlayer && Owner == Players.WhitePlayer)
                return false;
            if (game.GameState == GameStates.blackWin || game.GameState == GameStates.whiteWin || game.GameState == GameStates.stalemate)
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
        /// <summary>
        /// Gets board manager.
        /// </summary>
        BoardManager Board { get; }

        /// <summary>
        /// Gets current game state.
        /// </summary>
        GameStates GameState { get; }

        /// <summary>
        /// Gets current playing player.
        /// </summary>
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
