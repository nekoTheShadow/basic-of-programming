module Chapter10

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
