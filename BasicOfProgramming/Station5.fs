module Station5

open Station

let update d key value =
    List.fold
        (fun acc (k, v) -> if k = key then (key, value)::acc else (k, v)::acc)
        []
        d

let assoc d key =
    let _, v = List.find (fun (k, v) -> k = key) d in v

let insertEkikan ekikanTree ekikan =
    let insert ekikanTree kiten shuten kyori =
        try 
            let xs = RedBlackTree.search ekikanTree kiten in
            RedBlackTree.insert ekikanTree kiten ((shuten, kyori)::xs)
        with RedBlackTree.NotFoundException ->
            RedBlackTree.insert ekikanTree kiten [(shuten, kyori)] in
    insert (insert ekikanTree ekikan.Kiten ekikan.Shuten ekikan.Kyori) ekikan.Shuten ekikan.Kiten ekikan.Kyori

let rec dijkstraMain heap ekikanTree dictionary = 
    let (kyori, eki) = Heap.splitTop heap in
    if kyori = infinity then
        dictionary
    else
        let edges = RedBlackTree.search ekikanTree eki.Namae in
        let (newDictionary, newHeap) = 
            List.fold 
                (fun (d, h) (namae, kyori) -> 
                    let x = assoc d namae in
                    if eki.SaitanKyori + kyori < x.SaitanKyori then 
                        let newEki = {Namae=namae; SaitanKyori=eki.SaitanKyori + kyori; TemaeList=namae::eki.TemaeList} in
                        let newD = update d namae newEki in
                        let newH = Heap.insert h (eki.SaitanKyori + kyori) newEki in
                        (newD, newH)
                    else
                        (d, h)
                )
                (dictionary, heap)
                edges in
        dijkstraMain newHeap ekikanTree newDictionary

let distinct ekimeiList =
    List.fold (fun lst ekimei -> if List.contains ekimei.Kanji lst then lst else ekimei.Kanji::lst) [] ekimeiList

let dijkstra startRomaji endRomaji =
    let startKanji = romajiToKanji startRomaji (seiretsu globalEkimeiList) in
    let endKanji = romajiToKanji endRomaji (seiretsu globalEkimeiList) in
    let ekikanTree = List.fold (insertEkikan) RedBlackTree.Empty globalEkikanList in
    let dictionary = List.map (fun kanji -> if kanji = startKanji then (kanji, {Namae=startKanji; SaitanKyori=0.0; TemaeList=[startKanji]}) else (kanji, {Namae=kanji; SaitanKyori=infinity; TemaeList=[]})) (distinct globalEkimeiList) in
    let heap = Heap.insert (Heap.create 50000) 0.0 {Namae=startKanji; SaitanKyori=0.0; TemaeList=[startKanji]} in 
    assoc (dijkstraMain heap ekikanTree dictionary) endKanji