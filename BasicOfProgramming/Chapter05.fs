module Chapter05

open System

let jikan hour = if hour <= 12 then "午前" else "午後"

let seiza month day = 
    let between m1 d1 m2 d2 = 
        let date = DateTime(2020, month, day)
        let date1 = DateTime(2020, m1, d1)
        let date2 = DateTime(2020, m2, d2)
        date1 <= date && date <= date2

    let ranges = [
        ( 3, 21,  4, 19, "おひつじ座");
        ( 4, 20,  5, 20, "おうし座");
        ( 5, 21,  6, 21, "ふたご座");
        ( 6, 23,  7, 22, "かに座");
        ( 7, 23,  8, 22, "しし座");
        ( 8, 23,  9, 22, "おとめ座");
        ( 9, 23, 10, 23, "てんびん座");
        (10, 24, 11, 22, "さそり座"); 
        (11, 23, 12, 21, "いて座"); 
        (12, 22,  1, 19, "やぎ座");
        ( 1, 20,  2, 18, "みずがめ座");
        ( 2, 19,  3, 20, "うお座");
    ]

    let _, _, _, _, sign = ranges |> List.find(fun (m1, d1, m2, d2, _) -> between m1 d1 m2 d2)
    sign


let hanbetsushiki a b c = b*b-4.0*a*c

let kaiNoKosu a b c = 
    let d = hanbetsushiki a b c
    if      d > 0.0 then 2
    else if d < 0.0 then 0
    else                 1

let kyosukai a b c = hanbetsushiki a b c < 0.0

let taikei m kg =
    let bmi = kg/(m**2.0)
    if      bmi < 18.5 then "やせ"
    else if bmi < 25.0 then "標準"
    else if bmi < 30.0 then "肥満"
    else                    "高度肥満"