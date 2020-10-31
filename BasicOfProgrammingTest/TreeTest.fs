module TreeTest

open Xunit
open Tree

[<Fact>]
let ``問題17.5 treeDoubleは格納されている値をすべて2倍にする`` () =
    let tree1 = Empty
    let tree2 = Leaf(3)
    let tree3 = Node (tree1, 4, tree2)
    let tree4 = Node (tree2, 5, tree3)

    let treeA = Empty
    let treeB = Leaf(6)
    let treeC = Node (treeA, 8, treeB)
    let treeD = Node (treeB, 10, treeC)

    Assert.Equal(treeA, (treeDouble tree1))
    Assert.Equal(treeB, (treeDouble tree2))
    Assert.Equal(treeC, (treeDouble tree3))
    Assert.Equal(treeD, (treeDouble tree4))