module Chapter10

open Chapter08

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