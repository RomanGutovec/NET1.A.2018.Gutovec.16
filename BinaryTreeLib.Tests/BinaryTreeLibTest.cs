using System;
using System.Linq;
using BinaryTreeLib.Tests.Helpers;
using NUnit.Framework;

namespace BinaryTreeLib.Tests
{
    [TestFixture]
    public class BinaryTreeLibTest
    {
        [Test]
        public void BinaryTreeWithIntegerInOrderTest()
        {
            int[] numbers = { 15, 18, 1, -3, 11, 12 };
            BinaryTree<int> testTree = new BinaryTree<int>(numbers);

            int[] expected = { -3, 1, 11, 12, 15, 18 };
            int i = 0;
            foreach (var item in testTree.Inorder())
            {
                Assert.AreEqual(expected[i++], item);
            }
        }

        [Test]
        public void BinaryTreeWithIntegerPreOrderTest()
        {
            int[] numbers = { 15, 18, 1, -3, 11, 12 };
            BinaryTree<int> testTree = new BinaryTree<int>(numbers);

            int[] expected = { 15, 1, -3, 11, 12, 18 };
            int i = 0;
            foreach (var item in testTree.Preorder())
            {
                Assert.AreEqual(expected[i++], item);
            }
        }

        [Test]
        public void BinaryTreeWithIntegerPostOrderTest()
        {
            int[] numbers = { 15, 18, 1, -3, 11, 12 };
            BinaryTree<int> testTree = new BinaryTree<int>(numbers);

            int[] expected = { -3, 1, 11, 12, 18, 15 };
            int i = 0;
            foreach (var item in testTree.PostOrder())
            {
                Assert.AreEqual(expected[i++], item);
            }
        }

        [Test]
        public void BinaryTreeWithStringTest()
        {
            string[] strings = { "ABCD", "AB", "A", "ABCDE", "ABCDEF" };
            BinaryTree<string> testTree = new BinaryTree<string>(strings);

            string[] expected = { "A", "AB", "ABCDE", "ABCDEF", "ABCD" };
            int i = 0;
            foreach (var item in testTree.PostOrder())
            {
                Assert.AreEqual(expected[i++], item);
            }
        }

        [Test]
        public void BinaryTreeWithStringTestCompareByLength()
        {
            string[] strings = { "AA", "BBB", "C", "DDDD" };
            Comparison<string> comparison = (x, y) => x.Length - y.Length;
            BinaryTree<string> testTree = new BinaryTree<string>(strings, comparison);

            string[] expected = { "C", "BBB", "DDDD", "AA" };
            int i = 0;
            foreach (var item in testTree.PostOrder())
            {
                Assert.AreEqual(expected[i++], item);
            }
        }

        [Test]
        public void BookBinaryTreeTest_AssertsExpectedAmountPages()
        {
            Book book = new Book("Via C#", "Richter", 689);
            Book secondBook = new Book("C#", "Richter", 690);
            Book thirdBook = new Book("Simple C#", "Richter", 680);

            Book[] books = { book, secondBook, thirdBook };

            BinaryTree<Book> testTree = new BinaryTree<Book>(books);
            Book[] expectedBooks = { book, thirdBook, secondBook };
            int i = 0;
            foreach (var element in testTree)
            {
                Assert.AreEqual(expectedBooks[i].PagesAmount, books[i].PagesAmount);
            }
        }

        [Test]
        public void BookBinaryTreeTestWithComparisonByAmountPages_AssertsExpectedAmountPages()
        {
            Book book = new Book("Via C#", "Richter", 689);
            Book secondBook = new Book("C#", "Richter", 690);
            Book thirdBook = new Book("Simple", "Richter", 680);

            Book[] books = { book, secondBook, thirdBook };
            Comparison<Book> comparison = (x, y) => x.PagesAmount - y.PagesAmount;
            BinaryTree<Book> testTree = new BinaryTree<Book>(books, comparison);
            Book[] expectedBooks = { book, thirdBook, secondBook };
            int i = 0;
            foreach (var element in testTree)
            {
                Assert.AreEqual(expectedBooks[i].PagesAmount, books[i].PagesAmount);
            }
        }

        [Test]
        public void PointBinaryTreeTest_ThrowsArgumentException()
            => Assert.Throws<ArgumentException>(() =>
             {
                 Point point = new Point(2, 5);
                 Point secondPoint = new Point(4, 4);
                 Point thirdPoint = new Point(0, 0);

                 Point[] pointActual = { point, secondPoint, thirdPoint };

                 BinaryTree<Point> testTree = new BinaryTree<Point>(pointActual);
                 Point[] expectedPoints = { point, thirdPoint, secondPoint };
             });

        [Test]
        public void PointBinaryTreeTestWithComparison_CompareByYValue_TreeIncludeItElement()
        {
            Point point = new Point(2, 5);
            Point secondPoint = new Point(4, 0);
            Point thirdPoint = new Point(0, 4);

            Point[] pointActual = { point, secondPoint, thirdPoint };

            Comparison<Point> comparison = (x, y) => x.x - y.x;
            BinaryTree<Point> testTree = new BinaryTree<Point>(pointActual, comparison);
            Point[] expectedPoints = { thirdPoint, point, secondPoint };

            Assert.IsTrue(testTree.Contains(thirdPoint));
        }
    }
}
