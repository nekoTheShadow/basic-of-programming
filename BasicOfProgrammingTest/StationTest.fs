module StationTest

open Xunit
open Station

[<Fact>]
let ``問題8.6 hyojiはEkimeiレコードをPrettyPrintする`` () =
    let actual = hyoji {Kanji="茗荷谷"; Kana="みょうがたに"; Shozoku="丸の内線"; Romaji="myogadani"}
    Assert.Equal("丸の内線, 茗荷谷(みょうがたに)", actual)


type ``問題10-10 romajiToKanjiは駅名リストをもとにローマ字表記から漢字表記に変換する`` () = 
    [<Fact>]
    let ``変換できない場合は空文字を返す`` ()= 
        Assert.Equal("", (romajiToKanji "xxx" globalEkimeiList))
    
    [<Fact>]
    let ``変換できる場合は漢字表記を返す`` ()= 
        Assert.Equal("茗荷谷", (romajiToKanji "myogadani" globalEkimeiList))

type ``問題10-11 getEkikanKyoriは駅間リストをもとにふたつの駅の距離を求める`` () =
    [<Fact>]
    let ``ふたつの駅が直接つながっていない場合はinfinityを返す`` () =
        Assert.Equal(infinity, (getEkikanKyori "代々木上原" "明治神宮" globalEkikanList))
    
    [<Fact>]
    let ``ふたつの駅が直接つながっている場合はその距離を返す`` () =
        Assert.Equal(1.0, (getEkikanKyori "代々木上原" "代々木公園" globalEkikanList))
    
    [<Fact>]
    let ``始点と終点が反対でも正しく動くこと`` () =
        Assert.Equal(1.0, (getEkikanKyori "代々木公園" "代々木上原" globalEkikanList))

