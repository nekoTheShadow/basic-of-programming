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

let koushin p v ekikanTree =
    List.map (fun q ->
        try 
            let kyori = getEkikanKyori p.Namae q.Namae ekikanTree in
            if p.SaitanKyori + kyori >= q.SaitanKyori then
                q
            else 
                {Namae=q.Namae; SaitanKyori=p.SaitanKyori + kyori; TemaeList=q.Namae::p.TemaeList}
        with NotFoundException -> q
    ) v