module Chapter18Test

open Xunit
open Chapter18

[<Fact>]
let ``問題18.2 countUrikireYasaiは八百屋においていない野菜の数を数える``() =
    let yaoyaList =  [("トマト", 300); ("たまねぎ", 200); ("にんじん", 150); ("ほうれん草", 200)] 
    Assert.Equal(0, (countUrikireYasai yaoyaList ["たまねぎ"; "にんじん"]))
    Assert.Equal(1, (countUrikireYasai yaoyaList ["たまねぎ"; "じゃがいも"; "にんじん"]))
    Assert.Equal(2, (countUrikireYasai yaoyaList ["しいたけ"; "なす"; "にんじん"]))