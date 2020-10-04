module Chapter09Test

open Xunit
open Chapter09

type ``問題9-4 lengthはリストの長さを求める`` () =

    [<Fact>]
    let ``空リストの場合は0``() =
        let actual = length []
        Assert.Equal(0, actual)

    [<Fact>]    
    let ``[1; 2; 3]の場合は3``() =
        let actual = length [1; 2; 3]
        Assert.Equal(3, actual)