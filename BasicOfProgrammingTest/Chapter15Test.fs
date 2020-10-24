module Chapter15Test

open Xunit
open Chapter15
open TestUtil

[<Fact>]
let ``問題15.1 quickSortは数値のリストをソートする。`` () =
    isEqual [] (quickSort [])
    isEqual [1; 2; 3] (quickSort [2; 1; 3])
    isEqual [1; 2; 2] (quickSort [2; 1; 2])