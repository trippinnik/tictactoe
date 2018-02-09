using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Rest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeSDK;
using TicTacToeSDK.Models;

namespace TicTacToeFunctionalTests
{
    [TestClass]
    public class FunctionalTests
    {
        private static string AppUrl { get; set; }
        private static string AppToken { get; set; }

        [ClassInitialize]
        public static void TestClassInitialize(TestContext context)
        {
            AppUrl = context.Properties["AppUrl"] as string;
            AppToken = context.Properties["AppToken"] as string;
        }

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            ServiceClientCredentials serviceClientCredentials = new TokenCredentials(AppToken);
            TicTacToeSDKClient client = new TicTacToeSDKClient(new Uri(AppUrl), serviceClientCredentials);

            // Act 
            GameBoard xWinner = new GameBoard();
            xWinner.GameBoardProperty = new string[] {
                "X",
                "X",
                "X",
                "O",
                "O",
                "?",
                "?",
                "?",
                "?"
            };
            IHttpActionResult result = (client.ApiV1TicTacToeExecutemovePost(xWinner));
            IHttpActionResult executeMoveResponse = result.;
            // Assert
            Assert.IsTrue(result.Winner == "X");
        }
        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            ServiceClientCredentials serviceClientCredentials = new TokenCredentials(AppToken);
            TicTacToeSDKClient client = new TicTacToeSDKClient(new Uri(AppUrl), serviceClientCredentials);

            // Act 
            GameBoard xWinner = new GameBoard();
            xWinner.GameBoardProperty = new string[] {
                "X",
                "X",
                "?",
                "O",
                "O",
                "O",
                "?",
                "?",
                "?"
            };
            IHttpActionResult result = client.HttpClient.ApiV1TicTacToePost(xWinner);

            // Assert
            Assert.IsTrue(result.Winner == "O");
        }
        [TestMethod]
        public void TestMethod3()
        {
            // Arrange
            ServiceClientCredentials serviceClientCredentials = new TokenCredentials(AppToken);
            TicTacToeSDKClient client = new TicTacToeSDKClient(new Uri(AppUrl), serviceClientCredentials);

            // Act 
            GameBoard xWinner = new GameBoard();
            xWinner.GameBoardProperty = new string[] {
                "X",
                "X",
                "O",
                "O",
                "O",
                "X",
                "X",
                "O",
                "X"
            };
            IHttpActionResult result = client.ApiV1TicTacToePost(xWinner);

            // Assert
            Assert.IsTrue(result.Winner == "tie");
        }

        [TestMethod]
        public void TestMethod4()
        {
            // Arrange
            ServiceClientCredentials serviceClientCredentials = new TokenCredentials(AppToken);
            TicTacToeSDKClient client = new TicTacToeSDKClient(new Uri(AppUrl), serviceClientCredentials);

            // Act 
            GameBoard xWinner = new GameBoard();
            xWinner.GameBoardProperty = new string[] {
                "?",
                "X",
                "O",
                "O",
                "O",
                "X",
                "X",
                "?",
                "?"
            };
            IHttpActionResult result = client.ApiV1TicTacToePost(xWinner);

            // Assert
            Assert.IsTrue(result.Winner == "inconclussive");
        }
        [TestMethod]
        public void TestMethod5()
        {
            // Arrange
            ServiceClientCredentials serviceClientCredentials = new TokenCredentials(AppToken);
            TicTacToeSDKClient client = new TicTacToeSDKClient(new Uri(AppUrl), serviceClientCredentials);

            // Act 
            GameBoard xWinner = new GameBoard();
            xWinner.GameBoardProperty = new string[] {
                "?",
                "?",
                "?",
                "?",
                "?",
                "?",
                "?",
                "?",
                "?"
            };
            IHttpActionResult result = client.ApiV1TicTacToePost(xWinner);

            // Assert
            Assert.IsTrue(result.AzurePlayerSymbol == "X");
        }
        [TestMethod]
        public void TestMethod6()
        {
            // Arrange
            ServiceClientCredentials serviceClientCredentials = new TokenCredentials(AppToken);
            TicTacToeSDKClient client = new TicTacToeSDKClient(new Uri(AppUrl), serviceClientCredentials);

            // Act 
            GameBoard xWinner = new GameBoard();
            xWinner.GameBoardProperty = new string[] {
                "X",
                "?",
                "?",
                "?",
                "?",
                "?",
                "?",
                "?",
                "?"
            };
            IHttpActionResult result = client.ApiV1TicTacToePost(xWinner);

            // Assert
            Assert.IsTrue(result.Winner == "inconclussive");
        }
        [TestMethod]
        public void TestMethod7()
        {
            // Arrange
            ServiceClientCredentials serviceClientCredentials = new TokenCredentials(AppToken);
            TicTacToeSDKClient client = new TicTacToeSDKClient(new Uri(AppUrl), serviceClientCredentials);

            // Act 
            GameBoard xWinner = new GameBoard();
            xWinner.GameBoardProperty = new string[] {
                "!",
                "X",
                "O",
                "O",
                "O",
                "X",
                "X",
                "?",
                "?"
            };
            HttpResponseMessage result = client.ApiV1TicTacToePost(xWinner);

            // Assert
            Assert.IsTrue(result.StatusCode.Equals("400"));
        }
        [TestMethod]
        public void TestMethod8()
        {
            // Arrange
            ServiceClientCredentials serviceClientCredentials = new TokenCredentials(AppToken);
            TicTacToeSDKClient client = new TicTacToeSDKClient(new Uri(AppUrl), serviceClientCredentials);

            // Act 
            GameBoard xWinner = new GameBoard();
            xWinner.GameBoardProperty = new string[] {
                "X",
                "X",
                "O",
                "X",
                "?",
                "?",
                "?",
                "?",
                "?"
            };
            HttpResponseMessage result = client.HttpClient.PostAsync($"{AppUrl}/api/v1/", xWinner.ToString);

            // Assert
            Assert.IsTrue(result.StatusCode.Equals("400"));

        }
    }
}
