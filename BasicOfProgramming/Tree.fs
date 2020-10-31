module Tree

type 'a Tree = Empty
             | Leaf of 'a
             | Node of 'a Tree * 'a * 'a Tree

// type ('a, 'b) Tree2 = Empty
//                     | Leaf of 'a * 'b
//                     | Node of ('a, 'b) Tree2 * 'a * 'b * ('a, 'b) Tree2

let rec treeDouble tree = 
    match tree with
    | Empty -> Empty
    | Leaf(n) -> Leaf(n*2)
    | Node(tree1, n, tree2) -> Node ((treeDouble tree1), n*2, (treeDouble tree2))

let rec treeMap tree f = 
    match tree with
    | Empty -> Empty
    | Leaf(n) -> Leaf(f(n))
    | Node(tree1, n, tree2) -> Node ((treeMap tree1 f), (f n), (treeMap tree2 f))

let rec treeLength tree = 
    match tree with
    | Empty -> 0
    | Leaf(n) -> 1
    | Node(tree1, n, tree2) -> (treeLength tree1) + 1 + (treeLength tree2)

let rec treeDepth tree = 
    match tree with
    | Empty -> 0
    | Leaf(n) -> 0
    | Node(tree1, n, tree2) -> 1 + (max (treeDepth tree1) (treeDepth tree2))