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
            instance.DoWork();

            // Assert
            Assert.AreEqual(true, true);
        }

        [TestMethod()]
        public void UpdateWithBeginTransactionTests()
        {
            // Arrange
            var instance = new TransactionSample2();
            var pbObj = new PrivateObject(instance);

            // Act
            pbObj.Invoke("UpdateWithBeginTransaction");

            // Assert
            Assert.AreEqual(true, true);
        }
    }
}