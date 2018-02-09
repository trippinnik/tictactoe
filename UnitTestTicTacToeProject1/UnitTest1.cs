using System;
using Microsoft.Rest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestTicTacToeProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ServiceClientCredentials serviceClientCredentials = new TokenCredentials("faketoken");

        }
    }
}
