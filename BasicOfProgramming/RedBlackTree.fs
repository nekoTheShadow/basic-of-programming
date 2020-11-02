module RedBlackTree

exception NotFoundException

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

let insert rbTree key value =
  let rec f rbTree = 
    match rbTree with
    | Empty -> Node(Empty, key, value, Red, Empty)
    | Node (left, k, v, color, right) -> 
      if k = key then
        Node (left, key, value, color, right) 
      else if key < k then
        balance (Node (f left, k, v, color, right))
      else
        balance (Node (left, k, v, color, f right))
  in 
  match f rbTree with
  | Empty -> failwith "ありえない"
  | Node (left, k, v, color, right) -> Node (left, k, v, Black, right)

let rec search rbTree key =
  match rbTree with
  | Empty -> raise NotFoundException
  | Node (left, k, v, color, right) -> 
    if k = key then
      v
    else if key < k then
      search left key
    else
      search right key