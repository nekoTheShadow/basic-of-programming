module RedBlackTreeTest

open Xunit
open RedBlackTree

[<Fact>]
let ``問題20.2 balanceは赤黒木のバランスを調整する。``() =
    let rbTree1 = Node (Node (Node (Empty, 10, "x", Red, Empty), 13, "y", Red, Empty), 15, "z", Black, Empty) 
    let rbTree2 = Node (Node (Empty, 10, "x", Red, Node (Empty, 13, "y", Red, Empty)), 15, "z", Black, Empty) 
    let rbTree3 = Node (Empty, 10, "x", Black, Node (Node (Empty, 13, "y", Red, Empty), 15, "z", Red, Empty))
    let rbTree4 = Node (Empty, 10, "x", Black, Node (Empty, 13, "y", Red, Node (Empty, 15, "z", Red, Empty))) 
    let rbTree5 = Node (Node (Empty, 10, "x", Black, Empty), 13, "y", Red, Node (Empty, 15, "z", Black, Empty)) 
    let rbTree6 = Empty 
    Assert.Equal(rbTree5, balance rbTree1)
    Assert.Equal(rbTree5, balance rbTree2)
    Assert.Equal(rbTree5, balance rbTree3)
    Assert.Equal(rbTree5, balance rbTree4)
    Assert.Equal(rbTree6, balance rbTree6)

[<Fact>]
let ``問題20.3 insertは赤黒木に値を挿入する。``() =
    let rbTree0 = Empty 
    let rbTree1 = insert rbTree0 10 "x" 
    let rbTree2 = insert rbTree1 13 "y" 
    let rbTree3 = insert rbTree2 15 "z" 
    Assert.Equal(Node (Empty, 10, "x", Black, Empty), rbTree1)
    Assert.Equal(Node (Empty, 10, "x", Black, Node (Empty, 13, "y", Red, Empty)), rbTree2)
    Assert.Equal(Node (Node (Empty, 10, "x", Black, Empty), 13, "y", Black, Node (Empty, 15, "z", Black, Empty)), rbTree3)