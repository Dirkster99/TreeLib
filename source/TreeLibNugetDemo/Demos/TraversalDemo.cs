namespace TreeLibNugetDemo.Demos
{
    using System;
    using System.Collections.Generic;

    internal class TraversalDemo
    {
        /// <summary>
        /// Demos all 3 Development versions of the LevelOrder Tree Traversal algorithm
        /// in one method.
        /// 
        /// Only the algorithm in the TreeLib library is suppossed to be
        /// final - all other version are kept to understand the principal applied to
        /// arrive at the Generic patterns in the TreeLib library.
        /// </summary>
        /// <param name="root"></param>
        internal static void TestLevelOrder(Node root)
        {
            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX LevelOrder (Breadth-First)
            Console.WriteLine("LevelOrderTraversal Tree Traversal");
            var levorderItems = TreeLib.BreadthFirst.Traverse.LevelOrder(root, i => i.Children);

            foreach (var current in levorderItems)
            {
                Console.WriteLine(string.Format("{0,4} - {1}", current.Level
                                                             , current.Node.GetPath()));
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Demos all 3 Development versions of the PreOrder Tree Traversal algorithm
        /// in one method.
        /// 
        /// Only the algorithm in the TreeLib library is suppossed to be
        /// final - all other version are kept to understand the principal applied to
        /// arrive at the Generic patterns in the TreeLib library.
        /// </summary>
        /// <param name="root"></param>
        internal static void TestPreOrder(Node root)
        {
            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX PreOrder Traversal (Depth-First)
            Console.WriteLine("PreOrder (Depth First) Tree Traversal");
            var items = TreeLib.Depthfirst.Traverse.Preorder(root, i => i.Children);
            foreach (var item in items)
            {
                Console.WriteLine(item.GetPath());
            }
            Console.WriteLine();
            Console.WriteLine("Press any key for PreOrder demo with multiple roots...");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX PreOrder Traversal (Depth-First)
            Console.WriteLine("PreOrder (Depth First) Tree Traversal (Multiple Roots Nodes)");

            var root1 = makeTree(1);
            var root2 = makeTree(1);
            var multipleRoots = new List<Node>() { root2, root1 }.GetEnumerator();

            items = TreeLib.Depthfirst.Traverse.Preorder(multipleRoots, i => i.Children);
            foreach (var item in items)
            {
                Console.WriteLine(item.GetPath());
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Demos all 3 Development versions of the PostOrder Tree Traversal algorithm
        /// in one method.
        /// 
        /// Only the algorithm in the TreeLib library is suppossed to be
        /// final - all other version are kept to understand the principal applied to
        /// arrive at the Generic patterns in the TreeLib library.
        /// </summary>
        /// <param name="root"></param>
        internal static void TestPostOrder(Node root)
        {
            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX PostOrder Traversal (Depth-First)
            Console.WriteLine("(Depth First) PostOrder Tree Traversal");
            var items = TreeLib.Depthfirst.Traverse.PostOrder(root, i => i.Children);

            foreach (var item in items)
            {
                Console.WriteLine(item.GetPath());
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Returns a simple tree of <seealso cref="Nodes"/> to work
        /// with the demo code in this application.
        /// 
        ///        a
        ///      /  |  \
        ///    b    c    d
        ///   /|\    \    \ \
        ///  e,f,xyz  g    h i
        /// 
        ///  dfs: efbgchida
        /// </summary>
        /// <returns></returns>
        internal static Node makeTree(int isampleNumber = 0)
        {
            string SampleIndicator = string.Empty;

            if (isampleNumber > 0)
                SampleIndicator = isampleNumber.ToString();

            var a = new Node(null, string.Format("a{0}", SampleIndicator));

            var b = new Node(a, string.Format("b{0}", SampleIndicator));
            var c = new Node(a, string.Format("c{0}", SampleIndicator));
            var d = new Node(a, string.Format("d{0}", SampleIndicator));
            a.Children.Add(b);
            a.Children.Add(c);
            a.Children.Add(d);

            b.Children.Add(new Node(b, string.Format("e{0}", SampleIndicator)));
            b.Children.Add(new Node(b, string.Format("f{0}", SampleIndicator)));
            b.Children.Add(new Node(b, string.Format("x{0}", SampleIndicator)));
            b.Children.Add(new Node(b, string.Format("y{0}", SampleIndicator)));
            b.Children.Add(new Node(b, string.Format("z{0}", SampleIndicator)));

            c.Children.Add(new Node(c, string.Format("g{0}", SampleIndicator)));

            d.Children.Add(new Node(d, string.Format("h{0}", SampleIndicator)));
            d.Children.Add(new Node(d, string.Format("i{0}", SampleIndicator)));

            return a;
        }
    }
}
