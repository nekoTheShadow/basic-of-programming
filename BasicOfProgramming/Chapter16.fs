module Chapter16

let sumList lst =
    let rec f digits sum = 
        match digits with
        | [] -> []
        | d::ds -> (sum + d)::(f ds (sum + d))
    in f lst 0

let rec foldLeft f init lst =
    let rec g acc lst = 
        match lst with
        | [] -> acc
        | x::xs -> g (f acc x) xs
    in g init lst