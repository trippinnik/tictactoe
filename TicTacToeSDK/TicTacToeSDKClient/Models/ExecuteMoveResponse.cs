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
    /// Defines the ExecuteMoveResponse
    /// </summary>
    public partial class IHttpActionResult
    {
        /// <summary>
        /// Initializes a new instance of the ExecuteMoveResponse class.
        /// </summary>
        public IHttpActionResult() { }

        /// <summary>
        /// Initializes a new instance of the ExecuteMoveResponse class.
        /// </summary>
        public IHttpActionResult(int? move = default(int?), string azurePlayerSymbol = default(string), string winner = default(string), IList<int?> winnerPositions = default(IList<int?>), IList<string> gameBoard = default(IList<string>))
        {
            Move = move;
            AzurePlayerSymbol = azurePlayerSymbol;
            Winner = winner;
            WinnerPositions = winnerPositions;
            GameBoard = gameBoard;
        }

        /// <summary>
        /// this is the position the azure api app service choose
        /// </summary>
        [JsonProperty(PropertyName = "move")]
        public int? Move { get; set; }

        /// <summary>
        /// the symbol the azure player takes on. if player moves first and
        /// chooses O or azure moves first Azure shall be X
        /// </summary>
        [JsonProperty(PropertyName = "azurePlayerSymbol")]
        public string AzurePlayerSymbol { get; set; }

        /// <summary>
        /// indicates if there is a winner, tie or game is to continue
        /// </summary>
        [JsonProperty(PropertyName = "winner")]
        public string Winner { get; set; }

        /// <summary>
        /// array containing the winning positions
        /// </summary>
        [JsonProperty(PropertyName = "winnerPositions")]
        public IList<int?> WinnerPositions { get; set; }

        /// <summary>
        /// Gameboard and array of strings with 9 slots
        /// </summary>
        [JsonProperty(PropertyName = "gameBoard")]
        public IList<string> GameBoard { get; set; }

    }
}