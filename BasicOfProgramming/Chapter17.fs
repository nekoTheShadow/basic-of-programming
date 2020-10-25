module Chapter17

type Nengou = Meiji of int
            | Taisho of int
            | Showa of int
            | Heisei of int

let toSeireki nengou = match nengou with
    | Meiji(n) -> n + 1867
    | Taisho(n) -> n + 1911
    | Showa(n) -> n + 1925
    | Heisei(n) -> n + 1988

let nenrei birthYear currentYear = (toSeireki currentYear) - (toSeireki birthYear)