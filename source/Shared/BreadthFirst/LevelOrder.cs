namespace TreeLib.BreadthFirst
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// Implements a Generic class that can traverse a tree with tree nodes of type
    /// <typeparamref name="T"/> and supports invoking calls on each node via
    /// Generic method in the Traversal method.
    /// </summary>
    /// <typeparam name="TRESULT"></typeparam>
    /// <typeparam name="T"></typeparam>
    public class LevelOrder<TRESULT, T>
    {
        /// <summary>
        /// http://urosv.blogspot.de/2011/04/iterative-binary-tree-traversal.html
        /// C/C++ Blog Post by: Uros Vidojevic
        ///
        /// Levelorder traversal implementation is very similar
        /// to the preorder implementation, with the most significant difference
        /// that the <seealso cref="Queue{T}"/> is used instead of a
        /// <seealso cref="Stack{T}"/>.
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
            Queue<Tuple<int, T>> queue = new Queue<Tuple<int, T>>();

            if (root != null)
                queue.Enqueue(new Tuple<int, T>(0, root));

            while (queue.Count() > 0)
            {
                var queueItem = queue.Dequeue();
                int iLevel = queueItem.Item1;
                T current = queueItem.Item2;

                if (progress != null)
                  progress(current);

                ret = process(ret, current);           // Process the node

                try
                {
                    foreach (var item in children(current))
                        queue.Enqueue(new Tuple<int, T>(iLevel + 1, item));
                }
                catch (Exception e)
                {
                    if (exception != null)
                        ret = exception(ret, e, current);  // print a simple progress indicator
                }
            }

            return ret;
        }
    }
}
