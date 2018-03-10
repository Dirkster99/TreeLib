namespace TreeLibNugetDemo.Demos.Directories
{
    using System;
    using System.IO;

    /// <summary>
    /// Demonstrates a directory traversal method build on to the IEnumerable/Yield
    /// implementation. This implementation does NOT SUPPORT exception handling
    /// - which can be verified here.
    /// 
    /// See (see <seealso cref="DirectorySize"/> class for a Generic implementation
    /// with support for exception handling.
    /// </summary>
    public class DirSizeWoException
    {
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
            Console.WriteLine("given directory and output the size of all files in the end.");
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

            long files =0;
            long folders = 0;
            long size = DirSizeWoException.ComputeDirSize(path, out files, out folders);

            double kBSize = size / 1024;
            double mBSize = size / 1024 / 1024;
            double gBSize = size / 1024 / 1024 / 1024;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("    Folders found: {0}", folders);
            Console.WriteLine("      Files found: {0}", files);
            Console.WriteLine("Directory Size is: {0} Kb, {1} Mb, {2} Gb", kBSize, mBSize, gBSize);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// This method traverses the sub-directory structure of
        /// the <paramref name="dirRoot"/> directory to compute the
        /// size of all files that are stored in this directory.
        /// 
        /// This equivalent to the recursive implementation as explained here:
        /// https://stackoverflow.com/questions/468119/whats-the-best-way-to-calculate-the-size-of-a-directory-in-net#468131
        /// 
        /// But this will fail if we encounter an exception:
        /// https://stackoverflow.com/questions/1738820/a-problem-with-exception-handling-for-ienumerablet-its-lazyness-dependent#1738856
        /// 
        /// See <seealso cref="Directories.DirectorySize"/> class for generic traversal
        /// INCLUDING Exception handling.
        /// </summary>
        /// <param name="dirRoot"></param>
        /// <returns></returns>
        private static long ComputeDirSize(string sdirRoot, out long files
                                                          , out long folders)
        {
            long size = files = folders = 0;

            try
            {
                var dirRoot = new System.IO.DirectoryInfo(sdirRoot);

                var levorderItems = TreeLib.BreadthFirst.Traverse.LevelOrder(dirRoot, i => i.GetDirectories());
                Console.WriteLine();

                foreach (var current in levorderItems)
                {
                    folders++;

                    ////// Use this to print level depth and name of each visited directory
                    ////Console.WriteLine(string.Format("{0,4}-{1}", current.Level
                    ////                                           , current.Node.FullName));

                    Console.Write(".");  // print a simple progress indicator

                    FileInfo[] fis = current.Node.GetFiles();
                    foreach (FileInfo fi in fis)
                    {
                        files++;
                        size = size + fi.Length;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Cannot complete enumeration.'");
                Console.WriteLine("An unexpected error occured: '{0}'", e.Message);
                Console.WriteLine();
                Console.WriteLine("Press any key...");
                Console.ReadKey();
            }

            return size;
        }
    }
}
