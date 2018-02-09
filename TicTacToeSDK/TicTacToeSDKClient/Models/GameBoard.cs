﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace TicTacToeSDK.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    /// <summary>
    /// object that will hold an array of strings
    /// </summary>
    public partial class GameBoard
    {
        /// <summary>
        /// Initializes a new instance of the GameBoard class.
        /// </summary>
        public GameBoard() { }

        /// <summary>
        /// Initializes a new instance of the GameBoard class.
        /// </summary>
        public GameBoard(IList<string> gameBoardProperty = default(IList<string>))
        {
            GameBoardProperty = gameBoardProperty;
        }

        /// <summary>
        /// Gameboard and array of strings with 9 slots
        /// </summary>
        [JsonProperty(PropertyName = "gameBoard")]
        public IList<string> GameBoardProperty { get; set; }

    }
}
