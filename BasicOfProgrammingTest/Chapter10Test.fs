module Chapter10Test

open Xunit
open Chapter10
open Chapter08
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