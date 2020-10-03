module Chapter04Test

open Xunit
open Chapter04

[<Fact>]
let ``問題4.1 baitoKyuyoはその月の給与を返す`` () =
    let actual = baitoKyuyo 1 30
    Assert.Equal(28500, actual)

[<Fact>]
let ``問題4.2 jikoshokaiは与えられた名前を使った自己紹介をする`` () =
    let actual = jikoshokai "田中"
    Assert.Equal("わたしの名前は田中です", actual)

[<Fact>]
let ``問題4.3 hyojunTaijuは与えられた身長(m)をもとに標準体重(kg)を求める`` () =
    let actual = hyoujunTaiju 1.6
    Assert.Equal(56.32, actual, 2)
   
[<Fact>]
let ``問題4.4 bmiはBMI指数を求める`` () =
    let actual = bmi 1.6 60.0
    Assert.Equal(23.44, actual, 2)

[<Theory>]
[<InlineData(1, 2)>]
[<InlineData(2, 4)>]
[<InlineData(3, 6)>]
let ``問題4.6 tsuruNoAshiは鶴の数から足の本数の合計を計算する`` (tsuru, expected) =
    let actual = tsuruNoAshi tsuru
    Assert.Equal(expected, actual)
   
[<Theory>]
[<InlineData(1, 1, 6)>]
[<InlineData(2, 2, 12)>]
[<InlineData(3, 3, 18)>]
let ``問題4.7 tsusuKameNoAshiは鶴と亀の数から足の本数の合計を計算する`` (tsuru, kame, expected) =
    let actual = tsusuKameNoAshi tsuru kame
    Assert.Equal(expected, actual)

[<Theory>]
[<InlineData(50, 156, 22)>]
[<InlineData(10, 32, 4)>]
[<InlineData(8, 26, 3)>]
let ``問題4.7 tsusuKameは鶴と亀の頭数と足の本数の合計から鶴の頭数を計算する`` (hiki, ashi, expected) =
    let actual = tsurukame hiki ashi
    Assert.Equal(expected, actual)