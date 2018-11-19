using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTreeLib
{
    /// <summary>
    /// Represents binary tree class
    /// </summary>
    /// <typeparam name="T">type of the parameter which must put in the tree</typeparam>
    public class BinaryTree<T> : IEnumerable<T>
    {
        private Node<T> root;
        private Comparison<T> comparison;

        #region Constructors
        /// <summary>
        /// Default constructor
        /// <exception cref="ArgumentException">Thrown when type T not implement IComparable</exception>
        /// </summary>
        public BinaryTree()
        {
            if (!typeof(IComparable<T>).IsAssignableFrom(typeof(T)))
            {
                throw new ArgumentException($"The {typeof(T)} not implement IComparable");
            }

            comparison = Comparer<T>.Default.Compare;
        }

        /// <summary>
        /// Constructor which takes collection for initialization 
        /// </summary>
        /// /// <exception cref="ArgumentException">Thrown when type T not implement IComparable</exception>
        /// <param name="elements">collection for initialization</param>
        public BinaryTree(IEnumerable<T> elements) : this()
        {
            foreach (T element in elements)
            {
                this.Add(element);
            }
        }

        /// <summary>
        /// Constructor which takes collection and condition of comparison for initialization
        /// </summary>
        /// /// <exception cref="ArgumentException">Thrown when type T not implement IComparable</exception>
        /// <exception cref="ArgumentNullException">Thrown when condition to compare is not set</exception>
        /// <param name="elements">collection for initialization</param>
        /// <param name="comparison">condition to compare two elements (return -1 if first less then second, 0 if equals, 1 if second less than first)</param>
        public BinaryTree(IEnumerable<T> elements, Comparison<T> comparison)
        {
            this.comparison = comparison ?? throw new ArgumentNullException($"Comparer {nameof(comparison)} haves null value");
            foreach (T element in elements)
            {
                this.Add(element);
            }
        }

        /// <summary>
        /// Constructor which takes collection and condition of comparison for initialization
        /// </summary>
        /// /// <exception cref="ArgumentException">Thrown when type T not implement IComparable</exception>
        /// <exception cref="ArgumentNullException">Thrown when condition to compare is not set</exception>
        /// <param name="elements">collection for initialization</param>
        /// <param name="comparer">compare two elements</param>
        public BinaryTree(IEnumerable<T> elements, IComparer<T> comparer) : this(elements, comparer.Compare)
        {
        }

        /// <summary>
        /// Constructor which takes collection and condition of comparison for initialization
        /// </summary>
        /// /// <exception cref="ArgumentException">Thrown when type T not implement IComparable</exception>
        /// <exception cref="ArgumentNullException">Thrown when condition to compare is not set</exception>
        /// <param name="elements">collection for initialization</param>
        /// <param name="comparer">compare two elements</param>
        public BinaryTree(IEnumerable<T> elements, Comparer<T> comparer) : this(elements, comparer.Compare)
        {
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Add element to the binary tree
        /// </summary>
        /// <param name="element">element to add</param>
        public void Add(T element)
        {
            Node<T> node = new Node<T>(element);

            if (root == null)
            {
                root = node;
            }
            else
            {
                Node<T> current = root;
                Node<T> parent = null;
                while (current != null)
                {
                    parent = current;
                    if (comparison(element, current.Data) < 0)
                    {
                        current = current.Left;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }

                if (comparison(element, parent.Data) < 0)
                {
                    parent.Left = node;
                }
                else
                {
                    parent.Right = node;
                }
            }
        }

        /// <summary>
        /// Remove element from the binary tree
        /// </summary>
        /// <param name="element">element which must be removed</param>
        public void Remove(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException($"Elemnt {nameof(element)} haves null value");
            }

            Node<T> current = root;
            Node<T> parent = null;
            while (comparison(element, current.Data) != 0)
            {
                if (comparison(element, current.Data) < 0)
                {
                    parent = current;
                    current = current.Left;
                    if (current == null)
                    {
                        break;
                    }
                }
                else
                {
                    parent = current;
                    current = current.Right;
                    if (current == null)
                    {
                        break;
                    }
                }
            }

            if (current.Right == null)
            {
                if (current == root)
                {
                    root = current.Left;
                }
                else
                {
                    if (comparison(current.Data, parent.Data) < 0)
                    {
                        parent.Left = current.Left;
                    }
                    else
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (current == root)
                {
                    root = current.Right;
                }
                else
                {
                    if (comparison(current.Data, parent.Data) < 0)
                    {
                        parent.Left = current.Right;
                    }
                    else
                    {
                        parent.Right = current.Right;
                    }
                }
            }
            else
            {
                Node<T> minElement = current.Right.Left;
                Node<T> previous = current.Right;
                while (minElement.Left != null)
                {
                    previous = minElement;
                    minElement = minElement.Left;
                }

                previous.Left = minElement.Right;
                minElement.Left = current.Left;
                minElement.Right = current.Right;

                if (current == root)
                {
                    root = minElement;
                }
                else
                {
                    if (comparison(current.Data, parent.Data) < 0)
                    {
                        parent.Left = minElement;
                    }
                    else
                    {
                        parent.Right = minElement;
                    }
                }
            }
        }

        /// <summary>
        /// Check belong or not element to the binary tree
        /// </summary>
        /// <param name="element">element to check</param>
        /// <returns></returns>
        public bool Contains(T element)
        {
            Node<T> current = root;
            while (current != null)
            {
                if (comparison(element, current.Left.Data) == 0)
                {
                    return true;
                }

                if (comparison(element, current.Left.Data) < 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            return false;
        }
        
        /// <summary>
        /// Tree traversal (node, left, right)
        /// </summary>
        /// <returns>collection by current traversal</returns>
        public IEnumerable<T> Preorder()
            => Preorder(root);

        /// <summary>
        /// Tree traversal (left, node, right)
        /// </summary>
        /// <returns>collection by current traversal</returns>
        public IEnumerable<T> Inorder()
            => Inorder(root);

        /// <summary>
        /// Tree traversal (left, right, node)
        /// </summary>
        /// <returns>collection by current traversal</returns>
        public IEnumerable<T> PostOrder()
            => Postrder(root);
        #endregion

        #region Enumerators
        /// <summary>
        /// Return enumerator
        /// </summary>
        /// <returns>enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        => Inorder(root).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
         => Inorder(root).GetEnumerator();
        #endregion

#region Private methods
        private IEnumerable<T> Preorder(Node<T> root)
        {
            if (root == null)
            {
                yield break;
            }

            yield return root.Data;
            foreach (var element in Preorder(root.Left))
            {
                yield return element;
            }

            foreach (var element in Preorder(root.Right))
            {
                yield return element;
            }
        }

        private IEnumerable<T> Inorder(Node<T> root)
        {
            if (root == null)
            {
                yield break;
            }

            foreach (var element in Inorder(root.Left))
            {
                yield return element;
            }

            yield return root.Data;
            foreach (var element in Inorder(root.Right))
            {
                yield return element;
            }
        }

        private IEnumerable<T> Postrder(Node<T> root)
        {
            if (root == null)
            {
                yield break;
            }

            foreach (var element in Inorder(root.Left))
            {
                yield return element;
            }

            foreach (var element in Inorder(root.Right))
            {
                yield return element;
            }

            yield return root.Data;
        }
        #endregion

        #region Inner Types
        private class Node<T>
        {
            public Node(T element)
            {
                if (element == null)
                {
                    throw new ArgumentNullException($"Element {nameof(element)} haves null value");
                }

                Data = element;
            }

            public T Data { get; set; }

            public Node<T> Left { get; set; }

            public Node<T> Right { get; set; }
        }
        #endregion
    }
}
