module Chapter10Test

open Xunit
open Chapter10
open Person
open TestUtil

[<Fact>]
let ``問題10.1 insertは昇順となる位置にnを挿入する`` () =
    isEqual [1; 3; 4; 5; 7; 8] (insert [1; 3; 4; 7; 8] 5)

[<Fact>]
let ``問題10.2 inSortは整数のリストを昇順に並び替える`` () =
    isEqual [1; 3; 4; 5; 7; 8] (insSort [5; 3; 8; 1; 7; 4])

[<Fact>]
let ``問題10.3 gakuseiSortは学生を成績の昇順でソートする。`` () =
    let expected = [
        {Namae="A"; Tensu=10; Seiseki="A"};
        {Namae="B"; Tensu=20; Seiseki="B"};
        {Namae="C"; Tensu=30; Seiseki="C"};
        {Namae="D"; Tensu=40; Seiseki="D"};
        {Namae="E"; Tensu=50; Seiseki="E"};
    ]
    let students = [
        {Namae="D"; Tensu=40; Seiseki="D"};
        {Namae="A"; Tensu=10; Seiseki="A"};
        {Namae="E"; Tensu=50; Seiseki="E"};
        {Namae="C"; Tensu=30; Seiseki="C"};
        {Namae="B"; Tensu=20; Seiseki="B"};
    ]
    isEqual expected (gakuseiSort students)

[<Fact>]
let ``問題10.4 personSortは名前の順番で人間をソートする`` () =
    let expected = [
        {Name="A"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="A"};
        {Name="B"; Height=1.7; Weight=50.0; Date="2020/02/01"; BloodType="B"};
        {Name="C"; Height=1.8; Weight=40.0; Date="2020/03/01"; BloodType="O"};
        {Name="D"; Height=1.9; Weight=30.0; Date="2020/03/01"; BloodType="AB"};
    ]
    let persons = [
        {Name="C"; Height=1.8; Weight=40.0; Date="2020/03/01"; BloodType="O"};
        {Name="A"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="A"};
        {Name="D"; Height=1.9; Weight=30.0; Date="2020/03/01"; BloodType="AB"};
        {Name="B"; Height=1.7; Weight=50.0; Date="2020/02/01"; BloodType="B"};
    ]
    isEqual expected (personSort persons)

[<Fact>]
let ``問題10.5/問題10.6 gakuseiMaxは最高得点を取った人を探す`` () =
    let students = [
        {Namae="D"; Tensu=40; Seiseki="D"};
        {Namae="A"; Tensu=10; Seiseki="A"};
        {Namae="E"; Tensu=50; Seiseki="E"};
        {Namae="C"; Tensu=30; Seiseki="C"};
        {Namae="B"; Tensu=20; Seiseki="B"};
    ]
    Assert.Equal({Namae="E"; Tensu=50; Seiseki="E"}, (gakuseiMax students))

[<Fact>]
let ``問題10.7 ketsuekiShukeiは各血液型の人が何人いるのかを数える`` () =
    let persons = [
        {Name="A"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="A"};
        {Name="A"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="A"};
        {Name="A"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="A"};
        {Name="A"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="A"};
        {Name="A"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="B"};
        {Name="A"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="B"};
        {Name="A"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="B"};
        {Name="A"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="O"};
        {Name="A"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="O"};
        {Name="A"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="AB"};
    ]
    Assert.Equal((4, 3, 2, 1), (ketsuekiShukei persons))

[<Fact>]
let ``問題10.8 saitaKetsuekiはもっとも人数が多い血液型を返す`` () =
    let persons = [
        {Name="A"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="A"};
        {Name="A"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="A"};
        {Name="A"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="A"};
        {Name="A"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="A"};
        {Name="A"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="B"};
        {Name="A"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="B"};
        {Name="A"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="B"};
        {Name="A"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="O"};
        {Name="A"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="O"};
        {Name="A"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="AB"};
    ]
    Assert.Equal("A", (saitaKetsueki persons))

type ``問題10-9 equalLengthはふたつのリストの長さが同じかどうかを判定する`` () =
    [<Fact>]
    let ``ひとつめのリストが長い場合はFalse``() =
        Assert.False(equalLength [1; 1] [3])

    [<Fact>]
    let ``ふたつめのリストが長い場合はFalse``() =
        Assert.False(equalLength [1] [2; 3])
    
    [<Fact>]
    let ``同じ長さの場合はTrue``() =
        Assert.True(equalLength [1; 2; 3] [4; 5; 6])