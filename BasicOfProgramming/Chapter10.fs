module Chapter10

open Chapter08
open Person

let rec insert lst n = 
    match lst with
    | [] -> [n]
    | x::xs -> 
        if n <= x then
           n :: x :: xs
        else
            x :: (insert xs n)

let rec insSort lst =
    match lst with
    | [] -> []
    | x::xs -> insert (insSort xs) x

type Gakusei = {
    Namae: string;
    Tensu: int;
    Seiseki: string;
}

let rec gakuseiInsert students student = 
    match students with
    | [] -> [student]
    | x::xs -> 
        if student.Tensu <= x.Tensu then 
            student :: x :: xs
        else
            x :: (gakuseiInsert xs student)

let rec gakuseiSort students = 
    match students with 
    | [] -> []
    | x::xs ->  gakuseiInsert (gakuseiSort xs) x

let rec personInsert persons person = 
    match persons with
    | [] -> [person]
    | p::ps -> 
        if person.Name <= p.Name then 
            person :: p :: ps
        else
            p :: (personInsert ps person)

let rec personSort persons =
    match persons with
    | [] -> []
    | p::ps -> personInsert (personSort ps) p

let rec gakuseiMax students =
    match students with
    | [] -> {Namae=""; Tensu=System.Int32.MinValue; Seiseki=""}
    | s::ss ->
        let t = gakuseiMax ss in 
            if s.Tensu < t.Tensu then t else s

let rec ketsuekiShukei persons =
    match persons with
    | [] -> (0, 0, 0, 0)
    | {BloodType=bloodtype}::ps ->
        let (a, b, o, ab) = (ketsuekiShukei ps) in
            if      bloodtype = "A" then (a+1, b,   o,   ab  ) 
            else if bloodtype = "B" then (a,   b+1, o,   ab  ) 
            else if bloodtype = "O" then (a,   b,   o+1, ab  ) 
            else                         (a,   b,   o  , ab+1)

let saitaKetsueki persons = 
    let rec max tpls = 
        match tpls with
        | [] -> (-1, "")
        | (v1, s1)::ts -> 
            let (v2, s2) = max ts in
                if v1 < v2 then (v2, s2) else (v1, s1)
    
    let (a, b, o, ab) = ketsuekiShukei persons in
        let (_, blood) = max [(a, "A"); (b, "B"); (o, "O"); (ab, "AB")]
        blood

let rec equalLength lst1 lst2 =
    match lst1, lst2 with
    | [], [] -> true
    | [], x::xs
    | x::xs, [] -> false
    | x::xs, y::ys -> equalLength xs ys

    