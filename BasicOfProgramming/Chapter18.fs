module Chapter18

let rec countUrikireYasai yaoyaList yasaiList = 
    match yasaiList with
    | [] -> 0
    | y::ys -> 
        if List.exists (fun (k, v) -> k = y) yaoyaList then
            countUrikireYasai yaoyaList ys
        else
            countUrikireYasai yaoyaList ys + 1

exception NotFoundException

let rec assoc key d = 
    match d with
    | [] -> raise NotFoundException
    | (k, v)::es -> 
        if k = key then
            v
        else
            assoc key es