﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace TicTacToeSDK
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Models;

    /// <summary>
    /// Extension methods for TicTacToeSDKClient.
    /// </summary>
    public static partial class TicTacToeSDKClientExtensions
    {
            /// <summary>
            /// the post method for the execute which returns the gameboard and
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='receivedGameboard'>
            /// </param>
            public static object ApiV1TicTacToeExecutemovePost(this ITicTacToeSDKClient operations, GameBoard receivedGameboard = default(GameBoard))
            {
                return Task.Factory.StartNew(s => ((ITicTacToeSDKClient)s).ApiV1TicTacToeExecutemovePostAsync(receivedGameboard), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// the post method for the execute which returns the gameboard and
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='receivedGameboard'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> ApiV1TicTacToeExecutemovePostAsync(this ITicTacToeSDKClient operations, GameBoard receivedGameboard = default(GameBoard), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiV1TicTacToeExecutemovePostWithHttpMessagesAsync(receivedGameboard, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}