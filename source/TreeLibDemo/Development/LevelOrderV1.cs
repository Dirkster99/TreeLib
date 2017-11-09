namespace TTraversalDemo.Development
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TTraversalDemo;

    static class LevelOrderV1
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
        /// <param name="solutionRoot"></param>
        public static void LevelOrderTraversal(Node root)
        {
            Queue<Tuple<int, Node>> queue = new Queue<Tuple<int, Node>>();

            if (root != null)
                queue.Enqueue(new Tuple<int, Node>(0, root));

            while (queue.Count() > 0)
            {
                var queueItem = queue.Dequeue();
                int iLevel = queueItem.Item1;
                Node current = queueItem.Item2;

                Console.WriteLine(string.Format("{0,4} - {1}"
                    , iLevel, current.GetPath()));

                foreach (var item in current.Children)
                    queue.Enqueue(new Tuple<int, Node>(iLevel + 1, item));
            }
        }
    }
}
