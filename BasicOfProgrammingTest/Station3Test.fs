module Station3Test

open Xunit
open Station
open Station3
open TestUtil

type ``問題18-4 getEkikanKyoriは駅間リストをもとにふたつの駅の距離を求める`` () =
    [<Fact>]
    let ``ふたつの駅が直接つながっていない場合はinfinityを返す`` () =
        Assert.Throws<NotFoundException>(System.Action(fun _ -> getEkikanKyori "代々木上原" "明治神宮前駅" (insertsEkikan Empty globalEkikanList) |> ignore))
    
    [<Fact>]
    let ``ふたつの駅が直接つながっている場合はその距離を返す`` () =
        Assert.Equal(1.0, (getEkikanKyori "代々木上原" "代々木公園" (insertsEkikan Empty globalEkikanList)))
    
    [<Fact>]
    let ``始点と終点が反対でも正しく動くこと`` () =
        Assert.Equal(1.0, (getEkikanKyori "代々木公園" "代々木上原" (insertsEkikan Empty globalEkikanList)))

[<Fact>]
let ``問題18.5 koushinは未確定の駅のリストvに対して更新処理を行う``() =
    let p = {Namae="代々木上原"; SaitanKyori=1.0; TemaeList=["代々木上原"; "茗荷谷"]}
    let v = [
        {Namae="明治神宮前"; SaitanKyori=infinity; TemaeList=[]}
        {Namae="代々木公園"; SaitanKyori=infinity; TemaeList=[]}
    ]
    let expected = [
        {Namae="明治神宮前"; SaitanKyori=infinity; TemaeList=[]};
        {Namae="代々木公園"; SaitanKyori=2.0; TemaeList=["代々木公園"; "代々木上原"; "茗荷谷"]};
    ]
    isEqual expected (koushin p v (insertsEkikan Empty globalEkikanList))