module Chapter10Test

open Xunit
open Chapter10
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