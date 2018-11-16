using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTreeLib
{
    public class BinaryTree<T> : IEnumerable<T>
    {
        private Node<T> root;
        private Comparison<T> comparison;

        public BinaryTree(IEnumerable<T> elements)
        {
            comparison = Comparer<T>.Default.Compare;
            foreach (T element in elements)
            {
                this.Add(element);
            }
        }

        public BinaryTree(IEnumerable<T> elements, Comparison<T> comparison)
        {
            this.comparison = comparison ?? throw new ArgumentNullException($"Comparer {nameof(comparison)} haves null value");
            foreach (T element in elements)
            {
                this.Add(element);
            }
        }

        public BinaryTree(IEnumerable<T> elements, IComparer<T> comparer) : this(elements, comparer.Compare)
        {
        }

        public BinaryTree(IEnumerable<T> elements, Comparer<T> comparer) : this(elements, comparer.Compare)
        {
        }

        public void Add(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException($"Elemnt {nameof(element)} haves null value");
            }

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

        public IEnumerable<T> Preorder()
            => Preorder(root);

        public IEnumerable<T> Inorder()
            => Inorder(root);

        public IEnumerable<T> PostOrder()
            => Postrder(root);

        public IEnumerator<T> GetEnumerator()
        => Inorder(root).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
         => Inorder(root).GetEnumerator();

        private IEnumerable<T> Preorder(Node<T> root)
        {
            if (root == null)
            {
                yield break;
            }

            yield return root.Data;
            Preorder(root.Left);
            Preorder(root.Right);
        }

        private IEnumerable<T> Inorder(Node<T> root)
        {
            if (root == null)
            {
                yield break;
            }

            Preorder(root.Left);
            yield return root.Data;
            Preorder(root.Right);
        }

        private IEnumerable<T> Postrder(Node<T> root)
        {
            if (root == null)
            {
                yield break;
            }

            Preorder(root.Left);
            Preorder(root.Right);
            yield return root.Data;
        }

        public class Node<T>
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
    }
}
