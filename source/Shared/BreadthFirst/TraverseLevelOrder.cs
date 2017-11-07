namespace TreeLib.BreadthFirst
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TreeLib.Models;

    /// <summary>
    /// http://urosv.blogspot.de/2011/04/iterative-binary-tree-traversal.html
    /// C/C++ Blog Post by: Uros Vidojevic
    ///
    /// Levelorder traversal implementation is very similar
    /// to the preorder implementation, with the most significant difference
    /// that now the <seealso cref="Queue{T}"/> is used instead of a
    /// <seealso cref="Stack{T}"/>.
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
        ///
        /// Levelorder traversal implementation is very similar
        /// to the preorder implementation, with the most significant difference
        /// that now the <seealso cref="Queue{T}"/> is used instead of a
        /// <seealso cref="Stack{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="children"></param>
        /// <returns></returns>
        public static IEnumerable<LevelOrderCursor<T>> LevelOrder<T>(
            T root
          , Func<T, IEnumerable<T>> children)
        {
            if (children == null)
                throw new ArgumentNullException(nameof(children));

            return LevelOrderIterator(root, children);
        }

        private static IEnumerable<LevelOrderCursor<T>> LevelOrderIterator<T>(
              T root
            , Func<T, IEnumerable<T>> children)
        {
            int iLevel = 0;
            var current = new Tuple<int, T>(iLevel++, root);
            Queue<Tuple<int, IEnumerator<T>>> queue = new Queue<Tuple<int, IEnumerator<T>>>();

            if (current != null)
                queue.Enqueue(new Tuple<int, IEnumerator<T>>(current.Item1, new List<T>{ current.Item2}.GetEnumerator()));

            try
            {
                while (queue.Count > 0)
                {
                    var queueIt = queue.Dequeue();
                    while (queueIt.Item2.MoveNext())
                    {
                        var queueItem = queueIt.Item2.Current;
                        yield return new LevelOrderCursor<T>(queueIt.Item1, queueItem);

                        if (children(queueItem).FirstOrDefault() != null)
                            queue.Enqueue(new Tuple<int, IEnumerator<T>>(iLevel, children(queueItem).GetEnumerator()));
                    }

                    iLevel++;
                    continue;
                }
            }
            finally
            {
                // guarantee that everything is cleaned up even
                // if we don't enumerate all the way through
                while (queue.Count > 0)
                {
                    queue.Dequeue().Item2.Dispose();
                }
            }
        }
    }
}
