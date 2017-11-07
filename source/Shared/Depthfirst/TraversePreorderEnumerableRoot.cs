namespace TreeLib.Depthfirst
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Code is based on this source:
    /// http://www.codeducky.org/easy-tree-and-linked-list-traversal-in-c/
    /// https://github.com/madelson/MedallionUtilities/blob/master/MedallionCollections/Traverse.cs
    /// by Mike Adelson
    /// </summary>
    public partial class Traverse
    {
        /// <summary>
        /// Provides a Generic implementaion for a Preorder (DepthFirst) tree
        /// traversal algorithm, which can be used to traverse a n-ary tree
        /// via foreach(var item in collection){ ... }
        /// 
        /// This method expects a tree with multiple root nodes
        /// (e.g. Explorer in Windows).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="children"></param>
        /// <returns></returns>
        public static IEnumerable<T> Preorder<T>(
            IEnumerator<T> root
          , Func<T, IEnumerable<T>> children)
        {
            if (children == null)
                throw new ArgumentNullException(nameof(children));

            return PreorderIterator(root, children);
        }

        private static IEnumerable<T> PreorderIterator<T>(
            IEnumerator<T> root
          , Func<T, IEnumerable<T>> children)
        {
            T current = default(T);
            var stack = new Stack<IEnumerator<T>>();
            stack.Push(root);

            if (root.MoveNext())
                current = root.Current;
            else
                yield break;    // Got empty IEnumerable<T> here

            try
            {
                while (true)
                {
                    yield return current;

                    var childrenEnumerator = children(current).GetEnumerator();
                    if (childrenEnumerator.MoveNext())
                    {
                        // if we have children, the first child is our next current
                        // and push the new enumerator
                        current = childrenEnumerator.Current;
                        stack.Push(childrenEnumerator);
                    }
                    else
                    {
                        // otherwise, cleanup the empty enumerator and...
                        childrenEnumerator.Dispose();

                        // ...search up the stack for an enumerator with elements left
                        while (true)
                        {
                            if (stack.Count == 0)
                            {
                                // we didn't find one, so we're all done
                                yield break;
                            }

                            // consider the next enumerator on the stack
                            var topEnumerator = stack.Peek();
                            if (topEnumerator.MoveNext())
                            {
                                // if it has an element, use it
                                current = topEnumerator.Current;
                                break;
                            }
                            else
                            {
                                // otherwise discard it
                                stack.Pop().Dispose();
                            }
                        }
                    }
                }
            }
            finally
            {
                // guarantee that everything is cleaned up even
                // if we don't enumerate all the way through
                while (stack.Count > 0)
                {
                    stack.Pop().Dispose();
                }
            }
        }
    }
}
