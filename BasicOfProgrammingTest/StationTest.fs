module StationTest

open Xunit
open Station

[<Fact>]
let ``問題8.6 hyojiはEkimeiレコードをPrettyPrintする`` () =
    let actual = hyoji {Kanji="茗荷谷"; Kana="みょうがたに"; Shozoku="丸の内線"; Romaji="myogadani"}
    Assert.Equal("丸の内線, 茗荷谷(みょうがたに)", actual)