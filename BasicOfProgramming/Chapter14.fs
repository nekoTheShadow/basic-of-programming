module Chapter14

open Person

type Gakusei = {
    Namae: string;
    Tensuu: int;
    Seiseki: string;
}

let even lst = List.filter (fun v -> v%2=0) lst

let countA gakuseiList = List.length (List.filter (fun gakusei -> gakusei.Seiseki = "A") gakuseiList)

let concat lst = List.fold (+) "" lst

let gakuseiSum gakuseiList = List.sumBy (fun gakusei -> gakusei.Tensuu) gakuseiList

let f = fun x -> x*x-1
let g = fun person -> person.Name

let oneToN n = seq {1..n} |> Seq.sum
let fac n = seq {1..n} |> Seq.fold (*) 1