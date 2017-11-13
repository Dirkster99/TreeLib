namespace TreeLibNugetDemo.Demos.Directories
{
    using System;
    using System.IO;
    using TreeLib.BreadthFirst;

    /// <summary>
    /// Demonstrates a directory traversal method build on to the Generic&lt;T, TResult>
    /// class implementation. This implementation SUPPORTS EXCEPTION handling
    /// - which can be verified here.
    /// 
    /// See (see <seealso cref="DirSizeWoException"/> class for an IEnumerable/Yield
    /// implementation without support for exception handling.
    /// </summary>
    public class DirectorySize
    {
        /// <summary>
        /// Implements a method that computes statistics
        /// (number of folders, files, and their size)
        /// for each directory in <paramref name="d"/>.
        /// </summary>
        /// <param name="res"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        private static DirSizeResult ComputeDirSize(DirSizeResult res, DirectoryInfo d)
        {
            res.Folders++;

            try
            {
                FileInfo[] fis = d.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    res.Files++;
                    res.Size += fi.Length;
                }
            }
            catch
            {
                // No access to files could be handled here ...
                Console.Write("F");
            }

            return res;
        }

        /// <summary>
        /// Implements a simple user interaction to ask for a directory to traverse
        /// and compute statistics for.
        /// </summary>
        public static void DemoDirectoryTreeTraversal()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("This demo visits (traverses) all sub-directories of a");
            Console.WriteLine("given directory and outputs the size of all files in the end.");
            Console.WriteLine();
            Console.WriteLine("Please input a path e.g. 'C:' (without quotes) or just press enter if you");
            Console.WriteLine("do not want to see this demo right now.");

            string path = Console.ReadLine();

            if (string.IsNullOrEmpty(path) == true)
                return;

            if (path.Length == 2)  // Change 'C:' into 'C:\' to make sure its a valid path
            {
                if (path[1] == ':')
                    path += '\\';
            }

            var res = new DirSizeResult();       // Initialize result object

            // You can use LevelOrder<T>, PostOrder<T>, and PreOrder<T> here
            var Order = new LevelOrder<DirSizeResult, DirectoryInfo>();

            res = Order.Traverse(new DirectoryInfo(path)
                                , i => i.GetDirectories()
                                , res
                                , ComputeDirSize
                                
                                , i => Console.Write(".")   // print a simple progress indicator
                                
                                , (i, exc, j) =>            // print a simple child exception indicator
                                { Console.Write("D"); return i; }
            );

            double kBSize = res.Size / 1024;
            double mBSize = res.Size / 1024 / 1024;
            double gBSize = res.Size / 1024 / 1024 / 1024;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("    Folders found: {0}", res.Folders);
            Console.WriteLine("      Files found: {0}", res.Files);
            Console.WriteLine("Directory Size is: {0} Kb, {1} Mb, {2} Gb", kBSize, mBSize, gBSize);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        #region private class
        private class DirSizeResult
        {
            public DirSizeResult()
            {
                Size = Folders = Files = 0;
            }

            public long Size { get; set; }

            public long Folders { get; set; }

            public long Files { get; set; }
        }
        #endregion private class
    }
}
