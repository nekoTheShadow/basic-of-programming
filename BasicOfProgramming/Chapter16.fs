module Chapter16

let sumList lst =
    let rec f digits sum = 
        match digits with
        | [] -> []
        | d::ds -> (sum + d)::(f ds (sum + d))
    in f lst 0