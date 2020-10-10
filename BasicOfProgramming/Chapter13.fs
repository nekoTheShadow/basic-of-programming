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