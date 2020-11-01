module Chapter17Test

open Xunit
open Chapter17

[<Fact>]
let ``問題17.1 nenreiは誕生年と現在年から年齢を計算する。``() =
    Assert.Equal(28, (nenrei (Heisei 4) (Heisei 32)))
    Assert.Equal(26, (nenrei (Heisei 6) (Heisei 32)))
    Assert.Equal(60, (nenrei (Showa 35) (Heisei 32)))
    Assert.Equal(56, (nenrei (Showa 39) (Heisei 32)))

[<Fact>]
let ``問題17.2 seizaはyear型から星座を求める。``() =
    Assert.Equal(Gemini, (seiza (June 11)))
    Assert.Equal(Cancer, (seiza (June 30)))
    Assert.Equal(Virgo, (seiza (September 17)))
    Assert.Equal(Libra, (seiza (October 7)))

[<Fact>]
let ``問題17.17 minimumはリストの最小値を求める。``() =
    Assert.Equal(3, minimum 3 [])
    Assert.Equal(1, minimum 1 [2])
    Assert.Equal(2, minimum 3 [2])
    Assert.Equal(1, minimum 3 [2; 6; 4; 1; 8])