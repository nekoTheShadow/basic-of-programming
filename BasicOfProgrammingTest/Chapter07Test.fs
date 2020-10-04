module Chapter07

open Xunit
open Chapter07

[<Theory>]
[<InlineData(10, 20, 30, 40, 50, 150, 30)>]
[<InlineData(10, 10, 10, 10, 10, 50, 10)>]
[<InlineData(0, 0, 0, 0, 0, 0, 0)>]
let ``問題7.1 goukeiNoHeikinは5強化の合計点と平均点を計算する`` (japanese, math, english, science, society, sum, avg) =
    let (actualSum, actualAvg) = goukeiToHeikin japanese math english science society
    Assert.Equal(sum, actualSum)
    Assert.Equal(avg, actualAvg)