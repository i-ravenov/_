using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeWars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarsTests
{
    [TestClass]
    public class PartDictionaryTests
    {
        [TestMethod]
        public void PartitionForSmallValueTest()
        {
            // Arrange
            PartDictionary d = new PartDictionary(4);

            // Act
            ISet<Partition> parts = d[4];

            // Assert
            Assert.IsTrue(parts.Count == 5);
        }

        [TestMethod]
        public void PartitionForLargeValueTest()
        {
            // Arrange
            PartDictionary d = new PartDictionary(40);

            // Act
            ISet<Partition> parts = d[40];

            // Assert
            Assert.IsTrue(parts.Count == 37338);
        }
    }
}