
Overview
--------

Handling tree structured data in C#/.Net often requires us to traverse (visit)
each node (and their children) in a certain order.

A store (serialize) and restore (deserialize) algorithm usually requires a
LevelOrder or PreOrder traversal from the root node(s) down to the bottom,
in which, each node is visited exactly once.

Other algorithms, that require use to compute a value from the leaf up to the root
may require a PostOrder traversal. This solution contains a short overview on this
topic (see below) and Generic algorithms that can be used on any tree (be it binary
or n-ary - each node can have n children with any n > 0).

Classification
--------------
The world of Binary Tree traversal algorithms can be split into:

1 Breadth First
  +-> Level Order

2 Depth First
  +-> PreOrder
  +-> InOrder
  +-> Postorder

Watch this video to understand what is what (and why these names make some sense):
Binary tree traversal: Preorder, Inorder, Postorder
https://www.youtube.com/watch?v=gm8DUJJhmY4
Author: mycodeschool
