module Chapter20Test

open Chapter20
open Xunit

let isEqual set1 set2 =
    Assert.True(
        List.length set1 = List.length set2 && List.forall2 (( = )) (List.sort set1) (List.sort set2), 
        sprintf "expected %A, but actual %A" set1 set2
    )

[<Fact>]
let ``unionはふたつの集合の和集合を求める``() =
    isEqual [1; 2; 3; 4] (MySet.union [1; 2; 3] [2; 3; 4]) 

[<Fact>]
let ``interはふたつの集合の積集合を求める``() =
    isEqual [2; 3] (MySet.inter [1; 2; 3] [2; 3; 4]) 

[<Fact>]
let ``diffはふたつの集合の差集合を求める``() =
    isEqual [1] (MySet.diff [1; 2; 3] [2; 3; 4]) 

[<Fact>]
let ``memは要素が集合に格納されているかどうかを判定する``() =
    Assert.True(MySet.mem 1 [1; 2; 3])
    Assert.False(MySet.mem 4 [1; 2; 3])