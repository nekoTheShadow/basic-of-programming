module TreeTest

open Xunit
open Tree

let tree1 = Empty
let tree2 = Leaf(3)
let tree3 = Node (tree1, 4, tree2)
let tree4 = Node (tree2, 5, tree3)


[<Fact>]
let ``問題17.5 treeDoubleは格納されている値をすべて2倍にする`` () =
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
    Assert.Equal(0, (treeLength tree1))
    Assert.Equal(1, (treeLength tree2))
    Assert.Equal(2, (treeLength tree3))
    Assert.Equal(4, (treeLength tree4))

[<Fact>]
let ``問題17.8 treeDepthは木構造の深さを求める`` () =
    Assert.Equal(0, (treeDepth tree1))
    Assert.Equal(0, (treeDepth tree2))
    Assert.Equal(1, (treeDepth tree3))
    Assert.Equal(2, (treeDepth tree4))

[<Fact>]
let ``問題17.9 sumTreeは格納されている値を合計にする`` () =
    Assert.Equal(0, (sumTree tree1))
    Assert.Equal(3, (sumTree tree2))
    Assert.Equal(7, (sumTree tree3))
    Assert.Equal(15, (sumTree tree4))