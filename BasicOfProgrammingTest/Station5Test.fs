module Station5Test

open Xunit
open Station
open Station5

[<Fact>]
let ``問題23.3 dijkstraは始点(ローマ字)から終点(ローマ字)までの最短距離を求める`` () =
    let expected1 = {Namae = "護国寺"; SaitanKyori = 9.8; TemaeList = ["護国寺"; "江戸川橋"; "飯田橋"; "市ヶ谷"; "麹町"; "永田町"; "青山一丁目"; "表参道"; "渋谷"]} 
    let expected2 = {Namae = "目黒"; SaitanKyori = 12.7000000000000028; TemaeList = ["目黒"; "白金台"; "白金高輪"; "麻布十番"; "六本木一丁目"; "溜池山王"; "永田町"; "麹町"; "市ヶ谷"; "飯田橋"; "後楽園"; "茗荷谷"]} 
    Assert.Equal(expected1, (dijkstra "shibuya" "gokokuji"))
    Assert.Equal(expected2, (dijkstra "myogadani" "meguro"))