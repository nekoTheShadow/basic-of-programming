module Chapter13Test

open Person
open Chapter13
open Xunit
open TestUtil

[<Theory>]
[<InlineData("A", 1)>]
[<InlineData("B", 2)>]
[<InlineData("O", 3)>]
[<InlineData("AB", 0)>]
let ``問題13.1 countKetsuekiは指定された血液型を持つ人の数を数える``(bloodType, expected) =
    let persons = [
        {Name="1"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="A"};
        {Name="2"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="B"};
        {Name="3"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="B"};
        {Name="3"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="O"};
        {Name="3"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="O"};
        {Name="3"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="O"};
    ]
    Assert.Equal(expected, (countKetsueki persons bloodType))
    
[<Fact>]
let ``問題13.2 personNamaeは名前のリストを作成する``() =
    let persons = [
        {Name="1"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="A"};
        {Name="2"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="B"};
        {Name="3"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="B"};
    ]
    isEqual ["1"; "2"; "3"] (personNamae persons)

let ``問題13.4 composeは2つの関数を合成する``() =
    let time2 x = x*2
    let add3 x = x+3
    Assert.Equal(14, ((compose time2 add3) 4))