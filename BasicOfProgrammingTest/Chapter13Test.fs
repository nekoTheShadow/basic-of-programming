module Chapter13Test

open Person
open Chapter13
open Xunit

[<Theory>]
[<InlineData("A", 1)>]
[<InlineData("B", 2)>]
[<InlineData("O", 3)>]
[<InlineData("AB", 0)>]
let ``countKetsuekiは指定された血液型を持つ人の数を数える``(bloodType, expected) =
    let persons = [
        {Name="1"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="A"};
        {Name="2"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="B"};
        {Name="3"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="B"};
        {Name="3"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="O"};
        {Name="3"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="O"};
        {Name="3"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="O"};
    ]
    Assert.Equal(expected, (countKetsueki persons bloodType))
    
    
