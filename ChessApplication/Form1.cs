using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessClassLibrary;

namespace ChessApplication
{
    public partial class Form1 : Form
    {
        static private int fieldSize = 100;
        static private int boardWidth = 800;
        static private int boardHeight = 800;

        private Game game;
        private Button[,] board;
        private Dictionary<Players, Dictionary<PieceTypes, Image>> pieceImages;
        private IPieceManager selectedPiece;

        private Image getImage(string filename)
        {
            return new Bitmap(Image.FromFile(filename), new Size(fieldSize, fieldSize));
        }

        private void loadImages()
        {
            Dictionary<PieceTypes, Image> whitePieces = new Dictionary<PieceTypes, Image>();
            whitePieces.Add(PieceTypes.King, getImage("ChessPieceImages\\WhiteKing.png"));
            whitePieces.Add(PieceTypes.Queen, getImage("ChessPieceImages\\WhiteQueen.png"));
            whitePieces.Add(PieceTypes.Rook, getImage("ChessPieceImages\\WhiteRook.png"));
            whitePieces.Add(PieceTypes.Bishop, getImage("ChessPieceImages\\WhiteBishop.png"));
            whitePieces.Add(PieceTypes.Knight, getImage("ChessPieceImages\\WhiteKnight.png"));
            whitePieces.Add(PieceTypes.Pawn, getImage("ChessPieceImages\\WhitePawn.png"));

            Dictionary<PieceTypes, Image> blackPieces = new Dictionary<PieceTypes, Image>();
            blackPieces.Add(PieceTypes.King, getImage("ChessPieceImages\\BlackKing.png"));
            blackPieces.Add(PieceTypes.Queen, getImage("ChessPieceImages\\BlackQueen.png"));
            blackPieces.Add(PieceTypes.Rook, getImage("ChessPieceImages\\BlackRook.png"));
            blackPieces.Add(PieceTypes.Bishop, getImage("ChessPieceImages\\BlackBishop.png"));
            blackPieces.Add(PieceTypes.Knight, getImage("ChessPieceImages\\BlackKnight.png"));
            blackPieces.Add(PieceTypes.Pawn, getImage("ChessPieceImages\\BlackPawn.png"));

            pieceImages = new Dictionary<Players, Dictionary<PieceTypes, Image>>();
            pieceImages.Add(Players.WhitePlayer, whitePieces);
            pieceImages.Add(Players.BlackPlayer, blackPieces);
        }

        private void createBoard()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Color color;
                    if ((x + y) % 2 == 0)
                        color = Color.SaddleBrown;
                    else
                    {
                        color = Color.PapayaWhip;
                    }

                    board[x, y] = createFieldAt(x, y, color);
                }
            }
        }

        private Button createFieldAt(int x, int y, Color color)
        {
            var f = new Button();
            f.Width = Form1.fieldSize;
            f.Height = Form1.fieldSize;
            f.Location = new System.Drawing.Point(x*fieldSize, boardHeight - fieldSize - y*fieldSize);
            f.BackColor = color;
            f.Margin = new Padding(0);
            f.Click += new EventHandler((object sender, EventArgs e) => { onFieldClick(x, y); });
            this.Controls.Add(f);
            return f;
        }

        private void onFieldClick(int x, int y)
        {
            if(selectedPiece is null)
            {
                var pm = game.Board.GetPiece(x, y);
                if(pm.Owner == game.PlayerTurn)
                    selectedPiece = pm;
            }
            else
            {
                if (selectedPiece.canMoveTo(x, y))
                    selectedPiece.moveTo(x, y);
                selectedPiece = null;
            }
            updateBoard();
        }

        private void updateBoard()
        {
            foreach( var piece in game.Board )
            {
                var field = board[piece.PieceXPosition, piece.PieceYPosition];
                if(piece.Type == PieceTypes.Empty)
                {
                    field.Image = null;
                }
                else
                {
                    field.Image = pieceImages[piece.Owner][piece.Type];
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            board = new Button[8, 8];
            game = new Game();
            createBoard();
            loadImages();
            updateBoard();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
