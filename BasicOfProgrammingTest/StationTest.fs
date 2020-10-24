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

[<Fact>]
let ``問題12.2 makeEkiListはEkimeiのリストからEkiのリストを作成する``() =
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

[<Fact>]
let ``問題12.3 shokikaはEkimeiリストを初期化する``() = 
    let ekimeiList = [
        {Namae="代々木上原"; SaitanKyori=infinity; TemaeList=[]};
        {Namae="代々木公園"; SaitanKyori=infinity; TemaeList=[]};
        {Namae="明治神宮前"; SaitanKyori=infinity; TemaeList=[]};
    ]
    let expected = [
        {Namae="代々木上原"; SaitanKyori=infinity; TemaeList=[]};
        {Namae="代々木公園"; SaitanKyori=0.0; TemaeList=[]};
        {Namae="明治神宮前"; SaitanKyori=infinity; TemaeList=[]};
    ]
    isEqual expected (shokika ekimeiList "代々木公園")


[<Fact>]
let ``問題12.4 seirtsuはEkimeiリストをひらがなの順番に並べ替えて重複を取り除く``() =
    let ekimeiList = [
        {Kanji="1"; Kana="C"; Romaji="1"; Shozoku="1"}; 
        {Kanji="2"; Kana="A"; Romaji="2"; Shozoku="2"};
        {Kanji="3"; Kana="B"; Romaji="3"; Shozoku="3"};
        {Kanji="4"; Kana="A"; Romaji="4"; Shozoku="4"};
        {Kanji="5"; Kana="B"; Romaji="5"; Shozoku="5"};
    ]
    let expected = [
        {Kanji="4"; Kana="A"; Romaji="4"; Shozoku="4"};
        {Kanji="5"; Kana="B"; Romaji="5"; Shozoku="5"};
        {Kanji="1"; Kana="C"; Romaji="1"; Shozoku="1"}; 
    ]
    isEqual expected (seiretsu ekimeiList)

// ================================================================
// 問題14.7でkoushin1をprivate化したため、テストコードをコメントアウト
// ================================================================
// type ``問題13-6 koushin1はqの情報を更新する`` () =
//     [<Fact>]
//     let ``pとqがつながっていなかったら何もしない``() =
//         let p = {Namae="代々木上原"; SaitanKyori=infinity; TemaeList=[]}
//         let q = {Namae="明治神宮前"; SaitanKyori=infinity; TemaeList=[]}
//         Assert.Equal(q, (koushin1 p q))
    
//     [<Fact>]
//     let ``pとqがつながっていなかったら距離とTemaeListが更新される``() =
//         let p = {Namae="代々木上原"; SaitanKyori=1.0; TemaeList=["茗荷谷"]}
//         let q = {Namae="代々木公園"; SaitanKyori=infinity; TemaeList=[]}
//         let r = {Namae="代々木公園"; SaitanKyori=2.0; TemaeList=["代々木上原"; "茗荷谷"]}
//         Assert.Equal(r, (koushin1 p q))

[<Fact>]
let ``問題13.7 koushinは未確定の駅のリストvに対して更新処理を行う``() =
    let p = {Namae="代々木上原"; SaitanKyori=1.0; TemaeList=["茗荷谷"]}
    let v = [
        {Namae="明治神宮前"; SaitanKyori=infinity; TemaeList=[]}
        {Namae="代々木公園"; SaitanKyori=infinity; TemaeList=[]}
    ]
    let expected = [
        {Namae="明治神宮前"; SaitanKyori=infinity; TemaeList=[]};
        {Namae="代々木公園"; SaitanKyori=2.0; TemaeList=["代々木上原"; "茗荷谷"]};
    ]
    isEqual expected (koushin p v globalEkikanList)


[<Fact>]
let ``問題14.12 makeInitialEkiListは初期化されたEkiのリストを作成する``() =
    let ekimeiList = [
        {Kanji="代々木上原"; Kana="よよぎうえはら"; Romaji="yoyogiuehara"; Shozoku="千代田線"}; 
        {Kanji="代々木公園"; Kana="よよぎこうえん"; Romaji="yoyogikouen"; Shozoku="千代田線"}; 
        {Kanji="明治神宮前"; Kana="めいじじんぐうまえ"; Romaji="meijijinguumae"; Shozoku="千代田線"};  
    ]
    let expected = [
        {Namae="代々木上原"; SaitanKyori=infinity; TemaeList=[]};
        {Namae="代々木公園"; SaitanKyori=0.0; TemaeList=[]};
        {Namae="明治神宮前"; SaitanKyori=infinity; TemaeList=[]};
    ]
    isEqual expected (makeInitialEkiList ekimeiList "代々木公園")

[<Fact>]
let ``問題15.5 saitanWoBunriは最短距離が最小の駅とそれ以外のリストをタプルにする。``() =
    let eki1 = {Namae="池袋"; SaitanKyori = infinity; TemaeList = []}
    let eki2 = {Namae="新大塚"; SaitanKyori = 1.2; TemaeList = ["新大塚"; "茗荷谷"]}
    let eki3 = {Namae="茗荷谷"; SaitanKyori = 0.; TemaeList = ["茗荷谷"]}
    let eki4 = {Namae="後楽園"; SaitanKyori = infinity; TemaeList = []}
    let (e, es) = saitanWoBunri [eki1; eki2; eki3; eki4]
    Assert.Equal(eki3, e)
    isEqual [eki1, eki2, eki4], es
