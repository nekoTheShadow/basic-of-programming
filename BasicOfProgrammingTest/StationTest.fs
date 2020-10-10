module StationTest

open Xunit
open Station
open TestUtil

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
        Assert.Equal(infinity, (getEkikanKyori "代々木上原" "明治神宮前駅" globalEkikanList))
    
    [<Fact>]
    let ``ふたつの駅が直接つながっている場合はその距離を返す`` () =
        Assert.Equal(1.0, (getEkikanKyori "代々木上原" "代々木公園" globalEkikanList))
    
    [<Fact>]
    let ``始点と終点が反対でも正しく動くこと`` () =
        Assert.Equal(1.0, (getEkikanKyori "代々木公園" "代々木上原" globalEkikanList))

type ``問題10-12 kyoriWoHyojiは2駅間の距離についてPretty Printする`` () =
    [<Fact>]
    let ``2つの駅が直接つながっている場合「A駅からB駅まではCkmです」を返す`` () =
        Assert.Equal("代々木上原駅から代々木公園駅までは1.0kmです", (kyoriWoHyoji "yoyogiuehara" "yoyogikouen" globalEkimeiList globalEkikanList))
    [<Fact>]
    let ``2つの駅が直接つながっていない場合「A駅とB駅はつながっていません」を返す`` () =
        Assert.Equal("代々木上原駅と明治神宮前駅はつながっていません", (kyoriWoHyoji "yoyogiuehara" "meijijinguumae" globalEkimeiList globalEkikanList))
    [<Fact>]
    let ``A駅が存在しない場合「Aという駅は存在しません」を返す`` () =
        Assert.Equal("XXXという駅は存在しません", (kyoriWoHyoji "XXX" "meijijinguumae" globalEkimeiList globalEkikanList))
    [<Fact>]
    let ``B駅が存在しない場合「Bという駅は存在しません」を返す`` () =
        Assert.Equal("YYYという駅は存在しません", (kyoriWoHyoji "meijijinguumae" "YYY" globalEkimeiList globalEkikanList))

let ``makeEkiListはEkimeiのリストからEkiのリストを作成する``() =
    let ekimeiList = [
        {Kanji="代々木上原"; Kana="よよぎうえはら"; Romaji="yoyogiuehara"; Shozoku="千代田線"}; 
        {Kanji="代々木公園"; Kana="よよぎこうえん"; Romaji="yoyogikouen"; Shozoku="千代田線"}; 
        {Kanji="明治神宮前"; Kana="めいじじんぐうまえ"; Romaji="meijijinguumae"; Shozoku="千代田線"};  
    ]
    let expected = [
        {Namae="代々木上原"; SaitanKyori=infinity; TemaeList=[]};
        {Namae="代々木公園"; SaitanKyori=infinity; TemaeList=[]};
        {Namae="明治神宮前"; SaitanKyori=infinity; TemaeList=[]};
    ]
    isEqual expected (makeEkiList ekimeiList)