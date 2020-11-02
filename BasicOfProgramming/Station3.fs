module Station3

open Station

exception NotFoundException

let rec assoc key d = 
    match d with
    | [] -> raise NotFoundException
    | (k, v)::e -> if k = key then v else (assoc key e)

let rec getEkikanKyori name1 name2 ekikanTree =
    match ekikanTree with
    | Empty -> raise NotFoundException
    | Node(left, name, d, right) ->
        if name = name1 then
            assoc name2 d
        else if name1 < name then
            getEkikanKyori name1 name2 left
        else 
            getEkikanKyori name1 name2 right
