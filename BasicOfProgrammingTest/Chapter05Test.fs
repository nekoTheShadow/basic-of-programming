module Chapter05Test

open Xunit
open Chapter05

[<Theory>]
[<InlineData(1, "午前")>]
[<InlineData(13, "午後")>]
let ``問題5.2 jikanは午後か午前かを判定する`` (hour, expected) = 
    let actual = jikan hour
    Assert.Equal(expected, actual)

[<Theory>]
[<InlineData(6, 11, "ふたご座")>]
[<InlineData(6, 30, "かに座")>]
[<InlineData(9, 17, "おとめ座")>]
[<InlineData(10, 07, "てんびん座")>]
let ``問題5.3 seizaは与えられた日付の12星座を導出する`` (month, day, expected) = 
    let actual = seiza month day
    Assert.Equal(expected, actual)

[<Theory>]
[<InlineData(1.0, 5.0, 4.0, 9.0)>]
[<InlineData(2.0, -4.0, 2.0, 0.0)>]
[<InlineData(1.0, 2.0, 4.0, -12.0)>]
let ``問題5.4 hanbetsushikiは二次方程式ax^2+bx+c=0の判別式の値を計算する``(a, b, c, expected) = 
    let actual = hanbetsushiki a b c
    Assert.Equal(expected, actual)
 
[<Theory>]
[<InlineData(1.0, 5.0, 4.0, 2)>]
[<InlineData(2.0, -4.0, 2.0, 1)>]
[<InlineData(1.0, 2.0, 4.0, 0)>]
let ``問題5.5 kaiNoKosuは二次方程式ax^2+bx+c=0の解の個数を計算する``(a, b, c, expected) = 
    let actual = kaiNoKosu a b c
    Assert.Equal(expected, actual)