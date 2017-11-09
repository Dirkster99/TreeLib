namespace TreeLibNugetDemo
{
    using System;
    using TreeLibNugetDemo.Demos;
    using TreeLibNugetDemo.Demos.Directories;

    /// <summary>
    /// This demo application tests different versions of tree traversal algorithms from
    /// the Nuget  Dirster.TreeLib package (you may have to enable/restore NuGet packaging).
    /// </summary>
    class Program
    {
        static int Main(string[] args)
        {
            PrintMenu menu = new PrintMenu();
            var root = TraversalDemo.makeTree();

            menu.AddMenuEntry('1', "Level Order Traversal Demo");
            menu.AddMenuEntry('2', "Pre-Order Traversal Demo");
            menu.AddMenuEntry('3', "Post-Order Traversal Demo");
            menu.AddMenuEntry('4', "Compute Directory Size (without exception handling in enumeration)");
            menu.AddMenuEntry('5', "Compute Directory Size (WITH exception handling and Generic class)");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("This program demos TreeLib applications and use cases by example.");
                var key = menu.ShowMenu();

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                switch (key)
                {
                    case '1':
                        TraversalDemo.TestLevelOrder(root);
                        break;

                    case '2':
                        TraversalDemo.TestPreOrder(root);
                        break;

                    case '3':
                        TraversalDemo.TestPostOrder(root);
                        break;

                    case '4':
                        DirSizeWoException.DemoDirectoryTreeTraversal();
                        break;

                    case '5':
                        DirectorySize.DemoDirectoryTreeTraversal();
                        break;
                    default:
                        return (0);
                }
            }
        }
    }
}
