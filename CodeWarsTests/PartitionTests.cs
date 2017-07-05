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
    public class PartitionTests
    {
        [TestMethod]
        public void AddTwoEqualPartitionsToSetTest()
        {
            // Arrange
            Partition first = new Partition(new []{1,2,3});
            Partition second = new Partition(new []{2,3,1});
            ISet<Partition> set = new HashSet<Partition>();

            // Act
            set.Add(first);
            set.Add(second);

            // Assert
            Assert.IsTrue(set.Count == 1);
        }

        [TestMethod]
        public void AddTwoDifferentPartitionsToSetTest()
        {
            // Arrange
            Partition first = new Partition(new[] { 1, 1, 1, 3 });
            Partition second = new Partition(new[] { 2, 3, 1 });
            ISet<Partition> set = new HashSet<Partition>();

            // Act
            set.Add(first);
            set.Add(second);

            // Assert
            Assert.IsTrue(set.Count == 2);
        }

        [TestMethod]
        public void EqualsTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void GetHashCodeTest()
        {
            Assert.Fail();
        }
    }
}