[![Build status](https://ci.appveyor.com/api/projects/status/de18xc6i431xnlvg?svg=true)](https://ci.appveyor.com/project/Dirkster99/treelib)
[![Release](https://img.shields.io/github/release/Dirkster99/TreeLib.svg)](https://github.com/Dirkster99/TreeLib/releases/latest)
[![NuGet](https://img.shields.io/nuget/dt/Dirkster.TreeLib.svg)](http://nuget.org/packages/Dirkster.TreeLib)

# TreeLib
This project produces a ![.Net Standard](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)
Library with Generic methods to traverse k-nary trees in different orders of traversal.

Implementing something as complicated as a Post-Order traversal algorithm requires just:
* a project reference,
* a ![LINQ](https://msdn.microsoft.com/en-us/library/bb308959.aspx) statement to find each set of children in the tree,
* and a simple for each loop to implement the operation on each tree node:

```C#
Console.WriteLine("(Depth First) PostOrder Tree Traversal V3");
items = TreeLib.Depthfirst.Traverse.PostOrder(root, i => i.Children);

foreach (var item in items)
{
  Console.WriteLine(item.GetPath());
}
```
This pattern leads to a clear-cut separation of:
* the traversal algorithm and
* the operations performed on each tree node (e.g.: `Console.WriteLine(item.GetPath());`).

The project in this repository contains a demo console project to demo its usage in more detail.

# Supported Generic Traversal Methods

## Breadth First
### Level Order
See TreeLib.BreadthFirst.Traverse.LevelOrder implementation for:

* trees with 1 root (expects &lt;T> root as parameter)
* trees with multiple root node (expects IEnumerable&lt;T> root as parameter)

## Depth First
### PreOrder
See TreeLib.BreadthFirst.Traverse.PreOrder implementation for:

* trees with 1 root (expects &lt;T> root as parameter)
* trees with multiple root node (expects IEnumerable&lt;T> root as parameter)

### Postorder
See TreeLib.BreadthFirst.Traverse.Postorder implementation for:

* trees with 1 root (expects &lt;T> root as parameter)
* trees with multiple root node (expects IEnumerable&lt;T> root as parameter)

# Tip
* Read about <a href="http://www.codeducky.org/easy-tree-and-linked-list-traversal-in-c/">Generic Tree and Linked List Traversal in C#</a> to understand the usefulness of *Generic* traversal methods.

* Watch the <a href="https://www.youtube.com/watch?v=gm8DUJJhmY4">Binary tree traversal: Preorder, Inorder, Postorder</a> video to better understand what is what (and why these Traversal Order Names make some sense):

* Look into data structure books online ![Introduction to Trees, Binary Search Trees](https://cathyatseneca.gitbooks.io/data-structures-and-algorithms/introduction_to_trees,_binary_search_trees/definitions.html) or offline *![Algorithms](http://algs4.cs.princeton.edu/home/)* by Robert Sedgewick and Kevin Wayne, if you still need more background on tree structures 
