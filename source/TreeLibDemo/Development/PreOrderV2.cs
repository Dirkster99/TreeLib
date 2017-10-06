namespace TTraversalDemo.Development
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Source:
    /// http://www.codeducky.org/easy-tree-and-linked-list-traversal-in-c/
    /// https://github.com/madelson/MedallionUtilities/blob/master/MedallionCollections/Traverse.cs
    /// by Mike Adelson
    /// 
    /// Provides a fist generic implementation that traverses a tree in (Depth-First)
    /// PreOrder Fashion.
    /// </summary>
    internal static class PreOrderV2
    {
        /// <summary>
        /// Provides a Generic implementaion for a DepthFirst (Pre-Order)
        /// Traversal algorithm, which can be used to traverse a n-ary tree
        /// via foreach(var item in collection){ ... }
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="children"></param>
        /// <returns></returns>
        public static IEnumerable<T> Traverse<T>(T root, Func<T, IEnumerable<T>> children)
        {
            if (children == null)
                throw new ArgumentNullException(nameof(children));

            return TraverseIterator(root, children);
        }

        private static IEnumerable<T> TraverseIterator<T>(T root, Func<T, IEnumerable<T>> children)
        {
            var stack = new Stack<T>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var next = stack.Pop();
                yield return next;

                foreach (var child in children(next).ToArray().Reverse())
                {
                    stack.Push(child);
                }
            }
        }
    }
}
