module Chapter09Test

open Xunit
open Chapter08
open Chapter09
open Common

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

[<Fact>]
let ``問題9.7 countKetsuekiAはA型の人間を数える`` () =
    let persons = [
        {Name="田中"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="A"};
        {Name="山田"; Height=1.7; Weight=50.0; Date="2020/02/01"; BloodType="B"};
        {Name="中田"; Height=1.8; Weight=40.0; Date="2020/03/01"; BloodType="O"}; 
    ]
    Assert.Equal(1, (countKetsuekiA persons))

[<Fact>]
let ``問題9.8 otomezaはおとめ座の人間を数える`` () =
    let persons = [
        {Name="田中"; Height=1.6; Weight=60.0; Date="2020/08/23"; BloodType="A"};
        {Name="山田"; Height=1.7; Weight=50.0; Date="2020/02/01"; BloodType="B"};
        {Name="中田"; Height=1.8; Weight=40.0; Date="2020/09/22"; BloodType="O"}; 
    ]
    isEqual ["田中"; "中田"] (otomeza persons)