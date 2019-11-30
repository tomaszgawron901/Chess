﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    public class ChessBoard
    {
        private static int width = 8;
        private static int height = 8;
        /// <summary>
        /// The width of the board.
        /// </summary>
        public int Width
        {
            get { return width; }
        }

        /// <summary>
        /// The height of the board.
        /// </summary>
        public int Height
        {
            get { return height; }
        }



        private Piece[][] board;

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

        /// <summary>
        /// Sets given Piece at given position.
        /// </summary>
        /// <param name="piece">Piece to set.</param>
        /// <param name="position">Position.</param>
        public void SetPiece(Piece piece, Point position)
        {
            if (!CoordinateIsInRange(position))
                throw new ArgumentOutOfRangeException("Given position is out of chess board range.");
            if (piece != null && piece.Position != position)
                throw new ArgumentException("Piece position does not match to given position.");
            board[position.Y][position.X] = piece;
        }

        private Piece[][] create()
        {
            return new Piece[][] { 
                createRichRow(0, "White"),
                createPawnRow(1, "White"),
                createEmptyRow(),
                createEmptyRow(),
                createEmptyRow(),
                createEmptyRow(),
                createPawnRow(6, "Black"),
                createRichRow(7, "Black")};
        }

        private Piece[] createEmptyRow()
        {
            return new Piece[] {null, null, null, null, null, null, null, null };
        }

        private Piece[] createPawnRow(int row, string color)
        {
            if (color != "White" && color != "Black")
                throw new ArgumentException("Piece can be 'White' or 'Black'.");
            if(color == "White")
            {
                return new Piece[] {
                    new WhitePawn(new Point(0, row), this), 
                    new WhitePawn(new Point(1, row), this), 
                    new WhitePawn(new Point(2, row), this), 
                    new WhitePawn(new Point(3, row), this), 
                    new WhitePawn(new Point(4, row), this), 
                    new WhitePawn(new Point(5, row), this), 
                    new WhitePawn(new Point(6, row), this), 
                    new WhitePawn(new Point(7, row), this)};
            }
            return new Piece[] {
                new BlackPawn(new Point(0, row), this),
                new BlackPawn(new Point(1, row), this),
                new BlackPawn(new Point(2, row), this),
                new BlackPawn(new Point(3, row), this),
                new BlackPawn(new Point(4, row), this),
                new BlackPawn(new Point(5, row), this),
                new BlackPawn(new Point(6, row), this),
                new BlackPawn(new Point(7, row), this)};
        }

        private Piece[] createRichRow(int row, string color)
        {
            if (color != "White" && color != "Black")
                throw new ArgumentException("Piece can be 'White' or 'Black'.");
            return new Piece[] {
                new Rook(color,new Point(0, row), this),
                new Knight(color,new Point(1, row), this),
                new Bishop(color,new Point(2, row), this),
                new Queen(color,new Point(3, row), this),
                new King(color,new Point(4, row), this),
                new Bishop(color,new Point(5, row), this),
                new Knight(color,new Point(6, row), this),
                new Rook(color,new Point(7, row), this)};
        }
    }

    public class Game
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
            throw new NotImplementedException();
        }

    }
}
