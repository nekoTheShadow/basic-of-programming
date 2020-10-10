module Chapter11Test

open Chapter11
open Xunit

[<Theory>]
[<InlineData(0, 0)>]
[<InlineData(5, 55)>]
[<InlineData(10, 385)>]
let ``問題11.1 sumOfSquareは0からnまでの2上の和を求める``(n, expected) = 
    Assert.Equal(expected, (sumOfSquare n))


[<Theory>]
[<InlineData(0, 3)>]
[<InlineData(5, 65)>]
[<InlineData(10, 2049)>]
let ``問題11.2 aは与えられた漸化式を実装した関数``(n, expected) =
    Assert.Equal(expected, (a n))