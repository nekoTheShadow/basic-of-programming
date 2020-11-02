module Chapter18Test

open Xunit
open Chapter18
open System

[<Fact>]
let ``問題18.2 countUrikireYasaiは八百屋においていない野菜の数を数える``() =
    let yaoyaList =  [("トマト", 300); ("たまねぎ", 200); ("にんじん", 150); ("ほうれん草", 200)] 
    Assert.Equal(0, (countUrikireYasai yaoyaList ["たまねぎ"; "にんじん"]))
    Assert.Equal(1, (countUrikireYasai yaoyaList ["たまねぎ"; "じゃがいも"; "にんじん"]))
    Assert.Equal(2, (countUrikireYasai yaoyaList ["しいたけ"; "なす"; "にんじん"]))

type ``問題18-3 assocは連想リストからキーに対応する値を探す``() =
    [<Fact>]
    let ``キーに対応する値がない場合は例外``() =
        let d = [("新大塚", 1.2); ("後楽園", 1.8)]
        Assert.Throws<NotFoundException> (Action(fun _ -> assoc "池袋" d |> ignore))
    
    [<Fact>]
    let ``キーに対応する値がある場合はその値が戻り値``() =
        let d = [("新大塚", 1.2); ("後楽園", 1.8)]
        Assert.Equal(1.8, (assoc "後楽園" d))