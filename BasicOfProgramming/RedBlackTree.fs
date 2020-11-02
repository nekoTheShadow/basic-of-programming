module RedBlackTree

type Color = Red | Black

type ('a, 'b) RbTree = 
  | Empty 
  | Node of RbTree<'a, 'b> * 'a * 'b * Color * RbTree<'a, 'b>

let balance rbTree = 
    match rbTree with
      Node (Node (Node (a, xa, xb, Red, b), ya, yb, Red, c), za, zb, Black, d) 
    | Node (Node (a, xa, xb, Red, Node (b, ya, yb, Red, c)), za, zb, Black, d) 
    | Node (a, xa, xb, Black, Node (Node (b, ya, yb, Red, c), za, zb, Red, d)) 
    | Node (a, xa, xb, Black, Node (b, ya, yb, Red, Node (c, za, zb, Red, d))) 
        -> Node (Node (a, xa, xb, Black, b), ya, yb, Red, Node (c, za, zb, Black, d)) 
    | _ -> rbTree 