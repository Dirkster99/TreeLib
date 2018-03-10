namespace TreeLibDemoLib.Development
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This code shows the first development version of the PostOrder
    /// traversal algorithm as published by Dave Remy in his 2010 RemLog blog at:
    /// https://blogs.msdn.microsoft.com/daveremy/2010/03/16/non-recursive-post-order-depth-first-traversal-in-c/
    /// </summary>
    public static class PostOrderV1
    {
        public static List<Node> Traverse(Node root)
        {
            List<Node> ret = new List<Node>();
            var toVisit = new Stack<Node>();
            var visitedAncestors = new Stack<Node>();

            toVisit.Push(root);
            while (toVisit.Count > 0)
            {
                var current = toVisit.Peek();
                if (current.Children.Count > 0)
                {
                    if (PeekOrDefault(visitedAncestors) != current)
                    {
                        visitedAncestors.Push(current);
                        PushReverse(toVisit, current.Children);
                        continue;
                    }

                    visitedAncestors.Pop();
                }

                ret.Add(current);
                System.Console.WriteLine(current.GetPath());     // Process the node
                toVisit.Pop();
            }

            return ret;
        }

        /// <summary>
        /// Return the top element of stack or null if the Stack is empty.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static Node PeekOrDefault(Stack<Node> s)
        {
            return s.Count == 0 ? null : s.Peek();
        }

        /// <summary>
        /// Push all children of a given node in reverse order into the
        /// <seealso cref="Stack{T}"/> <paramref name="s"/>.
        /// 
        /// Use this to traverse the tree from left to right.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="list"></param>
        private static void PushReverse(Stack<Node> s, List<Node> list)
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
        private static void PushNonReverse(this Stack<Node> s, List<Node> list)
        {
            foreach (var l in list.ToArray())
            {
                s.Push(l);
            }
        }
    }
}
