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


[<Fact>]
let ``問題17.6 treeMapは格納されている値にすべてコールバックを適用する。`` () =
    let tree1 = Empty
    let tree2 = Leaf(3)
    let tree3 = Node (tree1, 4, tree2)
    let tree4 = Node (tree2, 5, tree3)

    let treeA = Empty
    let treeB = Leaf(-3)
    let treeC = Node (treeA, -4, treeB)
    let treeD = Node (treeB, -5, treeC)

    Assert.Equal(treeA, (treeMap tree1 ( ~- )))
    Assert.Equal(treeB, (treeMap tree2 ( ~- )))
    Assert.Equal(treeC, (treeMap tree3 ( ~- )))
    Assert.Equal(treeD, (treeMap tree4 ( ~- )))


[<Fact>]
let ``問題17.7 treeLengthは節と葉の合計を計算する。`` () =
    let tree1 = Empty
    let tree2 = Leaf(3)
    let tree3 = Node (tree1, 4, tree2)
    let tree4 = Node (tree2, 5, tree3)
    Assert.Equal(0, (treeLength tree1))
    Assert.Equal(1, (treeLength tree2))
    Assert.Equal(2, (treeLength tree3))
    Assert.Equal(4, (treeLength tree4))