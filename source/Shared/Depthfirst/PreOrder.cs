namespace TreeLib.Depthfirst
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Implements a Generic class that can traverse a tree with tree nodes of type
    /// <typeparamref name="T"/> and supports invoking calls on each node via
    /// Generic method in the Traversal method.
    /// </summary>
    /// <typeparam name="TRESULT"></typeparam>
    /// <typeparam name="T"></typeparam>
    public class PreOrder<TRESULT, T>
    {
        /// <summary>
        /// This code shows the first development version of the PreOrder
        /// traversal algorithm as published by Dave Remy in his 2010 RemLog blog at:
        /// https://blogs.msdn.microsoft.com/daveremy/2010/03/16/non-recursive-post-order-depth-first-traversal-in-c/
        ///
        /// </summary>
        /// <param name="root">This object points at the root of the tree structure.</param>
        /// <param name="children">This Generic method implements a way of enumerating all
        /// childrens for the root or current node in the traversal.</param>
        /// <param name="ret">This object contains result data of the traversal and should
        /// have been initialized by the caller.</param>
        /// <param name="process">This method accepts the current node and the result object
        /// <paramref name="ret"/> as aparameter to the required processing on each node.</param>
        /// <param name="progress">Optional generic method accepts the cuurent node as parameter
        /// and implements a progress indicator.</param>
        /// <param name="exception">Optional generic method accepts the current node <typeparamref name="T"/>
        /// and result object <paramref name="ret"/> as parameter to implement exception handling
        /// for browsing of children.</param>
        public TRESULT Traverse(T root
                               , Func<T, IEnumerable<T>> children
                               , TRESULT ret
                               , Func<TRESULT, T, TRESULT> process
                               , Action<T> progress = null
                               , Func<TRESULT, Exception, T, TRESULT> exception = null
            )
        {
            var stack = new Stack<T>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                if (progress != null)
                    progress(current);

                ret = process(ret, current);         // Process the node

                try
                {
                    var list = children(current).ToArray();

                    for (int i = list.Count() - 1; i >= 0; i--)
                    {
                        stack.Push(list[i]);
                    }
                }
                catch (Exception e)
                {
                    if (exception != null)
                        ret = exception(ret, e, current);  // exception handling
                }
            }

            return ret;
        }
    }
}
