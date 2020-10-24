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