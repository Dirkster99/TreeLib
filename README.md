[![Build status](https://ci.appveyor.com/api/projects/status/de18xc6i431xnlvg?svg=true)](https://ci.appveyor.com/project/Dirkster99/treelib)
[![Release](https://img.shields.io/github/release/Dirkster99/TreeLib.svg)](https://github.com/Dirkster99/TreeLib/releases/latest)
[![NuGet](https://img.shields.io/nuget/dt/Dirkster.TreeLib.svg)](http://nuget.org/packages/Dirkster.TreeLib)

# TreeLib
This project provides a:
- <a href="https://docs.microsoft.com/en-us/dotnet/standard/net-standard">.Net Standard</a> Library (1.4, 1.6, 2.0) or a
- .Net framework 4.0 Library

with Generic methods to traverse k-ary trees in different orders (Post-Order, Pre-Order, Level-Order) of traversal. This implementation includes scalable algorithms that return `IEnumerable<T>` to make parsing large tree structures a piece of cake, as well, as [Generic Exception handling](https://github.com/Dirkster99/TreeLib/blob/adb9145b9c5baaf0ee8bd6f5fe5982354d962dc2/source/TreeLibNugetDemo/Demos/Directories/DirectorySize.cs#L85-#L86) to ensure that traversal algorithms complete despite unexpected errors on some nodes.

Review demo projects:
* in this solution,
* <a href="https://github.com/Dirkster99/FilterTreeView">WPF FilterTreeView</a> sample application, and read
* <a href="https://www.codeproject.com/Articles/1213031/Advanced-WPF-TreeViews-Part-of-n">Advanced WPF TreeViews Part 3 of n</a>
* <a href="https://www.codeproject.com/Articles/1216583/Advanced-WPF-TreeViews-Part-of-n">Advanced WPF TreeViews Part 4 of n</a> to learn more details.

Implementing something as complicated as a Post-Order traversal algorithm requires just:
* a project reference,
* a <a href="https://msdn.microsoft.com/en-us/library/bb308959.aspx">LINQ</a> statement to find each set of children in the tree,
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

* <a href="https://github.com/Dirkster99/TreeLib/blob/master/source/Shared/BreadthFirst/TraverseLevelOrder.cs">Trees with 1 root node</a> (expects 1 &lt;T&gt; root item as parameter)
* <a href="https://github.com/Dirkster99/TreeLib/blob/master/source/Shared/BreadthFirst/TraverseLevelOrderEnumerableRoot.cs">Trees with multiple root nodes</a> (expects an IEnumerable&lt;T&gt; root item as parameter)
* <a href="https://github.com/Dirkster99/TreeLib/blob/master/source/Shared/BreadthFirst/LevelOrder.cs">Generic Level-Order</a> function and <a href="https://github.com/Dirkster99/TreeLib/blob/master/source/TreeLibNugetDemo/Program.cs">DemoDirectoryTreeTraversal</a>

## Depth First
### PreOrder
See TreeLib.BreadthFirst.Traverse.PreOrder implementation for:

* <a href="https://github.com/Dirkster99/TreeLib/blob/master/source/Shared/Depthfirst/TraversePreorder.cs">Trees with 1 root node</a> (expects 1 &lt;T> root item as parameter)
* <a href="https://github.com/Dirkster99/TreeLib/blob/master/source/Shared/Depthfirst/TraversePreorderEnumerableRoot.cs">Trees with multiple root nodes</a> (expects IEnumerable&lt;T> root as parameter)
* <a href="https://github.com/Dirkster99/TreeLib/blob/master/source/Shared/Depthfirst/PreOrder.cs">Generic Pre-Order</a> function and <a href="https://github.com/Dirkster99/TreeLib/blob/master/source/TreeLibNugetDemo/Program.cs">DemoDirectoryTreeTraversal</a>

### Postorder
See TreeLib.BreadthFirst.Traverse.Postorder implementation for:

* <a href="https://github.com/Dirkster99/TreeLib/blob/master/source/Shared/Depthfirst/TraversePostOrder.cs">Trees with 1 root node</a> (expects 1 &lt;T> root item as parameter)
* <a href="https://github.com/Dirkster99/TreeLib/blob/master/source/Shared/Depthfirst/TraversePostOrderEnumerableRoot.cs">Trees with multiple root nodes</a> (expects IEnumerable&lt;T> root item as parameter)
* <a href="https://github.com/Dirkster99/TreeLib/blob/master/source/Shared/Depthfirst/PostOrder.cs">Generic Post-Order</a> function and <a href="https://github.com/Dirkster99/TreeLib/blob/master/source/TreeLibNugetDemo/Program.cs">DemoDirectoryTreeTraversal</a>

# Tip
* Read about [Generic Tree and Linked List Traversal in C#](http://web.archive.org/web/20180128233111/http://www.codeducky.org/easy-tree-and-linked-list-traversal-in-c/) to understand the usefulness of *Generic* traversal methods.

* Watch the <a href="https://www.youtube.com/watch?v=gm8DUJJhmY4">Binary tree traversal: Preorder, Inorder, Postorder</a> video to better understand what is what (and why these Traversal Order Names make some sense):

* Look into data structure books online [Introduction to Trees, Binary Search Trees](https://cathyatseneca.gitbooks.io/data-structures-and-algorithms/introduction_to_trees,_binary_search_trees/definitions.html) or offline *[Algorithms](http://algs4.cs.princeton.edu/home/)* by Robert Sedgewick and Kevin Wayne, if you still need more background on tree structures 
