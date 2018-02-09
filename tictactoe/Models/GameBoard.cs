using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tictactoe.Models
{
    /// <summary>
    /// object that will hold an array of strings
    /// </summary>
    public class GameBoard
    {
        /// <summary>
        /// Gameboard and array of strings with 9 slots
        /// 
        /// </summary>
        /// <value>
        /// values may be X, O or ? for empty and length must be 9
        /// </value>
        public string[] gameBoard { get; set; }
       
    }
}
