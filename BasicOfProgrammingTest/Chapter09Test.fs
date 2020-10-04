module Chapter09Test

open Xunit
open Chapter09

let isEqual lst1 lst2 =
    Assert.True(
        List.length lst1 = List.length lst2 && List.forall2 (( = )) lst1 lst2, 
        sprintf "expected %A, but actual %A" lst1 lst2
    )


type ``問題9-4 lengthはリストの長さを求める`` () =

    [<Fact>]
    let ``空リストの場合は0``() =
        let actual = length []
        Assert.Equal(0, actual)

    [<Fact>]    
    let ``[1; 2; 3]の場合は3``() =
        let actual = length [1; 2; 3]
        Assert.Equal(3, actual)
 
[<Fact>]
let ``問題9.5 evenはリストの偶数の要素のみを集めたリストを作成する`` () =
    isEqual [2; 6; 4] (even [2; 1; 6; 4; 7])

[<Fact>]
let ``問題9.6 concatはリストを前から順番に結合する`` () =
    Assert.Equal("春夏秋冬", (concat ["春"; "夏"; "秋"; "冬"]))

