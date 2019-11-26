using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    static class ChessBoard
    {
        static public Piece[][] Create()
        {// TODO
            return null;
        }

        static private Piece[] CreateEmptyRow()
        {
            return new Piece[] {null, null, null, null, null, null, null, null };
        }

        static private Piece[] CreatePawnRow(string color)
        {
            // TODO
            if (color != "White" && color != "Black")
                throw new ArgumentException("Piece can be 'White' or 'Black'.");
            if(color == "White")
            {
                return new Piece[] { };
            }
            return new Piece[] { };
        }
    }

    class Game
    {
        private Piece[][] board;
        public Game()
        {

        }

    }
}
