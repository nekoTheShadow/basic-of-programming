module Chapter14Test

open Xunit
open Chapter14
open TestUtil

[<Fact>]
let ``問題14.1 evenはリストの偶数の要素のみを集めたリストを作成する`` () =
    isEqual [2; 6; 4] (even [2; 1; 6; 4; 7])

[<Fact>]
let ``問題14.2 countAは成績がAの学生の数を数える`` () =
    let gakuesiList = [
        {Namae="1"; Tensuu=1; Seiseki="A"};
        {Namae="2"; Tensuu=2; Seiseki="B"};
        {Namae="3"; Tensuu=3; Seiseki="C"};
        {Namae="4"; Tensuu=4; Seiseki="A"};
        {Namae="5"; Tensuu=5; Seiseki="B"};
    ]
    Assert.Equal(2, (countA gakuesiList))