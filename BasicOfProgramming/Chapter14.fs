module Chapter14

type Gakusei = {
    Namae: string;
    Tensuu: int;
    Seiseki: string;
}

let even lst = List.filter (fun v -> v%2=0) lst

let countA gakuseiList = List.length (List.filter (fun gakusei -> gakusei.Seiseki = "A") gakuseiList)

let concat lst = List.fold ((+)) "" lst

let gakuseiSum gakuseiList = List.sumBy (fun gakusei -> gakusei.Tensuu) gakuseiList