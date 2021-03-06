module Chapter07Test

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

[<Theory>]
[<InlineData("田中", "A", "田中さんの評価はAです")>]
[<InlineData("山田", "B", "山田さんの評価はBです")>]
[<InlineData("木村", "C", "木村さんの評価はCです")>]
let ``問題7.2 seisekiは「XXさんの評価はXです」という文字列を作成する`` (name, grade, expected) =
    let actual = seiseki (name, grade)
    Assert.Equal(expected, actual)

[<Theory>]
[<InlineData(1, 1, 1, -1)>]
[<InlineData(0, 0, 0, 0)>]
[<InlineData(1, -1, 1, 1)>]
let ``問題7.3 tasishoXはX軸について対称な点の座標を計算する`` (x1, y1, x2, y2) =
    let (x3, y3) = taishoX (x1, y1)
    Assert.Equal(x2, x3)
    Assert.Equal(y2, y3)

[<Theory>]
[<InlineData(0.0, 0.0, 1.0, 2.0, 0.5, 1.0)>]
[<InlineData(2.3, 5.1, 7.6, 1.7, 4.95, 3.4)>]
[<InlineData(-3.8, -2.4, 3.4, -1.2, -0.2, -1.8)>]
let ``問題7.4 chutenは2点の中点を計算する`` (x1, y1, x2, y2, x3, y3) =
    let (x4, y4) = chuten (x1, y1) (x2, y2)
    Assert.Equal(x3, x4, 2)
    Assert.Equal(y3, y4, 2)