namespace TreeLib.Depthfirst
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Developed out of the combined posts
    /// 1) Published by Dave Remy in his 2010 RemLog blog at:
    ///    https://blogs.msdn.microsoft.com/daveremy/2010/03/16/non-recursive-post-order-depth-first-traversal-in-c/
    ///
    /// 2) With the "Generic Tree and Linked List Traversal in C#" post by Mike Adelson
    ///    http://www.codeducky.org/easy-tree-and-linked-list-traversal-in-c/
    /// 
    /// http://www.codeducky.org/easy-tree-and-linked-list-traversal-in-c/
    /// https://github.com/madelson/MedallionUtilities/blob/master/MedallionCollections/Traverse.cs
    /// by Mike Adelson
    /// </summary>
    public partial class Traverse
    {
        /// <summary>
        /// Provides a Generic implementaion for a DepthFirst (Pre-Order)
        /// Traversal algorithm, which can be used to traverse a n-ary tree
        /// via foreach(var item in collection){ ... }
        /// 
        /// This method expects a tree with one root node
        /// (e.g. Explorer in Windows).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="children"></param>
        /// <returns></returns>
        public static IEnumerable<T> PostOrder<T>(
            T root
          , Func<T, IEnumerable<T>> children)
        {
            if (children == null)
                throw new ArgumentNullException(nameof(children));

            return PostOrderIterator(root, children);
        }

        class VisitElement<T> : IDisposable
        {
            #region fields
            private T _Element;
            private IEnumerator<T> _EnumerateChildren;
            private bool _disposed;
            #endregion fields

            #region ctors
            /// <summary>
            /// Class constructor
            /// </summary>
            /// <param name="element"></param>
            /// <param name="enumerateChildren"></param>
            public VisitElement(T element, IEnumerator<T> enumerateChildren)
                : this()
            {
                _Element = element;
                _EnumerateChildren = enumerateChildren;
            }

            /// <summary>
            /// Hidden class constructor
            /// </summary>
            protected VisitElement()
            {
            }
            #endregion ctors

            #region properties
            /// <summary>
            /// Gets whether the children of this element have already been visited or not.
            /// </summary>
            public bool ChildrenVisited { get; protected set; }

            /// <summary>
            /// Gets whether this element has already been visited or not.
            /// </summary>
            public bool ThisElementVisited { get; protected set; }

            /// <summary>
            /// Gets the Element for this node or null if this is the root.
            /// </summary>
            public T Element { get { return _Element; } }
            #endregion properties

            #region methods
            /// <summary>
            /// Gets the next available child or null (if all children have been enumerated).
            /// </summary>
            /// <returns></returns>
            public T GetNextChild()
            {
                if (_EnumerateChildren != null)
                {
                    if (_EnumerateChildren.MoveNext())
                        return _EnumerateChildren.Current;
                }

                ChildrenVisited = true;
                return default(T);
            }

            /// <summary>
            /// Marks this element as having been visited.
            /// </summary>
            public void SetThisElementVisited()
            {
                ThisElementVisited = true;
            }

            #region Disposable Interfaces
            /// <summary>
            /// Standard dispose method of the <seealso cref="IDisposable" /> interface.
            /// </summary>
            public void Dispose()
            {
                Dispose(true);
            }

            /// <summary>
            /// Source: http://www.codeproject.com/Articles/15360/Implementing-IDisposable-and-the-Dispose-Pattern-P
            /// </summary>
            /// <param name="disposing"></param>
            protected void Dispose(bool disposing)
            {
                if (_disposed == false)
                {
                    if (disposing == true)
                    {
                        // Dispose of the curently displayed content if it is disposable
                        if (_EnumerateChildren != null)
                        {
                            _EnumerateChildren.Dispose();
                            _EnumerateChildren = null;
                        }
                    }

                    // There are no unmanaged resources to release, but
                    // if we add them, they need to be released here.
                }

                _disposed = true;

                //// If it is available, make the call to the
                //// base class's Dispose(Boolean) method
                ////base.Dispose(disposing);
            }
            #endregion Disposable Interfaces
            #endregion methods
        }

        private static IEnumerable<T> PostOrderIterator<T>(
              T root
            , Func<T, IEnumerable<T>> children)
        {
            var toVisit = new Stack<VisitElement<T>>();

            try
            {
                var it = new List<T> { root }.GetEnumerator();
                var element = new VisitElement<T>(default(T), it);
                toVisit.Push(element);

                while (toVisit.Count > 0)
                {
                    var node = toVisit.Peek();

                    if (node.ChildrenVisited == false)
                    {
                        var child = node.GetNextChild();
                        if (child == null)
                        {
                            // Is this a non-root element?
                            if (node.Element != null)
                            {
                                node.SetThisElementVisited();
                                yield return node.Element;
                            }
                            else
                                yield break;

                            continue;
                        }
                        else
                        {
                            // Put this child on the stack and continue to dive down
                            element = new VisitElement<T>(child, children(child).GetEnumerator());
                            toVisit.Push(element);
                            continue;
                        }
                    }
                    else
                    {
                        if (node.ThisElementVisited == false)
                        {
                            // Is this a non-root element?
                            if (node.Element != null)
                            {
                                node.SetThisElementVisited();
                                yield return node.Element;
                            }
                            else
                                yield break;

                            continue;
                        }
                        else               // This node and its children have been visited
                            toVisit.Pop();
                    }
                }
            }
            finally
            {
                // guarantee that everything is cleaned up even
                // if we don't enumerate all the way through
                while (toVisit.Count > 0)
                {
                    toVisit.Pop().Dispose();
                }
            }
        }

        /// <summary>
        /// Return the top element of stack or null if the Stack is empty.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static T PeekOrDefault1<T>(Stack<T> s)
        {
            return s.Count == 0 ? default(T) : s.Peek();
        }

        /// <summary>
        /// Push all children of a given node in givrn order into the
        /// <seealso cref="Stack{T}"/> <paramref name="s"/>.
        /// 
        /// Use this to traverse the tree from right to left.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="list"></param>
        private static void PushNonReverse<T>(Stack<IEnumerator<T>> s, IEnumerable<T> list)
        {
            s.Push(list.GetEnumerator());
        }
    }
}
