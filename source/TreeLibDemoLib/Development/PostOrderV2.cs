namespace TreeLibDemoLib.Development
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This code shows the second development version of the PostOrder
    /// traversal algorithm. It combines the code:
    /// 1) Published by Dave Remy in his 2010 RemLog blog at:
    ///    https://blogs.msdn.microsoft.com/daveremy/2010/03/16/non-recursive-post-order-depth-first-traversal-in-c/
    ///
    /// 2) With the "Generic Tree and Linked List Traversal in C#" post by Mike Adelson
    ///    http://www.codeducky.org/easy-tree-and-linked-list-traversal-in-c/
    /// </summary>
    static public class PostOrderV2
    {
        /// <summary>
        /// Provides a Generic implementaion for a DepthFirst (Post-Order)
        /// Traversal algorithm, which can be used to traverse a n-ary tree
        /// via foreach(var item in collection){ ... }
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="children"></param>
        /// <returns></returns>
        public static IEnumerable<T> Traverse<T>(
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
            var toVisit = new Stack<T>();
            var visitedAncestors = new Stack<T>();

            toVisit.Push(root);
            while (toVisit.Count > 0)
            {
                var node = toVisit.Peek();

                if (children(node).FirstOrDefault() != null)
                {
                    if (node.Equals(PeekOrDefault(visitedAncestors)) == false)
                    {
                        visitedAncestors.Push(node);
                        PushReverse(toVisit, children(node));
                        continue;
                    }

                    visitedAncestors.Pop();
                }

                yield return node;      // Process the node
                toVisit.Pop();
            }
        }


        /// <summary>
        /// Return the top element of stack or null if the Stack is empty.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static T PeekOrDefault<T>(Stack<T> s)
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
        private static void PushReverse<T>(Stack<T> s, IEnumerable<T> list)
        {
            foreach (var l in list.ToArray().Reverse())
            {
                s.Push(l);
            }
        }

        /// <summary>
        /// Push all children of a given node in givrn order into the
        /// <seealso cref="Stack{T}"/> <paramref name="s"/>.
        /// 
        /// Use this to traverse the tree from right to left.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="list"></param>
        private static void PushNonReverse<T>(Stack<T> s, IEnumerable<T> list)
        {
            foreach (var l in list.ToArray())
            {
                s.Push(l);
            }
        }
    }
}
