using Microsoft.VisualStudio.TestTools.UnitTesting;
using MCP70483cs.Example4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4.Tests
{
    [TestClass()]
    public class TransactionSample2Tests
    {
        [TestMethod()]
        public void DoProcTest()
        {
            // Arrange
            var instance = new TransactionSample2();

            // Act

            // Assert
            Assert.AreEqual(1, 1);
            // Assert.Fail();
        }
    }
}