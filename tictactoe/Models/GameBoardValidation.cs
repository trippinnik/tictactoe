using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tictactoe.Models
{
    /// <summary>
    /// Validation of the gameboard
    /// must contain length string array 9
    /// only X, O or ?
    /// X and O must stay within turn rotation in numberg
    /// </summary>
    public class GameBoardValidation : GameBoard
    {
        /// <summary>
        /// Returns bool for verification of the gameboard post data
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            int xCount = 0;
            int oCount = 0;
            
            if (this.gameBoard.Length != 9)
            {
                ErrorMessage = "The gameboard is not the correct size. It must hold 9 positions. The length received was: " + this.gameBoard.Length;
                return false;
            }
            foreach (var key in this.gameBoard)
            {
                if (key != "O" || key != "X" || key != "?")
                {
                    ErrorMessage = "The gameBoard includes invalid characters.";
                    return false;
                }
                else if(key == "O")
                {
                    oCount++;
                }
                else if(key == "X")
                {
                    xCount++;
                }
            }
            //validate count of x or o are within 1 of each other
            if (xCount != oCount || xCount+1 != oCount || xCount -1 != oCount)
            {
                ErrorMessage = "One of the players has been going out of turn? The number of moves on the board is invalid";
                return false;
            }
            return true;
        }
        /// <summary>
        /// Holds a string for error message to be returned when post data does not match the schema
        /// </summary>
        public string ErrorMessage { get; set; }

    }
}
