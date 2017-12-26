using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MCP70483cs.Tests
{
    [TestClass]
    public class ProgramTests
    {
        private PrivateType _target;

        [TestInitialize]
        public void TestInit()
        {
            Console.WriteLine("TestInit");
            // _target = new PrivateType(typeof(Program));
        }

        [TestMethod]
        public void MainTest()
        {
            // Arrange

            // Action
            Program.Main(new string[] { });

            // Assert
            Assert.AreEqual(true, true);
        }
    }
}