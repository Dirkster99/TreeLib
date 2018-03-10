namespace TTraversalDemo
{
    using System;
    using System.Collections.Generic;
    using TreeLibDemoLib;
    using TreeLibDemoLib.Development;

    /// <summary>
    /// This demo application tests different versions of tree traversal algorithms from:
    /// 
    /// Version V1
    /// - simple and straight (no generics - just iterative code)
    /// 
    /// Version V2
    /// - First devered Generic version without Lazyness.
    /// 
    /// TreeLib.* (Version V3)
    /// - Second an Final derived Generic version with Lazyness.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var root = makeTree();

            TestLevelOrder(root);

            TestPreOrder(root);

            TestPostOrder(root);
        }

        /// <summary>
        /// Demos all 3 Development versions of the LevelOrder Tree Traversal algorithm
        /// in one method.
        /// 
        /// Only the algorithm in the TreeLib library is suppossed to be
        /// final - all other version are kept to understand the principal applied to
        /// arrive at the Generic patterns in the TreeLib library.
        /// </summary>
        /// <param name="root"></param>
        private static void TestLevelOrder(Node root)
        {
            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX LevelOrder (Breadth-First)
            Console.WriteLine("LevelOrderTraversal Tree Traversal V1");
            LevelOrderV1.Traverse(root);

            Console.WriteLine();
            Console.WriteLine("Press any key...");
            Console.ReadKey();

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX LevelOrder (Breadth-First)
            Console.WriteLine("LevelOrderTraversal Tree Traversal V2");
            var lorderitems = LevelOrderV2.Traverse(root, i => i.Children);

            foreach (var item in lorderitems)
            {
                int iLevel = item.Item1;
                Node current = item.Item2;

                Console.WriteLine(string.Format("{0,4} - {1}"
                    , iLevel, current.GetPath()));
            }

            Console.WriteLine();
            Console.WriteLine("Press any key...");
            Console.ReadKey();

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX LevelOrder (Breadth-First)
            Console.WriteLine("LevelOrderTraversal Tree Traversal V3");
            var levorderItems = TreeLib.BreadthFirst.Traverse.LevelOrder(root, i => i.Children);

            foreach (var current in levorderItems)
            {
                Console.WriteLine(string.Format("{0,4} - {1}", current.Level
                                                             , current.Node.GetPath()));
            }

            Console.WriteLine();
            Console.WriteLine("Press any key...");
            Console.ReadKey();
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
        private static void TestPreOrder(Node root)
        {
            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX PreOrder Traversal (Depth-First)
            Console.WriteLine("PreOrder (Depth First) Tree Traversal V1");
            PreOrderV1.Traverse(root);
            Console.WriteLine();
            Console.WriteLine("Press any key...");
            Console.ReadKey();

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX PreOrder Traversal (Depth-First)
            Console.WriteLine("PreOrder (Depth First) Tree Traversal V2");
            var items = PreOrderV2.Traverse(root, i => i.Children);
            foreach (var item in items)
            {
                Console.WriteLine(item.GetPath());
            }
            Console.WriteLine();
            Console.WriteLine("Press any key...");
            Console.ReadKey();

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX PreOrder Traversal (Depth-First)
            Console.WriteLine("PreOrder (Depth First) Tree Traversal V3");
            items = TreeLib.Depthfirst.Traverse.Preorder(root, i => i.Children);
            foreach (var item in items)
            {
                Console.WriteLine(item.GetPath());
            }
            Console.WriteLine();
            Console.WriteLine("Press any key...");
            Console.ReadKey();

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX PreOrder Traversal (Depth-First)
            Console.WriteLine("PreOrder (Depth First) Tree Traversal V3 (Multiple Roots Nodes)");

            var root1 = makeTree(1);
            var multipleRoots = new List<Node>(){ root, root1}.GetEnumerator();

            items = TreeLib.Depthfirst.Traverse.Preorder(multipleRoots, i => i.Children);
            foreach (var item in items)
            {
                Console.WriteLine(item.GetPath());
            }
            Console.WriteLine();
            Console.WriteLine("Press any key...");
            Console.ReadKey();
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
        private static void TestPostOrder(Node root)
        {
            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX PostOrder Traversal (Depth-First)
            Console.WriteLine("(Depth First) PostOrder Tree Traversal V1");
            PostOrderV1.Traverse(root);
            Console.WriteLine();
            Console.WriteLine("Press any key...");
            Console.ReadKey();

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX PostOrder Traversal (Depth-First)
            Console.WriteLine("(Depth First) Post-Order Tree Traversal V2");
            var items = PostOrderV2.Traverse(root, i => i.Children);

            foreach (var item in items)
            {
                Console.WriteLine(item.GetPath());
            }
            Console.WriteLine();
            Console.WriteLine("Press any key...");
            Console.ReadKey();

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX PostOrder Traversal (Depth-First)
            Console.WriteLine("(Depth First) PostOrder Tree Traversal V3");
            items = TreeLib.Depthfirst.Traverse.PostOrder(root, i => i.Children);

            foreach (var item in items)
            {
                Console.WriteLine(item.GetPath());
            }
            Console.WriteLine();
            Console.WriteLine("Press any key...");
            Console.ReadKey();
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
        private static Node makeTree(int isampleNumber=0)
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
