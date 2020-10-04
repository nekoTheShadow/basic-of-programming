module Chapter10

let rec insert lst n = 
    match lst with
    | [] -> [n]
    | x::xs -> 
        if n <= x then
           n :: x :: xs
        else
            x :: (insert xs n)
