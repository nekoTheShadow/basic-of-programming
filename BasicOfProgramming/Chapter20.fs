module Chapter20

module MySet = begin 
    let empty = []

    let singleton x = [x]

    let rec union set1 set2 =
        match set2 with
        | [] -> set1
        | x::xs -> 
            if List.contains x set1 then 
                union set1 xs
            else
                union (x::set1) xs
    
    let inter set1 set2 =
        List.fold (fun set v -> if List.contains v set1 then v::set else set) empty set2

    let diff set1 set2 =
        List.fold (fun set v -> if List.contains v set2 then set else v::set) empty set1
    
    let mem v set = List.contains v set
end



