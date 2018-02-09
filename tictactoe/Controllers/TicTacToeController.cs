using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Web;
using tictactoe.Models;

namespace tictactoe.Controllers
{
    /// <summary>
    /// Defines methods that implement the tictactoe resource
    /// </summary>
    [Route("api/v1/[controller]/executemove")] //indicating v1
    [Produces("application/json")] // See: https://en.wikipedia.org/wiki/Media_type  
    public class TicTacToe : Controller
    {
        /// <summary>
        /// initialize a new instance of the <see cref="TicTacToe"/> class
        /// </summary>
        public TicTacToe()
        {

        }

        /// <summary>
        /// the post method for the execute which returns the gameboard and 
        /// </summary>
        ///<example>
        ///{
	    ///"gameBoard":[
		///"X",
		///"X",
		///"O",
		///"?",
		///"?",
		///"?",
		///"?",
		///"?",
		///"?"
		///]
    /// }
    /// </example>
    /// Post must be array of string, type gameBoard. Array must be length 9 and strings must be X, O or ?
    // POST api/values
    [ProducesResponseType(typeof(ExecuteMoveResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestResult), (int) HttpStatusCode.BadRequest)]
        [HttpPost()]
        public IActionResult Post([FromBody] GameBoard receivedGameboard)
        {
            //check that the gameboard meets our specs
            GameBoardValidation gameboardValidation = new GameBoardValidation();
            gameboardValidation.gameBoard = receivedGameboard.gameBoard;
            if (gameboardValidation.IsValid())
            {
                ExecuteMoveResponse moveResponse = new ExecuteMoveResponse();
                moveResponse = moveResponse.ExecuteMove(receivedGameboard);
                return new ObjectResult(moveResponse);
            }
            else
            {
                BadRequestResult badRequest = new BadRequestResult();
                return BadRequest(gameboardValidation); //return the validation object that includes error message            
                             
                    
            }
            
            


        }

        
    }
}
    

