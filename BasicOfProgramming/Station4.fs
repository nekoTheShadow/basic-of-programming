module Station4

open Station
open RedBlackTree

let insertEkikan ekikanTree ekikan =
    let insert ekikanTree kiten shuten kyori =
        try 
            let xs = search ekikanTree kiten in
            insert ekikanTree kiten ((shuten, kyori)::xs)
        with NotFoundException ->
            insert ekikanTree kiten [(shuten, kyori)] in
    insert (insert ekikanTree ekikan.Kiten ekikan.Shuten ekikan.Kyori) ekikan.Shuten ekikan.Kiten ekikan.Kyori

let rec getEkikanKyori kanji1 kanji2 ekikanTree =
    assoc kanji1 (search ekikanTree kanji2)

let koushin p v ekikanTree =
    List.map (fun q ->
        let kyori = getEkikanKyori p.Namae q.Namae ekikanTree in
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

let printEki eki =
    printfn "%s (%f km)" (List.rev eki.TemaeList |> String.concat " ") eki.SaitanKyori in

let dijkstra startRomaji endRomaji = 
    let startKanji = romajiToKanji startRomaji (seiretsu globalEkimeiList) in
    let endKanji = romajiToKanji endRomaji (seiretsu globalEkimeiList) in
    let ekiList = dijkstraMain (makeInitialEkiList globalEkimeiList startKanji) (List.fold (insertEkikan) Empty globalEkikanList) in
    let eki = List.find (fun eki -> eki.Namae = endKanji) ekiList in
    printEki eki
    eki


    