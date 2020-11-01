module Station2

open Station

let rec getEkikanKyori name1 name2 ekikanTree =
    match ekikanTree with
    | Empty -> infinity
    | Node(left, name, d, right) ->
        if name = name1 then
            assoc name2 d
        else if name1 < name then
            getEkikanKyori name1 name2 left
        else 
            getEkikanKyori name1 name2 right


let koushin p v ekikanList =
    List.map (fun q ->
        let kyori = getEkikanKyori p.Namae q.Namae ekikanList in
        if kyori = infinity || p.SaitanKyori + kyori >= q.SaitanKyori then
            q
        else
            {Namae=q.Namae; SaitanKyori=p.SaitanKyori + kyori; TemaeList=q.Namae::p.TemaeList}
    ) v


let rec dijkstraMain ekiList ekikanTree = 
    match ekiList with
    | [] -> []
    | e::es ->
        let (f, fs) = saitanWoBunri (e::es) in
        let gs = koushin f fs ekikanTree in
        f :: dijkstraMain gs ekikanTree

let dijkstra startRomaji endRomaji = 
    let startKanji = romajiToKanji startRomaji (seiretsu globalEkimeiList) in
    let endKanji = romajiToKanji endRomaji (seiretsu globalEkimeiList) in
    let ekiList = dijkstraMain (makeInitialEkiList globalEkimeiList startKanji) (insertsEkikan Empty globalEkikanList) in
    List.find (fun eki -> eki.Namae = endKanji) ekiList
