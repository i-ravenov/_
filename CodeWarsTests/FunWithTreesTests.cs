using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeWars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeWars.DataStructures;
using CodeWars.Solutions;

namespace CodeWarsTests
{
    [TestClass]
    public class FunWithTreesTests
    {
        [TestMethod]
        public void EmptyArrayTest()
        {
            TreeNode expected = null;
            Assert.AreEqual(expected, FunWithTrees.ArrayToTree(new int[] { }));
        }

        [TestMethod]
        public void ArrayWithMultipleElementsTest()
        {
            TreeNode expected = new TreeNode(17, new TreeNode(0, new TreeNode(3), new TreeNode(15)), new TreeNode(-4));
            Assert.AreEqual(expected, FunWithTrees.ArrayToTree(new int[] { 17, 0, -4, 3, 15 }));
        }

        [TestMethod]
        public void ArrayWith13ElementsTest()
        {
            // Arrange
            int[] input = Enumerable.Range(1, 13).ToArray();
            TreeNode expected = new TreeNode(1, 
                new TreeNode(2, 
                    new TreeNode(4, 
                        new TreeNode(8), 
                        new TreeNode(9)), 
                    new TreeNode(5, 
                        new TreeNode(10), 
                        new TreeNode(11))), 
                new TreeNode(3, 
                    new TreeNode(6,
                        new TreeNode(12),
                        new TreeNode(13)), 
                    new TreeNode(7)));

            // Act
            TreeNode result = FunWithTrees.ArrayToTree(input);
            
            // Assert
            Assert.AreEqual(expected, result);
        }

    }
}
