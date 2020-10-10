module Chapter13

open Person

let rec countKetsueki persons bloodType =
    match persons with
    | [] -> 0
    | p::ps -> 
        if p.BloodType = bloodType then
           1 + (countKetsueki ps bloodType)
        else 
            countKetsueki ps bloodType

let personNamae persons = 
    List.map (fun p -> p.Name) persons

// 問題13.3
let f1 x = x
let f2 x y = x
let f3 x y = y
let f4 x f = (f x)
let f5 f g x = g (f x)