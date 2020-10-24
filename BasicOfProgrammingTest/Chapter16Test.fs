module Chapter16Test

open Xunit
open Chapter16
open TestUtil

[<Fact>]
let ``問題16.1 sumListは整数のリストからそれまでの数の合計からなるリストを作成する``() =
    isEqual [3; 5; 6; 10] (sumList [3; 2; 1])
    isEqual [] (sumList [])

