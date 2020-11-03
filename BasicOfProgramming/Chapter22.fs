module Chapter22

let count = ref -1
let getnsym s =
    count := !count + 1
    sprintf "%s%d" s !count

let fibArray arr = 
    let rec f n x1 x2 = 
        if n = Array.length arr then
            arr
        else
            arr.[n] <- x1
            f (n + 1) x2 (x1 + x2)
    in f 0 0 1