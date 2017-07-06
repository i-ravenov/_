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
        public void ConcatTwoPartitionsTest()
        {
            // Arrange
            var first = new Partition(new[] { 1, 1, 1, 3 });
            var second = new Partition(new[] { 2, 3, 1 });

            // Act
            var sum = first + second;

            // Assert
            Assert.IsTrue(sum.Length == 7);
        }

        [TestMethod]
        public void DecartCompositionTest()
        {
            // Arrange
            var p1 = new Partition(1);

            // Act
            var composition = Partition.Decart(new HashSet<Partition> {p1}, new HashSet<Partition> { p1 });

            // Assert
            Assert.IsTrue(composition.Count == 1);
            Assert.IsTrue(composition.Contains(new Partition(new []{1, 1})));
        }

        [TestMethod]
        public void DecartCompositionTest2()
        {
            // Arrange 
            var p1 = new Partition(new[] { 1, 1, 1, 3 });
            var p2 = new Partition(new[] { 2, 3, 1 });
            var p3 = new Partition(new[] {2});
            var p4 = new Partition(new [] {3});
            var leftSet = new HashSet<Partition> {p1, p2, p3};
            var rightSet = new HashSet<Partition> {p3, p4};

            // Act
            var composition = Partition.Decart(leftSet, rightSet);

            // Assert
            Assert.IsTrue(composition.Count == 6);
        }
    }
}