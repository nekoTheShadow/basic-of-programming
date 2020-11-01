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