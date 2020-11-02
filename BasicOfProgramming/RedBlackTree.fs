module RedBlackTree

type Color = Red | Black

type ('a, 'b) RbTree = 
  | Empty 
  | Node of RbTree<'a, 'b> * 'a * 'b * Color * RbTree<'a, 'b>