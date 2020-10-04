module Chapter10Test

open Xunit
open Chapter10
open Common

[<Fact>]
let ``問題10.1 insertは昇順となる位置にnを挿入する`` () =
    isEqual [1; 3; 4; 5; 7; 8] (insert [1; 3; 4; 7; 8] 5)

[<Fact>]
let ``問題10.2 inSortは整数のリストを昇順に並び替える`` () =
    isEqual [1; 3; 4; 5; 7; 8] (insSort [5; 3; 8; 1; 7; 4])