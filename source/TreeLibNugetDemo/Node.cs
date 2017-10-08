namespace TreeLibNugetDemo
{
    using System.Collections.Generic;

    class Node
    {
        public string Id;
        public List<Node> Children;
        public Node Parent;

        public Node(Node parent, string id)
        {
            Parent = parent;
            Id = id;
            Children = new List<Node>();
        }

        public Node(Node parent, string id, List<Node> children)
        {
            Parent = parent;
            Id = id;
            Children = children;
        }

        public override bool Equals(object obj)
        {
            var node = obj as Node;
            if (node != null)
            {
                return node.Id == this.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public string GetPath(Node current = null)
        {
            if (current == null)
                current = this;

            string result = string.Empty;

            // Traverse the list of parents backwards and
            // add each child to the path
            while (current != null)
            {
                result = "/" + current.Id + result;

                current = current.Parent;
            }

            return result;
        }

        public override string ToString()
        {
            if (Id == null)
                return "(null)";

            if (Id == string.Empty)
                return "(empty)";

            if (Parent == null)
                return Id;

            return string.Format("{0}  at: {1}", Id, GetPath());
        }
    }
}
