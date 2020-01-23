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

        private Dictionary<Players, Dictionary<PieceTypes, Image>> loadImages()
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

            var output = new Dictionary<Players, Dictionary<PieceTypes, Image>>();
            output.Add(Players.WhitePlayer, whitePieces);
            output.Add(Players.BlackPlayer, blackPieces);
            return output;
        }

        private Button[,] createBoard()
        {
             var output = new Button[8, 8];
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

                    output[x, y] = createFieldAt(x, y, color);
                }
            }
            return output;
        }

        private Button createFieldAt(int x, int y, Color color)
        {
            var f = new Button();
            f.Width = Form1.fieldSize;
            f.Height = Form1.fieldSize;
            f.Location = new System.Drawing.Point(x*fieldSize, boardHeight - fieldSize - y*fieldSize + 24);
            f.BackColor = color;
            f.Margin = new Padding(0);
            f.FlatStyle = FlatStyle.Flat;
            f.FlatAppearance.BorderColor = Color.LightGray;
            f.FlatAppearance.BorderSize = 2;
            f.Click += new EventHandler((object sender, EventArgs e) => { onFieldClick(x, y); });
            f.MouseEnter += new EventHandler((object sender, EventArgs e) => { onMouseEnter(x, y); });
            f.MouseLeave += new EventHandler((object sender, EventArgs e) => { onMouseLeave(x, y); });
            return f;
        }

        private void onMouseEnter(int x, int y)
        {
            if (game is null || game.GameState == GameStates.blackWin || game.GameState == GameStates.whiteWin)
                return;

            if (selectedPiece == null)
                return;

            if (selectedPiece.PieceXPosition == x && selectedPiece.PieceYPosition == y)
                return;

            if(selectedPiece.canMoveTo(x, y))
            {
                board[x, y].FlatAppearance.BorderColor = Color.GreenYellow;
                return;
            }
            board[x, y].FlatAppearance.BorderColor = Color.Red;
        }

        private void onMouseLeave(int x, int y)
        {
            if (game is null || game.GameState == GameStates.blackWin || game.GameState == GameStates.whiteWin)
                return;

            if (selectedPiece != null && selectedPiece.PieceXPosition == x && selectedPiece.PieceYPosition == y)
            {
                board[x, y].FlatAppearance.BorderColor = Color.Black;
                return;
            }
            board[x, y].FlatAppearance.BorderColor = Color.LightGray;
        }

        private void onFieldClick(int x, int y)
        {
            if (game is null || game.GameState == GameStates.blackWin || game.GameState == GameStates.whiteWin)
                return;

            if(selectedPiece is null)
            {
                var pm = game.Board.GetPiece(x, y);
                if(pm.Owner == game.PlayerTurn)
                    selectedPiece = pm;
            }
            else
            {
                if (selectedPiece.canMoveTo(x, y))
                {
                    selectedPiece.moveTo(x, y);
                    if(game.GameState == GameStates.blackWin)
                    {
                        var king = game.Board.getWhiteKing();
                        board[king.PieceXPosition, king.PieceYPosition].BackColor = Color.Red;
                    }else if(game.GameState == GameStates.whiteWin)
                    {
                        var king = game.Board.getBlackKing();
                        board[king.PieceXPosition, king.PieceYPosition].BackColor = Color.Red;
                    }
                }
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
                field.FlatAppearance.BorderColor = Color.LightGray;
            }
            if (selectedPiece != null)
            {
                board[selectedPiece.PieceXPosition, selectedPiece.PieceYPosition].FlatAppearance.BorderColor = Color.Black;
            }
        }

        private void setBoardDefaultColors()
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

                    board[x, y].BackColor = color;
                }
            }
        }

        private void disposeBoard()
        {
            foreach(var field in board)
            {
                this.Controls.Add(field);
            }
        }


        private Game createGame()
        {
            return new Game();
        }

        private async void startNewGame()
        {
            var startGameTask = new Task<Game>(createGame);
            var updateBoardTask = new Task(updateBoard);
            var updateColorTask = new Task(setBoardDefaultColors);

            startGameTask.Start();

            game = await startGameTask;

            updateBoardTask.Start();
            updateColorTask.Start();
            await updateBoardTask;
            await updateColorTask;
        }

        public Form1()
        {
            InitializeComponent();
            InitializeBoard();
        }

        private async void InitializeBoard()
        {
            
            var loadImagesTask = new Task<Dictionary<Players, Dictionary<PieceTypes, Image>>>(loadImages);
            var createBoardTask = new Task<Button[,]>(createBoard);

            loadImagesTask.Start();
            createBoardTask.Start();

            pieceImages = await loadImagesTask;
            board = await createBoardTask;

            disposeBoard();
            startNewGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void newGameOption_Click(object sender, EventArgs e)
        {
            startNewGame();
        }
    }
}
