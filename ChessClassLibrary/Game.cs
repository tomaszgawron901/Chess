using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    class ChessBoard
    {
        private int width = 8;
        private int height = 8;
        private Piece[][] board;

        /// <summary>
        /// Returns the width of the board.
        /// </summary>
        public int Width
        {
            get { return width; }
        }

        /// <summary>
        /// Returns the height of the board.
        /// </summary>
        public int Height
        {
            get { return height; }
        }

        /// <summary>
        /// Returns current board.
        /// </summary>
        public Piece[][] Board
        {
            get { return board; }
        }

        public ChessBoard()
        {
            board = create();
        }

        /// <summary>
        /// Checks whether Point position is in the range of the board.
        /// </summary>
        /// <param name="position">Point to check.</param>
        /// <returns>True when Point is in the range, otherwise false.</returns>
        public bool CoordinateIsInRange(Point position)
        {
            if (position.X < 0 || position.X >= width || position.Y < 0 || position.Y >= height)
                return false;
            return true;
        }

        /// <summary>
        /// Returns Piece from given position.
        /// </summary>
        /// <param name="position">Position on the board.</param>
        /// <returns>The Piece from given position.</returns>
        public Piece GetPiece(Point position)
        {
            if (!CoordinateIsInRange(position))
                throw new ArgumentOutOfRangeException("Given position is out of chess board range.");
            return board[position.Y][position.X];
        }

        private Piece[][] create()
        {
            return new Piece[][] { 
                createRichRow("White"),
                createPawnRow("White"),
                createEmptyRow(),
                createEmptyRow(),
                createEmptyRow(),
                createEmptyRow(),
                createPawnRow("Black"),
                createRichRow("Black")};
        }

        private Piece[] createEmptyRow()
        {
            return new Piece[] {null, null, null, null, null, null, null, null };
        }

        private Piece[] createPawnRow(string color)
        {
            if (color != "White" && color != "Black")
                throw new ArgumentException("Piece can be 'White' or 'Black'.");
            if(color == "White")
            {
                return new Piece[] {
                    new WhitePawn(), 
                    new WhitePawn(), 
                    new WhitePawn(), 
                    new WhitePawn(), 
                    new WhitePawn(), 
                    new WhitePawn(), 
                    new WhitePawn(), 
                    new WhitePawn()};
            }
            return new Piece[] {
                new BlackPawn(), 
                new BlackPawn(), 
                new BlackPawn(), 
                new BlackPawn(), 
                new BlackPawn(), 
                new BlackPawn(), 
                new BlackPawn(), 
                new BlackPawn()};
        }

        private Piece[] createRichRow(string color)
        {
            if (color != "White" && color != "Black")
                throw new ArgumentException("Piece can be 'White' or 'Black'.");
            return new Piece[] {
                new Rook(color),
                new Knight(color),
                new Bishop(color),
                new Queen(color),
                new King(color),
                new Bishop(color),
                new Knight(color),
                new Rook(color)};
        }
    }

    class Game
    {
        private ChessBoard chessBoard;
        private string playerColor;
        public Game()
        {
            chessBoard = new ChessBoard();
            playerColor = "White";
        }



        public bool CanMove(Point from, Point to)// TODO ------------------- TODO ------------------------ TODO
        {
            if (!chessBoard.CoordinateIsInRange(from) || !chessBoard.CoordinateIsInRange(to))
                return false;
            Piece p1 = chessBoard.GetPiece(from);
            Piece p2 = chessBoard.GetPiece(to);
            if (p1 == null)
                return false;
            if (p1.Color != playerColor)
                return false;
            
            if(p2 != null)
            {
                if (p2.Color == p1.Color)
                    return false;
                else
                {

                }
            }
            else
            {

            }


            return false;
        }

    }
}
