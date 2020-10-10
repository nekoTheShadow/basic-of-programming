module Chapter11

let rec sumOfSquare n = 
    if n = 0 then
        0
    else 
        (n * n) + sumOfSquare (n - 1)

 