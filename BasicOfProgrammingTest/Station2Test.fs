module Station2Test

open Xunit
open Station
open Station2

type ``問題17-14 getEkikanKyoriは駅間リストをもとにふたつの駅の距離を求める`` () =
    [<Fact>]
    let ``ふたつの駅が直接つながっていない場合はinfinityを返す`` () =
        Assert.Equal(infinity, (getEkikanKyori "代々木上原" "明治神宮前駅" (insertsEkikan Empty globalEkikanList)))
    
    [<Fact>]
    let ``ふたつの駅が直接つながっている場合はその距離を返す`` () =
        Assert.Equal(1.0, (getEkikanKyori "代々木上原" "代々木公園" (insertsEkikan Empty globalEkikanList)))
    
    [<Fact>]
    let ``始点と終点が反対でも正しく動くこと`` () =
        Assert.Equal(1.0, (getEkikanKyori "代々木公園" "代々木上原" (insertsEkikan Empty globalEkikanList)))


[<Fact>]
let ``問題17.15 dijkstraは始点(ローマ字)から終点(ローマ字)までの最短距離を求める`` () =
    let expected1 = {Namae = "護国寺"; SaitanKyori = 9.8; TemaeList = ["護国寺"; "江戸川橋"; "飯田橋"; "市ヶ谷"; "麹町"; "永田町"; "青山一丁目"; "表参道"; "渋谷"]} 
    let expected2 = {Namae = "目黒"; SaitanKyori = 12.7000000000000028; TemaeList = ["目黒"; "白金台"; "白金高輪"; "麻布十番"; "六本木一丁目"; "溜池山王"; "永田町"; "麹町"; "市ヶ谷"; "飯田橋"; "後楽園"; "茗荷谷"]} 
    Assert.Equal(expected1, (dijkstra "shibuya" "gokokuji"))
    Assert.Equal(expected2, (dijkstra "myogadani" "meguro"))