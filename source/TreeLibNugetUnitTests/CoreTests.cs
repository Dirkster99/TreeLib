namespace TreeLibNugetUnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using TreeLibDemoLib;
    using TreeLibDemoLib.Development;

    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var root = CoreTests.makeTree1();
            TestTreeTraversal(root);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var root = CoreTests.makeTree2();
            TestTreeTraversal(root);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var root = CoreTests.makeTree3();
            TestTreeTraversal(root);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var root = CoreTests.makeTree4();
            TestTreeTraversal(root);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var root = CoreTests.makeTree5();
            TestTreeTraversal(root);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var root = CoreTests.makeTree6();
            TestTreeTraversal(root);
        }

        [TestMethod]
        public void TestMethod7()
        {
            var root = CoreTests.makeTree7();
            TestTreeTraversal(root);
        }

        [TestMethod]
        public void TestMethod8()
        {
            var root = CoreTests.makeTree8();
            TestTreeTraversal(root);
        }

        [TestMethod]
        public void TestMethod9()
        {
            var root = CoreTests.makeTree9();
            TestTreeTraversal(root);
        }

        [TestMethod]
        public void TestMethod10()
        {
            var root = CoreTests.makeTree10();
            TestTreeTraversal(root);
        }

        [TestMethod]
        public void TestMethod11()
        {
            var root = CoreTests.makeTree11();
            TestTreeTraversal(root);
        }

        [TestMethod]
        public void TestMethod12()
        {
            var root = CoreTests.makeTree12();
            TestTreeTraversal(root);
        }

        private static void TestTreeTraversal(Node root)
        {
            // Generate version 1 traversals
            var levelOrderItems1 = LevelOrderV1.Traverse(root);
            var preOrderItems1 = PreOrderV1.Traverse(root);
            var postOrderItems1 = PostOrderV1.Traverse(root);

            // Generate version 2 traversals
            var levelOrderItems2 = LevelOrderV2.Traverse(root, i => i.Children).ToList();
            var preOrderItems2 = PreOrderV2.Traverse(root, i => i.Children).ToList();
            var postOrderItems2 = PostOrderV2.Traverse(root, i => i.Children).ToList();

            // Generate version 3 traversals
            var levelOrderItems3 = TreeLib.BreadthFirst.Traverse.LevelOrder(root, i => i.Children).ToList();
            var preOrderItems3 = TreeLib.Depthfirst.Traverse.Preorder(root, i => i.Children).ToList();
            var postOrderItems3 = TreeLib.Depthfirst.Traverse.PostOrder(root, i => i.Children).ToList();

            // Order of traversal may be different,
            // in the end, all elements are there (count)
            Assert.AreEqual(levelOrderItems1.Count, preOrderItems1.Count);
            Assert.AreEqual(levelOrderItems1.Count, postOrderItems1.Count);

            Assert.AreEqual(levelOrderItems1.Count, levelOrderItems2.Count);
            Assert.AreEqual(preOrderItems1.Count, preOrderItems2.Count);
            Assert.AreEqual(postOrderItems1.Count, postOrderItems2.Count);

            Assert.AreEqual(levelOrderItems1.Count, levelOrderItems3.Count);
            Assert.AreEqual(preOrderItems1.Count, preOrderItems3.Count);
            Assert.AreEqual(postOrderItems1.Count, postOrderItems3.Count);

            // Sort Version 1 by Id and make sure all items are there
            levelOrderItems1.Sort((i1, i2) => i1.Id.CompareTo(i2.Id));
            preOrderItems1.Sort((i1, i2) => i1.Id.CompareTo(i2.Id));
            postOrderItems1.Sort((i1, i2) => i1.Id.CompareTo(i2.Id));

            // Sort Version 2 by Id and make sure all items are there
            levelOrderItems2.Sort((i1, i2) => i1.Item2.Id.CompareTo(i2.Item2.Id));
            preOrderItems2.Sort((i1, i2) => i1.Id.CompareTo(i2.Id));
            postOrderItems2.Sort((i1, i2) => i1.Id.CompareTo(i2.Id));

            // Sort Version 3 by Id and make sure all items are there
            levelOrderItems3.Sort((i1, i2) => i1.Node.Id.CompareTo(i2.Node.Id));
            preOrderItems3.Sort((i1, i2) => i1.Id.CompareTo(i2.Id));
            postOrderItems3.Sort((i1, i2) => i1.Id.CompareTo(i2.Id));

            for (int i = 0; i < levelOrderItems1.Count; i++)
            {
                Assert.AreEqual(levelOrderItems1[i], preOrderItems1[i]);
                Assert.AreEqual(levelOrderItems1[i], postOrderItems1[i]);

                if (levelOrderItems1[i].Equals(levelOrderItems2[i].Item2) == false)
                {
                    Console.WriteLine("1.1) Comparing levelOrderItems1[i] '{0}' with levelOrderItems2[i] '{1}' failed."
                        , levelOrderItems1[i], levelOrderItems2[i].Item2);
                }

                if (preOrderItems1[i].Equals(preOrderItems2[i]) == false)
                {
                    Console.WriteLine("2.1) Comparing preOrderItems1[i] '{0}' with preOrderItems2[i] '{1}' failed."
                        , preOrderItems1[i], preOrderItems2[i]);
                }

                if (postOrderItems1[i].Equals(postOrderItems2[i]) == false)
                {
                    Console.WriteLine("3.1) Comparing postOrderItems1[i] '{0}' with postOrderItems2[i] '{1}' failed."
                        , postOrderItems1[i], postOrderItems2[i]);
                }

                Assert.AreEqual(levelOrderItems1[i], levelOrderItems2[i].Item2);
                Assert.AreEqual(preOrderItems1[i], preOrderItems2[i]);
                Assert.AreEqual(postOrderItems1[i], postOrderItems2[i]);

                if (levelOrderItems1[i].Equals(levelOrderItems3[i].Node) == false)
                {
                    Console.WriteLine("1.2) Comparing levelOrderItems1[i] '{0}' with levelOrderItems3[i] '{1}' failed."
                        , levelOrderItems1[i], levelOrderItems3[i].Node);
                }

                if (preOrderItems1[i].Equals(preOrderItems3[i]) == false)
                {
                    Console.WriteLine("2.2) Comparing preOrderItems1[i] '{0}' with preOrderItems3[i] '{1}' failed."
                        , preOrderItems1[i], preOrderItems3[i]);
                }

                if (postOrderItems1[i].Equals(postOrderItems3[i]) == false)
                {
                    Console.WriteLine("3.3) Comparing postOrderItems1[i] '{0}' with postOrderItems3[i] '{1}' failed."
                        , postOrderItems1[i], postOrderItems3[i]);
                }

                Assert.AreEqual(levelOrderItems1[i], levelOrderItems3[i].Node);
                Assert.AreEqual(preOrderItems1[i], preOrderItems3[i]);
                Assert.AreEqual(postOrderItems1[i], postOrderItems3[i]);
            }
        }

        private static Node makeTree1(int isampleNumber = 0)
        {
            string SampleIndicator = string.Empty;

            if (isampleNumber > 0)
                SampleIndicator = isampleNumber.ToString();

            var a = new Node(null, string.Format("a{0}", SampleIndicator));

            return a;
        }

        private static Node makeTree2(int isampleNumber = 0)
        {
            string SampleIndicator = string.Empty;

            if (isampleNumber > 0)
                SampleIndicator = isampleNumber.ToString();

            var a = new Node(null, string.Format("a{0}", SampleIndicator));

            var b = new Node(a, string.Format("b{0}", SampleIndicator));
            a.Children.Add(b);

            return a;
        }

        private static Node makeTree3(int isampleNumber = 0)
        {
            string SampleIndicator = string.Empty;

            if (isampleNumber > 0)
                SampleIndicator = isampleNumber.ToString();

            var a = new Node(null, string.Format("a{0}", SampleIndicator));

            var b = new Node(a, string.Format("b{0}", SampleIndicator));
            var c = new Node(a, string.Format("c{0}", SampleIndicator));
            a.Children.Add(b);
            a.Children.Add(c);

            return a;
        }

        private static Node makeTree4(int isampleNumber = 0)
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

            return a;
        }

        private static Node makeTree5(int isampleNumber = 0)
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

            return a;
        }

        private static Node makeTree6(int isampleNumber = 0)
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

            return a;
        }

        private static Node makeTree7(int isampleNumber = 0)
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

            return a;
        }

        private static Node makeTree8(int isampleNumber = 0)
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

            return a;
        }

        private static Node makeTree9(int isampleNumber = 0)
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

            return a;
        }

        private static Node makeTree10(int isampleNumber = 0)
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

            return a;
        }

        private static Node makeTree11(int isampleNumber = 0)
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

            return a;
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
        private static Node makeTree12(int isampleNumber = 0)
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
