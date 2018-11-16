using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreeLib.Tests
{
    [TestClass]
    public class BinaryTreeLibTest
    {
        [TestMethod]
        public void BinaryTreeWithIntegerInOrderTest()
        {
            int[] numbers = { 15, 18, 1, -3, 11, 12 };
            BinaryTree<int> testTree = new BinaryTree<int>(numbers);
         
            int[] actual = { -3, 1, 11, 12, 15, 18 };
            int i = 0;
            foreach (var item in testTree.Inorder())
            {
                Assert.AreEqual(item, actual[i++]);              
            }
        }

        [TestMethod]
        public void BinaryTreeWithIntegerPreOrderTest()
        {
            int[] numbers = { 15, 18, 1, -3, 11, 12 };
            BinaryTree<int> testTree = new BinaryTree<int>(numbers);

            int[] actual = { 15, 1, -3, 11, 12, 18 };
            int i = 0;
            foreach (var item in testTree.Preorder())
            {
                Assert.AreEqual(item, actual[i++]);
            }
        }

        [TestMethod]
        public void BinaryTreeWithIntegerPostOrderTest()
        {
            int[] numbers = { 15, 18, 1, -3, 11, 12 };
            BinaryTree<int> testTree = new BinaryTree<int>(numbers);

            int[] actual = { 15, -3, 11, 1, 18, 12 };
            int i = 0;
            foreach (var item in testTree.PostOrder())
            {
                Assert.AreEqual(item, actual[i++]);
            }
        }
    }
}
