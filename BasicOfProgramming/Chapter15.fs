module Chapter15

let rec quickSort lst =
    let take n lst p = List.filter (fun item -> p item n) lst in
    let takeEqual n lst = take n lst (=) in
    let takeLess n lst = take n lst (<) in
    let takeGraeater n lst = take n lst (>) in
    match lst with
    | [] -> []
    | x::xs -> quickSort (takeLess x xs)
                @ takeEqual x lst
                @ quickSort (takeGraeater x xs)

let rec gcd m n =
    if n = 0 then
        m
    else 
        gcd n (m % n)

let prime n =
    let rec seive lst =
        printfn "[問題21.2] List.length lst ---> %d" (List.length lst)
        match lst with
        | [] -> []
        | x::xs -> x::(seive (List.filter (fun y -> y % x <> 0) xs)) in
    seq {2..n} |> Seq.toList |> seive
 
 