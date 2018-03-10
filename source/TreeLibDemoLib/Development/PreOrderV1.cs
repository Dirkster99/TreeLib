namespace TreeLibDemoLib.Development
{
    using System.Collections.Generic;

    /// <summary>
    /// Source: http://urosv.blogspot.de/2011/04/iterative-binary-tree-traversal.html
    /// C/C++ Blog Post by: Uros Vidojevic
    ///
    /// Provides a basic sample implementation that traverses a tree in (Depth-First)
    /// PreOrder Fashion.
    /// </summary>
    public static class PreOrderV1
    {
        /// <summary>
        /// Source: http://urosv.blogspot.de/2011/04/iterative-binary-tree-traversal.html
        /// C/C++ Blog Post by: Uros Vidojevic
        ///
        /// </summary>
        /// <param name="root"></param>
        public static List<Node> Traverse(Node root)
        {
            List<Node> ret = new List<Node>();
            var stack = new Stack<Node>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                ret.Add(current);
                System.Console.WriteLine(current.GetPath());     // Process the node

                for (int i = current.Children.Count - 1; i >= 0; i--)
                {
                    stack.Push(current.Children[i]);
                }
            }

            return ret;
        }
    }
}
