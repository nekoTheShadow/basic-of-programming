module Chapter11Test

open Chapter11
open Xunit

[<Theory>]
[<InlineData(0, 0)>]
[<InlineData(5, 55)>]
[<InlineData(10, 385)>]
let ``問題11.1 sumOfSquareは0からnまでの2上の和を求める``(n, expected) = 
    Assert.Equal(expected, (sumOfSquare n))
