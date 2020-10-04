module Chapter09

open Chapter08

let seasons = "春" :: "夏" :: "秋" :: "冬" ::[]
let persons = {Name="田中"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="A"} ::
              {Name="山田"; Height=1.7; Weight=50.0; Date="2020/02/01"; BloodType="B"} ::
              {Name="中田"; Height=1.8; Weight=40.0; Date="2020/03/01"; BloodType="O"} :: []
let weekdays = ["日曜日"; "月曜日"; "火曜日"; "水曜日"; "木曜日"; "金曜日"; "土曜日"]

let rec length lst =
    match lst with
    | [] -> 0
    | first::rest -> 1 + length rest

let rec even lst =
    match lst with
    | [] -> []
    | x::xs -> if x%2 = 0 then x :: even xs else even xs

let rec concat lst =
    match lst with
    | [] -> ""
    | x::xs -> x + concat xs