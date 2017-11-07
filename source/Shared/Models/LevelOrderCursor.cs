namespace TreeLib.Models
{
    /// <summary>
    /// This class implements a simple traversal cursor to indicate
    /// the next element being enumerated and its level.
    /// (see enumeration function in <seealso cref="TreeLib.BreadthFirst.Traverse"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LevelOrderCursor<T>
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="level"></param>
        /// <param name="node"></param>
        public LevelOrderCursor(int level, T node)
            : this()
        {
            Level = level;
            Node = node;
        }

        /// <summary>
        /// Hidden class constructor.
        /// </summary>
        protected LevelOrderCursor()
        {
        }

        /// <summary>
        /// The level indicates the zero based level at which the
        /// corresponding <seealso cref="Node"/> is contained within
        /// the tree.
        /// </summary>
        public int Level { get; private set; }

        /// <summary>
        /// Indicates the tree node that is visited when this class
        /// is returned from an IEnumerable&gt;T> function.
        /// </summary>
        public T Node { get; private set; }
    }
}
