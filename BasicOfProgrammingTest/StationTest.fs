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
    let p = {Namae="代々木上原"; SaitanKyori=1.0; TemaeList=["代々木上原"; "茗荷谷"]}
    let v = [
        {Namae="明治神宮前"; SaitanKyori=infinity; TemaeList=[]}
        {Namae="代々木公園"; SaitanKyori=infinity; TemaeList=[]}
    ]
    let expected = [
        {Namae="明治神宮前"; SaitanKyori=infinity; TemaeList=[]};
        {Namae="代々木公園"; SaitanKyori=2.0; TemaeList=["代々木公園"; "代々木上原"; "茗荷谷"]};
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
        {Namae="代々木公園"; SaitanKyori=0.0; TemaeList=["代々木公園"]};
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
    isEqual [eki4; eki2; eki1] es


[<Fact>]
let ``問題16.4 dijkstraMainはdijkstraのメインループ``() =
    let eki1 = {Namae="池袋"; SaitanKyori = infinity; TemaeList = []}
    let eki2 = {Namae="新大塚"; SaitanKyori = 1.2; TemaeList = ["新大塚"; "茗荷谷"]}
    let eki3 = {Namae="茗荷谷"; SaitanKyori = 0.; TemaeList = ["茗荷谷"]}
    let eki4 = {Namae="後楽園"; SaitanKyori = infinity; TemaeList = []}
    let expected = [
        {Namae = "茗荷谷"; SaitanKyori = 0.; TemaeList = ["茗荷谷"]}; 
        {Namae = "新大塚"; SaitanKyori = 1.2; TemaeList = ["新大塚"; "茗荷谷"]}; 
        {Namae = "後楽園"; SaitanKyori = 1.8; TemaeList = ["後楽園"; "茗荷谷"]}; 
        {Namae = "池袋"; SaitanKyori = 3.; TemaeList = ["池袋"; "新大塚"; "茗荷谷"]}
    ]
    isEqual expected (dijkstraMain [eki1; eki2; eki3; eki4] globalEkikanList) 

[<Fact>]
let ``問題16.5 dijkstraは始点(ローマ字)から終点(ローマ字)までの最短距離を求める`` () =
    let expected1 = {Namae = "護国寺"; SaitanKyori = 9.8; TemaeList = ["護国寺"; "江戸川橋"; "飯田橋"; "市ヶ谷"; "麹町"; "永田町"; "青山一丁目"; "表参道"; "渋谷"]} 
    let expected2 = {Namae = "目黒"; SaitanKyori = 12.7000000000000028; TemaeList = ["目黒"; "白金台"; "白金高輪"; "麻布十番"; "六本木一丁目"; "溜池山王"; "永田町"; "麹町"; "市ヶ谷"; "飯田橋"; "後楽園"; "茗荷谷"]} 
    Assert.Equal(expected1, (dijkstra "shibuya" "gokokuji"))
    Assert.Equal(expected2, (dijkstra "myogadani" "meguro"))

[<Fact>]
let ``問題17.11 assocは連想リストを検索する``() =
    let d = [("新大塚", 1.2); ("後楽園", 1.8)]
    Assert.Equal(1.8, (assoc "後楽園" d))
    Assert.Equal(infinity, (assoc "池袋" d))

[<Fact>]
let ``問題17.12 EkikanTreeにEkikanを挿入する``() =
    let ekikan1 = {Kiten="池袋"; Shuten="新大塚"; Keiyu="丸ノ内線"; Kyori=1.8; Jikan=3}
    let ekikan2 = {Kiten="新大塚"; Shuten="茗荷谷"; Keiyu="丸ノ内線"; Kyori=1.2; Jikan=2}
    let ekikan3 = {Kiten="茗荷谷"; Shuten="後楽園"; Keiyu="丸ノ内線"; Kyori=1.8; Jikan=2}

    let tree1 = insertEkikan Empty ekikan1 
    let tree2 = insertEkikan tree1 ekikan2
    let tree3 = insertEkikan tree2 ekikan3
    let expected1 = Node(Node(Empty, "新大塚", [("池袋", 1.8)], Empty), "池袋", [("新大塚", 1.8)], Empty)
    let expected2 = Node(Node(Empty, "新大塚", [("茗荷谷", 1.2); ("池袋", 1.8)], Empty), "池袋", [("新大塚", 1.8)], Node(Empty, "茗荷谷", [("新大塚", 1.2)], Empty))
    let expected3 = Node(Node(Node (Empty, "後楽園", [("茗荷谷", 1.8)], Empty), "新大塚", [("茗荷谷", 1.2); ("池袋", 1.8)], Empty), "池袋", [("新大塚", 1.8)], Node(Empty, "茗荷谷", [("後楽園", 1.8); ("新大塚", 1.2)], Empty))
    Assert.Equal(expected1, tree1)
    Assert.Equal(expected2, tree2)
    Assert.Equal(expected3, tree3)

[<Fact>]
let ``問題17.13 insertsEkikanはEkikanTreeにすべてのEkikanを挿入する。``() =
    let ekikanList = [
        {Kiten="池袋"; Shuten="新大塚"; Keiyu="丸ノ内線"; Kyori=1.8; Jikan=3};
        {Kiten="新大塚"; Shuten="茗荷谷"; Keiyu="丸ノ内線"; Kyori=1.2; Jikan=2};
        {Kiten="茗荷谷"; Shuten="後楽園"; Keiyu="丸ノ内線"; Kyori=1.8; Jikan=2}
    ]
    let expected = Node(Node(Node (Empty, "後楽園", [("茗荷谷", 1.8)], Empty), "新大塚", [("茗荷谷", 1.2); ("池袋", 1.8)], Empty), "池袋", [("新大塚", 1.8)], Node(Empty, "茗荷谷", [("後楽園", 1.8); ("新大塚", 1.2)], Empty))
    Assert.Equal(expected, (insertsEkikan Empty ekikanList))