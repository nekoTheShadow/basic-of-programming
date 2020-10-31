module Tree

type Tree = Empty
          | Leaf of int
          | Node of Tree * int * Tree

let rec treeDouble tree = match tree with
    | Empty -> Empty
    | Leaf(n) -> Leaf(n*2)
    | Node(tree1, n, tree2) -> Node ((treeDouble tree1), n*2, (treeDouble tree2))

let rec treeMap tree f = match tree with
    | Empty -> Empty
    | Leaf(n) -> Leaf(f(n))
    | Node(tree1, n, tree2) -> Node ((treeMap tree1 f), (f n), (treeMap tree2 f))
