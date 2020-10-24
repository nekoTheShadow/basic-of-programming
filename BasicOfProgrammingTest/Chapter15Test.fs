module Chapter15Test

open Xunit
open Chapter15
open TestUtil

[<Fact>]
let ``問題15.1 quickSortは数値のリストをソートする。`` () =
    isEqual [] (quickSort [])
    isEqual [1; 2; 3] (quickSort [2; 1; 3])
    isEqual [1; 2; 2] (quickSort [2; 1; 2])

[<Theory>]
[<InlineData(15, 15, 15)>]
[<InlineData(15,  0, 15)>]
[<InlineData(24, 15, 3)>]
let ``問題15.2 gcdはm>=n>=0の最大公約数を求める`` (m, n, expected) =
    Assert.Equal(expected, (gcd m n))