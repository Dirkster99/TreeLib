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

        private static IEnumerable<T> PostOrderIterator<T>(
              T root
            , Func<T, IEnumerable<T>> children)
        {
            var toVisit = new Stack<IEnumerator<T>>();
            var visitedAncestors = new Stack<T>();

            try
            {
                var it = new List<T> { root }.GetEnumerator();
                toVisit.Push(it);

                while (toVisit.Count > 0)
                {
                    T current = default(T);
                    var node = toVisit.Peek();
                    if (node.MoveNext())
                    {
                        current = node.Current;
                    }
                    else
                    {
                        // otherwise, cleanup the empty enumerator and...
                        node.Dispose();

                        // ...search up the stack for an enumerator with elements left
                        while (true)
                        {
                            if (toVisit.Count == 0)
                            {
                                // we didn't find one, so we're all done
                                yield break;
                            }

                            // consider the next enumerator on the stack
                            var topEnumerator = toVisit.Peek();
                            if (topEnumerator.MoveNext())
                            {
                                // if it has an element, use it
                                current = topEnumerator.Current;
                                //break;
                            }
                            else
                            {
                                // otherwise discard it
                                toVisit.Pop().Dispose();

                                if (visitedAncestors.Count() > 0)
                                {
                                    current = visitedAncestors.Pop();
                                    yield return current;
                                }
                                else
                                    yield break; // Done Done :-)
                            }
                        }
                    }

                    if (children(current).FirstOrDefault() != null)
                    {
                        if (current.Equals(PeekOrDefault1(visitedAncestors)) == false)
                        {
                            visitedAncestors.Push(current);
                            PushNonReverse(toVisit, children(current));
                            continue;
                        }

                        visitedAncestors.Pop();
                    }

                    //System.Console.WriteLine(node.GetStackPath());     // Process the node
                    yield return current;

                    //toVisit.Pop();
                    node = toVisit.Peek();
                    if (node.MoveNext())
                    {
                        current = node.Current;
                        yield return current;
                    }
                    else
                    {
                        node = toVisit.Pop();
                        // otherwise, cleanup the empty enumerator and...
                        node.Dispose();

                        // ...search up the stack for an enumerator with elements left
                        while (true)
                        {
                            if (toVisit.Count == 0)
                            {
                                // we didn't find one, so we're all done
                                yield break;
                            }

                            // consider the next enumerator on the stack
                            var topEnumerator = toVisit.Peek();

                            current = topEnumerator.Current;
                            visitedAncestors.Pop();
                            yield return current;

                            if (topEnumerator.MoveNext())
                            {
                                // if it has an element, use it
                                current = topEnumerator.Current;

                                if (children(current).FirstOrDefault() != null)
                                {
                                    if (current.Equals(PeekOrDefault1(visitedAncestors)) == false)
                                    {
                                        visitedAncestors.Push(current);
                                        PushNonReverse(toVisit, children(current));
                                        break;
                                    }                                  
                                }

                                yield return current;
                            }
                            else
                            {
                                // otherwise discard it
                                toVisit.Pop().Dispose();
                            }
                        }
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
        /// Push all children of a given node in reverse order into the
        /// <seealso cref="Stack{T}"/> <paramref name="s"/>.
        /// 
        /// Use this to traverse the tree from left to right.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="list"></param>
        private static void PushReverse<T>(Stack<IEnumerator<T>> s, IEnumerable<T> list)
        {
            s.Push(list.ToArray().Reverse().GetEnumerator());
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
