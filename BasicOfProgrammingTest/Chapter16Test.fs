module Chapter16Test

open Xunit
open Chapter16
open TestUtil

[<Fact>]
let ``問題16.1 sumListは整数のリストからそれまでの数の合計からなるリストを作成する``() =
    isEqual [3; 5; 6; 10] (sumList [3; 2; 1; 4])
    isEqual [] (sumList [])

[<Fact>]
let ``問題16.2 foldLeftは畳み込み関数を提供する``() =
    Assert.Equal(0, (foldLeft (-) 0 []))
    Assert.Equal(2, (foldLeft (-) 10 [4; 1; 3]))
    isEqual [3; 2; 1] (foldLeft (fun lst a -> a::lst) [] [1; 2; 3]) 
