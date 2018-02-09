using System;
using System.Diagnostics;
using tictactoe.Models;

namespace tictactoe.Controllers
{
    /// <summary>
    /// Defines the ExecuteMoveResponse
    /// </summary>
    public class ExecuteMoveResponse : GameBoard
    {
        
        /// <summary>
        /// this is the position the azure api app service choose
        /// </summary>
        /// <value>
        /// value with be the number of the space on the gameboard or null if a tie or winner has occurred
        /// if a winner is not present then the move property shall contain the result after the move is applied
        /// </value>
        public int Move { get; set; }
        /// <summary>
        /// the symbol the azure player takes on. if player moves first and chooses O or azure moves first Azure shall be X
        /// </summary>
        /// <value>
        /// string X or O
        /// </value>
        public string AzurePlayerSymbol { get; set; }
        /// <summary>
        /// indicates if there is a winner, tie or game is to continue
        /// </summary>
        /// <value>
        /// X, O, inconclussive (game is ongoing) or tie (all positions filled and no winner)
        /// </value>
        public string Winner { get; set; }
        /// <summary>
        /// array containing the winning positions
        /// </summary>
        /// <value>
        /// array of int with 3 positions
        /// </value>
        public int?[] WinnerPositions { get; set; }
        /// <summary>
        /// Our game logic. Takes the post data. Applies logic. Returns the response
        /// </summary>
        /// <param name="gameBoard">Send a gameboard</param>
        /// 
        /// <returns></returns>
        public ExecuteMoveResponse ExecuteMove(GameBoard gameBoard)
        {
            this.CheckAzurePlayer(gameBoard);
            var wHolder = CheckWinner(gameBoard.gameBoard);
            this.Winner = wHolder.Item1;
            this.WinnerPositions = wHolder.Item2;
            this.gameBoard = gameBoard.gameBoard;
            if (this.Winner == "inconclussive")
            { 
                this.Move = GenerateMove(gameBoard);

                try
                {
                    this.gameBoard[Move] = AzurePlayerSymbol;

                }
                //catch for move is invalid
                catch (IndexOutOfRangeException e)
                {
                    Debug.Write(e, "something bad happened and MOVE was invalid: ");
                 }
                var holder = CheckWinner(this.gameBoard);
                this.Winner = wHolder.Item1;
                this.WinnerPositions = wHolder.Item2;
            }
            return this;
            
        }   
        /// <summary>
        /// check for winner. takes the gameboard
        /// </summary>
        protected (string, int?[]) CheckWinner(string[] gameBoard)
        {
            
            for (int i = 0; i < gameBoard.Length; i += 3) {
                if (gameBoard[i] == gameBoard[i+1] && gameBoard[i] == gameBoard[i + 2] && gameBoard[i] != "?")
                {
                    return (gameBoard[i], new int?[] { i, i + 1, i + 2 });
                    //Winner = gameBoard[i];
                    //WinnerPositions = new int?[] { i, i + 1, i + 2 };
                    //break;
                }
             }
            for (int i = 0; i < 3; i ++)
            {
                if (gameBoard[i] == gameBoard[i + 3] && gameBoard[i] == gameBoard[i + 6] && gameBoard[i] != "?")
                {
                    return (gameBoard[i], new int?[] { i, i + 3, i + 6 });
                    //Winner = gameBoard[i];
                    //WinnerPositions = new int?[] { i, i + 3, i + 6 };
                    //break;
                }
            }
            if(gameBoard[0] == gameBoard[4] && gameBoard[0] == gameBoard[8] && gameBoard[0] != "?")
            {
                return (gameBoard[0], new int?[] { 0, 4, 8 });
               // Winner = gameBoard[0];
                //WinnerPositions = new int?[] { 0, 4, 8 };
                
            }
            else if (gameBoard[2] == gameBoard[4] && gameBoard[0] == gameBoard[6] && gameBoard[0] != "?")
            {
                return (gameBoard[2], new int?[] { 0, 4, 6 });
                //Winner = gameBoard[2];
                //WinnerPositions = new int?[] { 2, 4, 6 };
            }
            else if(Array.IndexOf(gameBoard,"?") == 0)
            {
                return ("tie", null);
                //Winner = "tie";
                //WinnerPositions = null;
            }
            else
            {
                return ("inconclussive", null);
                //Winner = "inconclussive";
                //WinnerPositions = null;
            }

        }
        /// <summary>
        /// Receive the gameboard positions apply logic to determine the aZurePlayerSymbol
        /// </summary>
        /// <param name="gameBoard"></param>
        protected void CheckAzurePlayer(GameBoard gameBoard)
        {
            int xCount = 0;
            int oCount = 0;
            int qCount = 0;
            //count each type of position
            for (int i = 0; i < gameBoard.gameBoard.Length; i++)
            {
                if (gameBoard.gameBoard[i].ToUpper().Equals("X")){
                    xCount++;
                }
                else if (gameBoard.gameBoard[i].ToUpper().Equals("O")){
                    oCount++;
                }
                else
                {
                    qCount++;
                }
            }
            //if azure goes first or caller goes first and chooses O
            if (qCount == 9 || (oCount == 1 && xCount == 0))
            {
                AzurePlayerSymbol = "X";
            }
            //if azure goes second or if caller when first and chose X
            else if (xCount == 1 && oCount == 0)
            {
                AzurePlayerSymbol = "O";
            }
            //if azure went first
            else if (xCount == oCount)
            {
                AzurePlayerSymbol = "X";
            }
            //if azure goes second and there are more X, caller chose X
            else if (xCount > oCount)
            {
                AzurePlayerSymbol = "O";
            }
            //else azure is X
            else
            {
                AzurePlayerSymbol = "X";
            }


        }
        /// <summary>
        /// Generate some logic to place the piece
        /// </summary>
        /// <param name="gameBoard"></param>
        protected int GenerateMove(GameBoard gameBoard)
        {
            GameBoard possibleGameBoard = gameBoard;

            //loop through the gameboard 
            for (int i = 0; i < gameBoard.gameBoard.Length; i++)
            {
                //check for a win
                if ((Array.IndexOf(gameBoard.gameBoard, "?")) == i){
                    possibleGameBoard.gameBoard[i] = AzurePlayerSymbol;
                    if(CheckWinner(possibleGameBoard.gameBoard).Item1 == AzurePlayerSymbol)
                    {
                        return i;
                    }
                    //try for two in a row
                    else if ((gameBoard.gameBoard[i + 1] == AzurePlayerSymbol) || (i > 0 && (gameBoard.gameBoard[i-1] == AzurePlayerSymbol) || (i < 6 && gameBoard.gameBoard[i = 3] == AzurePlayerSymbol)))
                    {
                        return i;
                        
                    }
                    //check for diagonal
                    if ((i == 4) && ((gameBoard.gameBoard[0] == AzurePlayerSymbol) || gameBoard.gameBoard[2] == AzurePlayerSymbol) || (gameBoard.gameBoard[6] == AzurePlayerSymbol) || (gameBoard.gameBoard[8] == AzurePlayerSymbol))
                    {
                        return i;
                    }
                                                   



                }
                
               

            }
            //pick a random space
            Random rnd = new Random();
            int r = rnd.Next(8);
            while (r > -1)
            {
                if (gameBoard.gameBoard[r] == AzurePlayerSymbol)
                {
                    return r;
                }
            }
            //error
            return -1;

        }

        
    }
        

    }
