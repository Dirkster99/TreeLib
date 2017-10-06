namespace TTraversalDemo.Development
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    static class LevelOrderV2
    {
        /// <summary>
        /// http://urosv.blogspot.de/2011/04/iterative-binary-tree-traversal.html
        /// C/C++ Blog Post by: Uros Vidojevic
        ///
        /// Levelorder traversal implementation is very similar
        /// to the preorder implementation, with the most significant difference
        /// that now the <seealso cref="Queue{T}"/> is used instead of a
        /// <seealso cref="Stack{T}"/>.
        /// </summary>
        /// <param name="solutionRoot"></param>
        public static IEnumerable<Tuple<int, T>> LevelOrderTraversal<T>(
            T root
          , Func<T, IEnumerable<T>> children)
        {
            Queue<Tuple<int, T>> queue = new Queue<Tuple<int, T>>();

            if (root != null)
                queue.Enqueue(new Tuple<int, T>(0, root));

            while (queue.Count() > 0)
            {
                var queueItem = queue.Dequeue();
                int iLevel = queueItem.Item1;
                T current = queueItem.Item2;

                yield return new Tuple<int,T>(iLevel, current) ;

                foreach (var item in children(current))
                    queue.Enqueue(new Tuple<int, T>(iLevel + 1, item));
            }
        }
    }
}
