module Chapter17Test

open Xunit
open Chapter17

[<Fact>]
let ``問題17.1 nenreiは誕生年と現在年から年齢を計算する。``() =
    Assert.Equal(28, (nenrei (Heisei 4) (Heisei 32)))
    Assert.Equal(26, (nenrei (Heisei 6) (Heisei 32)))
    Assert.Equal(60, (nenrei (Showa 35) (Heisei 32)))
    Assert.Equal(56, (nenrei (Showa 39) (Heisei 32)))